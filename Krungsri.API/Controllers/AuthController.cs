using Krungsri.API.Models;
using Krungsri.DataAccess.Interfaces;
using Krungsri.Domain.Interfaces;
using Krungsri.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Krungsri.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMerchantRepository _merchantRepository;
        private readonly IAdminRepository _adminRepository;
        public AuthController(IAuthService authService, IMerchantRepository merchantRepository, IAdminRepository adminRepository)
        {
            _authService = authService;
            _merchantRepository = merchantRepository;
            _adminRepository = adminRepository;
        }
        [HttpPost("register")]
        public IActionResult Register(UserRegisterModel userRegister)
        {            
            UserDto user = new UserDto
            {                
                Email = userRegister.Email,
                Gender = userRegister.Gender,
                Birthdate = userRegister.Birthdate,
                FirstName = userRegister.FirstName,
                LastName = userRegister.LastName,
                Pin = userRegister.Pin,
                Balance = 0.00m,
                BookBank = _authService.GenerateBookBank(),
                PhoneNumber = userRegister.PhoneNumber
            };
            var regis = _authService.Register(user);
            if(regis != null)
            {
                return Ok(regis);
            }
            else
            {
                return new BadRequestResult();
            }
        }
        [HttpPost("sendotp")]
        public IActionResult SendOtp(SendOtpModel sendOtp)
        {
            var otp = _authService.SendOtpEmail(sendOtp.Email);            
            OtpDto otpDto = new OtpDto()
            {
                Email = sendOtp.Email,
                Otp = otp.Otp,             
                Ref = otp.Ref
            };            
            return new OkObjectResult(otpDto);            
        }
        [HttpPost("confirmotp")]
        public IActionResult ConfirmOtp([FromBody] ConfirmOtpModel otp)
        {
            if (_authService.CheckOtp(otp.Email, otp.Otp))
            {
                if (_authService.CheckExpireOtp(otp.Email))
                {
                    return new NoContentResult();
                }
                else
                {
                    return new OkResult();
                }
            }
            else
            {
                return new BadRequestResult();
            }
        }
        [HttpPost("userlogin")]
        public IActionResult UserLogin([FromBody] UserLoginModel userLogin)
        {
        IActionResult response = Unauthorized();
        UserLoginDto loginDto = new UserLoginDto()
        {
            Email = userLogin.Email,
            Password = userLogin.Password
        };
        var userDetail = _authService.GetUserLoginDto(userLogin.Email);
        if (userDetail == null)
        {
            return response;
        }
        var user = _authService.AuthenticateUser(loginDto);
        if (user != null)
        {
            var tokenString = _authService.GenerateJSONWebToken();
            var RefreshToken = _authService.GenRefreshToken();
            TokenDto tokenDto = new TokenDto()
            {
                RefreshToken = RefreshToken,
                UserId = userDetail.UserId
            };
            _authService.SaveRefreshToken(tokenDto);
            response = Ok(new { token = tokenString , UserId = tokenDto.UserId});
        }
        return response;
        }

        public IActionResult RefreshToken([FromBody] RefeshTokenModel refeshTokenModel)
        {
           var token =  _authService.GetTokenByRefreshToken(refeshTokenModel.RefreshToken);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }
            else
            {
                return Ok(new { Token = token });
            }
        }

        public class RefeshTokenModel
        {
            public string RefreshToken { get; set; }
        }
        [HttpPost("merchantlogin")]
        public IActionResult MerchantLogin([FromBody] MerchantLoginModel merchantLogin)
        {
            IActionResult response = Unauthorized();
            MerchantLoginDto loginDto = new MerchantLoginDto()
            {
                UserName = merchantLogin.UserName,
                Password = merchantLogin.Password
            };
            var merchant = _merchantRepository.GetMerchantByUserName(loginDto.UserName);
            var userDetail = _authService.GetMerchantLoginDto(merchantLogin.UserName);
            if (userDetail == null)
            {
                return response;
            }
            var user = _authService.AuthenticateMerchant(loginDto);
            if (user != null)
            {
                var tokenString = _authService.GenerateJSONWebToken();
                var RefreshToken = _authService.GenRefreshToken();
                MerchantTokenDto tokenDto = new MerchantTokenDto()
                {
                    RefreshToken = RefreshToken,
                    MerchantId = userDetail.MerchantId
                };
                _authService.SaveRefreshTokenMerchant(tokenDto);
                response = Ok(new { token = tokenString, BookBank = merchant.BookBank, RefreshToken = tokenDto.RefreshToken, Name = merchant.Name });
            }
            return response;
        }
        [HttpPost("adminlogin")]
        public IActionResult AdminLogin([FromBody] AdminLoginModel adminLogin)
        {
            IActionResult response = Unauthorized();
            AdminLoginDto loginDto = new AdminLoginDto()
            {
                UserName = adminLogin.UserName,
                Password = adminLogin.Password
            };
            var admin = _adminRepository.GetAdminByUserName(loginDto.UserName);
            var userDetail = _authService.GetAdminLoginDto(adminLogin.UserName);
            if (userDetail == null)
            {
                return response;
            }
            var user = _authService.AuthenticateAdmin(loginDto);
            if (user != null)
            {
                var tokenString = _authService.GenerateJSONWebToken();
                var RefreshToken = _authService.GenRefreshToken();
                AdminTokenDto tokenDto = new AdminTokenDto()
                {
                    RefreshToken = RefreshToken,
                    AdminId = userDetail.AdminId
                };
                _authService.SaveRefreshTokenAdmin(tokenDto);
                response = Ok(new { token = tokenString, BookBank = admin.BookBank, RefreshToken = tokenDto.RefreshToken, Name = admin.Name, AdminId = admin.AdminId });
            }
            return response;
        }
    }
}

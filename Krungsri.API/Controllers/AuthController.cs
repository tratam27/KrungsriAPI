using Krungsri.API.Models;
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
        public AuthController(IAuthService authService)
        {
            _authService = authService;
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
                PhoneNumber = userRegister.PhoneNumber
            };
            if (_authService.Register(user))
            {
                return new OkResult();
            }
            else
            {
                return new BadRequestResult();
            }
        }
        [HttpPost("sendotp")]
        public IActionResult SendOtp(SendOtpModel sendOtp)
        {
            _authService.SendOtpEmail(sendOtp.Email);
            return new OkResult();
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
            response = Ok(new { token = tokenString });
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
    }
}

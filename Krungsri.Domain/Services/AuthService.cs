using Krungsri.DataAccess.Interfaces;
using Krungsri.DataAccess.Models;
using Krungsri.Domain.Interfaces;
using Krungsri.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace Krungsri.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;
        private readonly ITokenRepository _tokenRepository;
        private readonly IOtpRepository _otpRepository;
        private readonly IMerchantRepository _merchantRepository;
        private readonly IMerchantTokenRepository _merchantTokenRepository;
        private readonly IAdminRepository _adminRepository;
        private readonly IAdminTokenRepository _adminTokenRepository;
        public AuthService(IUserRepository userRepository, IConfiguration configuration, ITokenRepository tokenRepository, IOtpRepository otpRepository, IMerchantRepository merchantRepository, IMerchantTokenRepository merchantTokenRepository, IAdminRepository adminRepository, IAdminTokenRepository adminTokenRepository)
        {
            _userRepository = userRepository;
            _config = configuration;
            _tokenRepository = tokenRepository;
            _otpRepository = otpRepository;
            _merchantRepository = merchantRepository;
            _merchantTokenRepository = merchantTokenRepository;
            _adminRepository = adminRepository;
            _adminTokenRepository = adminTokenRepository;
        }
        public UserLoginDto AuthenticateUser(UserLoginDto login)
        {
            try
            {
                UserLoginDto user = null;
                var getUser = _userRepository.GetUserByEmail(login.Email);                
                var hashedPassword = HashPassword(login.Password, getUser.Salt);
                if (login.Email == getUser.Email && hashedPassword == getUser.Password)
                {
                    user = new UserLoginDto { Email = getUser.Email, Password = hashedPassword };
                }
                return user;
            }
            catch
            {
                return null;
            }
        }
        public MerchantLoginDto AuthenticateMerchant(MerchantLoginDto login)
        {
            try
            {
                MerchantLoginDto user = null;
                var getUser = _merchantRepository.GetMerchantByUserName(login.UserName);
                var hashedPassword = HashPassword(login.Password, getUser.Salt);
                if (login.UserName == getUser.UserName && hashedPassword == getUser.Password)
                {
                    user = new MerchantLoginDto { UserName = getUser.UserName, Password = hashedPassword };
                }
                return user;
            }
            catch
            {
                return null;
            }
        }
        public AdminLoginDto AuthenticateAdmin(AdminLoginDto login)
        {
            try
            {
                AdminLoginDto user = null;
                var getUser = _adminRepository.GetAdminByUserName(login.UserName);
                var hashedPassword = HashPassword(login.Password, getUser.Salt);
                if (login.UserName == getUser.UserName && hashedPassword == getUser.Password)
                {
                    user = new AdminLoginDto { UserName = getUser.UserName, Password = hashedPassword };
                }
                return user;
            }
            catch
            {
                return null;
            }
        }
        public UserAccess Register(UserDto user)
        {
            if (!IsValidEmail(user.Email))
            {
                return null;
            }
            var checkuser = _userRepository.GetUserByEmail(user.Email);
            if(checkuser != null)
            {
                return null;
            }

            var salt = GenerateSalt();
            string[] birth = user.Birthdate.Split("/");
            var convertDate = new DateTime(Int32.Parse(birth[2]), Int32.Parse(birth[1]), Int32.Parse(birth[0]));

            UserAccess userDb = new UserAccess()
            {
                Balance = user.Balance,
                Birthdate = convertDate,
                Email = user.Email,
                BookBank = user.BookBank,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                Salt = salt,
                Password = HashPassword(user.Pin, salt),                
                PhoneNumber = user.PhoneNumber,                
            };
            _userRepository.Create(userDb);
            var getuser = _userRepository.GetUserByEmail(userDb.Email);
            return getuser;
        }
        public string GenerateBookBank()
        {
            var char1 = "1234567890";
            var BookBank = new char[10];
            var random = new Random();
            for (int i = 0; i < BookBank.Length; i++)
            {
                BookBank[i] = char1[random.Next(char1.Length)];
            }
            var stringBB = new String(BookBank);
            var insertone = stringBB.Insert(3, "-");
            var BookBankForm = insertone.Insert(10, "-");
            return BookBankForm;
        }
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public string GenerateOTP()
        {
            var char1 = "1234567890";
            var OTP = new char[6];
            var random = new Random();
            for (int i = 0; i < OTP.Length; i++)
            {
                OTP[i] = char1[random.Next(char1.Length)];
            }
            var stringOTP = new String(OTP);
            return stringOTP;
        }
        public OtpAccess SendOtpEmail(string email)
        {
            var Otp = GenerateOTP();
            var Ref = GenerateSixReference();
            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress("622707130005@dpu.ac.th");
            mail.Subject = "Verify Account(SocialApp)";
            mail.Body = "Use this OTP code to verify account in SocialApp : " + Otp + " With Reference No. "+Ref;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("622707130005@dpu.ac.th", "1103701732814");
            smtp.Send(mail);
            OtpAccess otpAccess = new OtpAccess
            {
                Email = email,
                Otp = Otp,
                Ref = Ref
            };
            _otpRepository.Create(otpAccess);
            return otpAccess;
        }
        public bool CheckOtp(string email, string otp)
        {            
                var detail = _otpRepository.GetOtpByEmail(email);
                if( detail == null)
                {
                    return false;
                }
                if (otp == detail.Otp)
                {
                    return true;
                }
                else
                {
                    return false;
                }            
        }
        public bool CheckExpireOtp(string email)
        {            
            var otpdetail = _otpRepository.GetOtpByEmail(email);
            if (otpdetail.CreateDateTime.AddMinutes(15) < DateTime.UtcNow.AddHours(7))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string HashPassword(string password, string salt)
        {
            var pass_salt = password + salt;
            byte[] bytes = Encoding.Unicode.GetBytes(pass_salt);
            SHA256Managed hashObj = new SHA256Managed();
            byte[] byteHash = hashObj.ComputeHash(bytes);
            string hashSt = "";
            foreach (byte cha in byteHash)
            {
                hashSt = hashSt + String.Format("{0:x2}", cha);
            }
            return hashSt;
        }
        public string GenerateSalt()
        {
            RNGCryptoServiceProvider rncCsp = new RNGCryptoServiceProvider();
            byte[] salt = new byte[100];
            rncCsp.GetBytes(salt);
            string saltSt = "";
            foreach (byte cha in salt)
            {
                saltSt = saltSt + String.Format("{0:x2}", cha);
            }
            return saltSt;
        }
        public string GenRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        public string GenerateSixReference()
        {
            var chars1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            var charcon1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var charcon2 = "abcdefghijklmnopqrstuvwxyz";
            var charcon3 = "1234567890";
            var stringChars1 = new char[6];
            bool condition1;
            bool condition2;
            bool condition3;
            var random = new Random();
            do
            {
                condition1 = false;
                condition2 = false;
                condition3 = false;
                for (int i = 0; i < stringChars1.Length; i++)
                {
                    stringChars1[i] = chars1[random.Next(chars1.Length)];
                    foreach (var cha in charcon1)
                    {
                        if (stringChars1[i] == cha)
                        {
                            condition1 = true;
                        }
                    }
                    foreach (var cha in charcon2)
                    {
                        if (stringChars1[i] == cha)
                        {
                            condition2 = true;
                        }
                    }
                    foreach (var cha in charcon3)
                    {
                        if (stringChars1[i] == cha)
                        {
                            condition3 = true;
                        }
                    }
                }
            } while (condition1 != true || condition2 != true || condition3 != true);
            var str = new String(stringChars1);
            return str;
        }

        public string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(5),
              signingCredentials: credentials);
        
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string SaveRefreshToken(TokenDto tokenDto)
        {
            TokenAccess tokenAccess = new TokenAccess()
            {
                UserId = tokenDto.UserId,
                RefreshToken = tokenDto.RefreshToken
            };
            var checkuser = _tokenRepository.GetRefreshByUserId(tokenDto.UserId);
            if (checkuser == null)
            {
                _tokenRepository.Create(tokenAccess);
            }
            else
            {
                _tokenRepository.Update(tokenAccess);
            }
            return tokenDto.RefreshToken;
        }
        public string SaveRefreshTokenMerchant(MerchantTokenDto merchantToken)
        {
            MerchantTokenAccess tokenAccess = new MerchantTokenAccess()
            {
                MerchantId = merchantToken.MerchantId,
                RefreshToken = merchantToken.RefreshToken
            };
            var checkuser = _merchantTokenRepository.GetMerchantTokenById(merchantToken.MerchantId);
            if (checkuser == null)
            {
                _merchantTokenRepository.Create(tokenAccess);
            }
            else
            {
                _merchantTokenRepository.Update(tokenAccess);
            }
            return merchantToken.RefreshToken;
        }
        public string SaveRefreshTokenAdmin(AdminTokenDto adminToken)
        {
            AdminTokenAccess tokenAccess = new AdminTokenAccess()
            {
                AdminId = adminToken.AdminId,
                RefreshToken = adminToken.RefreshToken
            };
            var checkuser = _adminTokenRepository.GetAdminTokenById(adminToken.AdminId);
            if (checkuser == null)
            {
                _adminTokenRepository.Create(tokenAccess);
            }
            else
            {
                _adminTokenRepository.Update(tokenAccess);
            }
            return adminToken.RefreshToken;
        }
        public UserLoginDto GetUserLoginDto(string email)
        {
            var accessuser = _userRepository.GetUserByEmail(email);
            if (accessuser == null)
            {
                return null;
            }
            UserLoginDto user = new UserLoginDto()
            {                
                Email = accessuser.Email,
                UserId = accessuser.UserId
            };
            return user;
        }
        public MerchantLoginDto GetMerchantLoginDto(string username)
        {
            var accessuser = _merchantRepository.GetMerchantByUserName(username);
            if (accessuser == null)
            {
                return null;
            }
            MerchantLoginDto user = new MerchantLoginDto()
            {
                UserName = accessuser.UserName,
                MerchantId = accessuser.MerchantId,
            };
            return user;
        }
        public AdminLoginDto GetAdminLoginDto(string username)
        {
            var accessuser = _adminRepository.GetAdminByUserName(username);
            if (accessuser == null)
            {
                return null;
            }
            AdminLoginDto user = new AdminLoginDto()
            {
                UserName = accessuser.UserName,
                AdminId = accessuser.AdminId,
            };
            return user;
        }

        public string GetTokenByRefreshToken(string refreshToken)
        {
            //check refresh token 
            TokenAccess rt = _tokenRepository.FindRefreshToken(refreshToken);
            var expiredDate = rt.CreateDateTime.AddYears(1);
            if (rt != null && expiredDate.CompareTo(DateTime.Now) > 0)
            {
                string token = GenerateJSONWebToken();
                return token;
            }
            else
            {
                return null;
            }
        }
    }
}

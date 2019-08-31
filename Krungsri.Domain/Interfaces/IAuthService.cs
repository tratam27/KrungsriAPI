using Krungsri.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.Domain.Interfaces
{
    public interface IAuthService
    {
        UserLoginDto AuthenticateUser(UserLoginDto login);
        bool Register(UserDto user);
        string GenerateBookBank();
        bool IsValidEmail(string email);
        string GenerateOTP();
        string SendOtpEmail(string email);
        string HashPassword(string password, string salt);
        string GenerateSalt();
        string GenerateSixReference();
        bool CheckExpireOtp(string email);
        bool CheckOtp(string email, string otp);
        UserLoginDto GetUserLoginDto(string email);
        string GenerateJSONWebToken();
        string GenRefreshToken();
        string SaveRefreshToken(TokenDto tokenDto);
        string GetTokenByRefreshToken(string refreshToken);
    }
}

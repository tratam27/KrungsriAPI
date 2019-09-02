using Krungsri.DataAccess.Models;
using Krungsri.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.Domain.Interfaces
{
    public interface IAuthService
    {
        UserLoginDto AuthenticateUser(UserLoginDto login);
        UserAccess Register(UserDto user);
        string GenerateBookBank();
        bool IsValidEmail(string email);
        string GenerateOTP();
        OtpAccess SendOtpEmail(string email);
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
        MerchantLoginDto AuthenticateMerchant(MerchantLoginDto login);
        MerchantLoginDto GetMerchantLoginDto(string username);
        string SaveRefreshTokenMerchant(MerchantTokenDto merchantToken);
        AdminLoginDto GetAdminLoginDto(string username);
        string SaveRefreshTokenAdmin(AdminTokenDto adminToken);
        AdminLoginDto AuthenticateAdmin(AdminLoginDto login);
    }
}

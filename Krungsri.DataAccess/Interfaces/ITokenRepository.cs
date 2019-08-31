using Krungsri.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Interfaces
{
    public interface ITokenRepository
    {
        void Create(TokenAccess user);
        TokenAccess Get();
        void Update(TokenAccess user);
        void Delete(TokenAccess user);
        TokenAccess GetRefreshByUserId(int id);
        TokenAccess FindRefreshToken(string refreshToken);        

    }
}

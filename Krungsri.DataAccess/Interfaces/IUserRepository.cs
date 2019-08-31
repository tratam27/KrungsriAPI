using Krungsri.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        void Create(UserAccess user);
        UserAccess Get();
        void Update(UserAccess user);
        void Delete(UserAccess user);
        UserAccess GetUserByEmail(string email);
        UserAccess GetUserById(int id);
    }
}

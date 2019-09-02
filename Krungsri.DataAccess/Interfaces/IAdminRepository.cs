using Krungsri.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Interfaces
{
    public interface IAdminRepository
    {
        void Create(AdminAccess user);
        AdminAccess Get();
        void Update(AdminAccess user);
        void Delete(AdminAccess user);
        AdminAccess GetAdminById(int id);
        AdminAccess GetAdminByUserName(string username);
    }
}

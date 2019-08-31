using Krungsri.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Interfaces
{
    public interface IAdminTokenRepository
    {
        void Create(AdminTokenAccess user);
        AdminTokenAccess Get();
        void Update(AdminTokenAccess user);
        void Delete(AdminTokenAccess user);
        AdminTokenAccess GetAdminTokenById(int id);
    }
}

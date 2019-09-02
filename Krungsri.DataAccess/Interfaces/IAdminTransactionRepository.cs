using Krungsri.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Interfaces
{
    public interface IAdminTransactionRepository
    {
        void Create(AdminTransactionAccess user);
        AdminTransactionAccess Get();
        void Update(AdminTransactionAccess user);
        void Delete(AdminTransactionAccess user);
        AdminTransactionAccess GetAdminTransactionById(int id);
        List<AdminTransactionAccess> GetAdminsMonthly(int adminId);
        AdminTransactionAccess GetAdminTransactionByRef(string reference);
    }
}

using Krungsri.DataAccess.Models;
using Krungsri.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.Domain.Interfaces
{
    public interface IAdminTransactionService
    {
        string BookBankToQr(int id);
        void AddTransactionToHistory(AdminTranDto tranDto);
        List<AdminTransactionAccess> ShowMonthlyTrans(int adminId);
        void AddTransactionBeforeScan(AdminTranDto adminTran);
        AdminTranExpireDate GetAdminTransaction(string reference);
        decimal UpdateUserBalance(AdminUpdateUserIdAndBalanceDto userIdAndBalanceDto);
        void UpdateUserId(AdminUpdateUserIdAndBalanceDto userIdAndBalanceDto);
    }
}

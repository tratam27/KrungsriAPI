using Krungsri.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.Domain.Interfaces
{
    public interface IMerchantTransactionService 
    {
        string BookBankToQr(int id);
        void AddTransactionToHistory(MerchantTranDto tranDto);
        void ShowMonthlyTrans();
    }
}

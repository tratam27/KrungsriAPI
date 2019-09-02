using Krungsri.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Interfaces
{
    public interface IMerchantTransactionRepository
    {
        void Create(MerchantTransactionAccess user);
        MerchantTransactionAccess Get();
        void Update(MerchantTransactionAccess user);
        void Delete(MerchantTransactionAccess user);
        MerchantTransactionAccess GetMerchantTransactionById(int id);
        List<MerchantTransactionAccess> GetMerchantsMonthly();
    }
}

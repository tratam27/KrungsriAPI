using Krungsri.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Interfaces
{
    public interface IMerchantRepository
    {
        void Create(MerchantAccess user);
        MerchantAccess Get();
        void Update(MerchantAccess user);
        void Delete(MerchantAccess user);
        MerchantAccess GetMerchantById(int id);
    }
}

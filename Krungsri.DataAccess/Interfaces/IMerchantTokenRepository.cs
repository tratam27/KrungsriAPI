using Krungsri.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Interfaces
{
    public interface IMerchantTokenRepository
    {
        void Create(MerchantTokenAccess user);
        MerchantTokenAccess Get();
        void Update(MerchantTokenAccess user);
        void Delete(MerchantTokenAccess user);
        MerchantTokenAccess GetMerchantTokenById(int id);
    }
}

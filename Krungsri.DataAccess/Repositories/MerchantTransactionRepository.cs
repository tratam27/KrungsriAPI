using Krungsri.DataAccess.Context;
using Krungsri.DataAccess.Interfaces;
using Krungsri.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Krungsri.DataAccess.Repositories
{
    public class MerchantTransactionRepository : IMerchantTransactionRepository
    {
        private readonly KrungsriContext _context;
        public MerchantTransactionRepository(KrungsriContext context)
        {
            _context = context;
        }

        public void Create(MerchantTransactionAccess user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void Delete(MerchantTransactionAccess user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }

        public MerchantTransactionAccess Get()
        {
            return _context.merchantTransactions.Find();
        }

        public void Update(MerchantTransactionAccess user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        public MerchantTransactionAccess GetMerchantTransactionById(int id)
        {
            return _context.merchantTransactions.FirstOrDefault(x=>x.Id == id);
        }
        public List<MerchantTransactionAccess> GetMerchantsMonthly()
        {            
            return _context.merchantTransactions.Where(x => x.CreateDateTime > DateTime.Now.AddDays(-30) && x.CreateDateTime <= DateTime.Now).ToList();
        }
    }
}

using Krungsri.DataAccess.Context;
using Krungsri.DataAccess.Interfaces;
using Krungsri.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Krungsri.DataAccess.Repositories
{
    public class MerchantRepository : IMerchantRepository
    {
        private readonly KrungsriContext _context;
        public MerchantRepository(KrungsriContext context)
        {
            _context = context;
        }

        public void Create(MerchantAccess user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void Delete(MerchantAccess user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }

        public MerchantAccess Get()
        {
            return _context.merchants.Find();
        }

        public MerchantAccess GetMerchantById(int id)
        {
            return _context.merchants.FirstOrDefault(x => x.MerchantId == id);
        }
        public void Update(MerchantAccess user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
        public MerchantAccess GetMerchantByUserName(string username)
        {
            return _context.merchants.FirstOrDefault(x => x.UserName == username);
        }
    }
}

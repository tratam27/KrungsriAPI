using Krungsri.DataAccess.Context;
using Krungsri.DataAccess.Interfaces;
using Krungsri.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Krungsri.DataAccess.Repositories
{
    public class MerchantTokenRepository : IMerchantTokenRepository
    {
        private readonly KrungsriContext _context;
        public MerchantTokenRepository(KrungsriContext context)
        {
            _context = context;
        }

        public void Create(MerchantTokenAccess user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void Delete(MerchantTokenAccess user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }

        public MerchantTokenAccess Get()
        {
            return _context.merchantTokens.Find();
        }

        public MerchantTokenAccess GetMerchantTokenById(int id)
        {
            return _context.merchantTokens.FirstOrDefault(x => x.Id == id);
        }

        public void Update(MerchantTokenAccess user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}

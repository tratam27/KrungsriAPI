using Krungsri.DataAccess.Context;
using Krungsri.DataAccess.Interfaces;
using Krungsri.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Krungsri.DataAccess.Repositories
{
    public class AdminTransactionRepository : IAdminTransactionRepository
    {
        private readonly KrungsriContext _context;
        public AdminTransactionRepository(KrungsriContext context)
        {
            _context = context;
        }

        public void Create(AdminTransactionAccess user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void Delete(AdminTransactionAccess user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }

        public AdminTransactionAccess Get()
        {
            return _context.adminTransactions.Find();
        }

        public AdminTransactionAccess GetAdminTransactionById(int id)
        {
            return _context.adminTransactions.FirstOrDefault(x=>x.Id == id);
        }

        public void Update(AdminTransactionAccess user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}

using Krungsri.DataAccess.Context;
using Krungsri.DataAccess.Interfaces;
using Krungsri.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Krungsri.DataAccess.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly KrungsriContext _context;
        public AdminRepository(KrungsriContext context)
        {
            _context = context;
        }

        public void Create(AdminAccess user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void Delete(AdminAccess user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }

        public AdminAccess Get()
        {
            return _context.admins.Find();
        }

        public void Update(AdminAccess user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
        public AdminAccess GetAdminById(int id)
        {
            return _context.admins.FirstOrDefault(x=>x.AdminId == id);
        }
    }
}

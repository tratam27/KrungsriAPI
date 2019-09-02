using Krungsri.DataAccess.Context;
using Krungsri.DataAccess.Interfaces;
using Krungsri.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Krungsri.DataAccess.Repositories
{
    public class AdminTokenRepository : IAdminTokenRepository
    {
        private readonly KrungsriContext _context;
        public AdminTokenRepository(KrungsriContext context)
        {
            _context = context;
        }
        public void Create(AdminTokenAccess user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }
        public void Delete(AdminTokenAccess user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }
        public AdminTokenAccess Get()
        {
            return _context.adminTokens.Find();
        }
        public AdminTokenAccess GetAdminTokenById(int id)
        {
            return _context.adminTokens.FirstOrDefault(x => x.AdminId == id);
        }
        public void Update(AdminTokenAccess user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}

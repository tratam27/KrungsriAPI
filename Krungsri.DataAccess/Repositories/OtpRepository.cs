using Krungsri.DataAccess.Context;
using Krungsri.DataAccess.Interfaces;
using Krungsri.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Krungsri.DataAccess.Repositories
{
    public class OtpRepository : IOtpRepository
    {
        private readonly KrungsriContext _context;
        public OtpRepository(KrungsriContext context)
        {
            _context = context;
        }

        public void Create(OtpAccess user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void Delete(OtpAccess user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }
        public OtpAccess Get()
        {
            return _context.oTPs.Find();
        }

        public OtpAccess GetOtpByEmail(string email)
        {
            return _context.oTPs.LastOrDefault(x => x.Email == email);
        }

        public OtpAccess GetOtpById(int id)
        {
            return _context.oTPs.FirstOrDefault(x=>x.Id == id);
        }

        public void Update(OtpAccess user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}

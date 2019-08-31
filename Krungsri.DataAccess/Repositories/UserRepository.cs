using Krungsri.DataAccess.Context;
using Krungsri.DataAccess.Interfaces;
using Krungsri.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Krungsri.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly KrungsriContext _context;
        public UserRepository(KrungsriContext context)
        {
            _context = context;
        }

        public void Create(UserAccess user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void Delete(UserAccess user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }

        public UserAccess Get()
        {
            return _context.users.Find();
        }

        public void Update(UserAccess user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
        public UserAccess GetUserByEmail(string email)
        {
            return _context.users.FirstOrDefault(x => x.Email == email);
        }
        public UserAccess GetUserById(int id)
        {
            return _context.users.FirstOrDefault(x => x.UserId == id);
        }
    }
}

using Krungsri.DataAccess.Context;
using Krungsri.DataAccess.Interfaces;
using Krungsri.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Krungsri.DataAccess.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly KrungsriContext _context;
        public TokenRepository(KrungsriContext context)
        {
            _context = context;
        }

        public TokenAccess FindRefreshToken(string refreshToken)
        {
            return _context.tokens.FirstOrDefault(x => x.RefreshToken == refreshToken);
        }

        public void Create(TokenAccess user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void Delete(TokenAccess user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }

        public TokenAccess Get()
        {
            return _context.tokens.Find();
        }

        public TokenAccess GetRefreshByUserId(int id)
        {
            return _context.tokens.FirstOrDefault(x => x.Id == id);
        }

        public void Update(TokenAccess user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        public TokenAccess CheckRefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}

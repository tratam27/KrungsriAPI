using Krungsri.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Interfaces
{
    public interface IOtpRepository
    {
        void Create(OtpAccess user);
        OtpAccess Get();
        void Update(OtpAccess user);
        void Delete(OtpAccess user);
        OtpAccess GetOtpById(int id);
        OtpAccess GetOtpByEmail(string email);
    }
}


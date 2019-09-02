using Krungsri.DataAccess.Interfaces;
using Krungsri.DataAccess.Models;
using Krungsri.Domain.Interfaces;
using Krungsri.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.Domain.Services
{
    public class AdminTransactionService : IAdminTransactionService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IAdminTransactionRepository _adminTransactionRepository;
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public AdminTransactionService(IAdminRepository adminRepository, IAdminTransactionRepository adminTransactionRepository, IAuthService authService,IUserRepository userRepository)
        {
            _adminRepository = adminRepository;
            _adminTransactionRepository = adminTransactionRepository;
            _authService = authService;
            _userRepository = userRepository;
        }
        public string BookBankToQr(int id)
        {
            var Admin = _adminRepository.GetAdminById(id);
            var book = Admin.BookBank;
            return book;
        }
        public void AddTransactionToHistory(AdminTranDto tranDto)
        {
            AdminTransactionAccess transactionAccess = new AdminTransactionAccess
            {
                MoneyAmount = decimal.Parse(tranDto.MoneyAmount),
                Ref = _authService.GenerateSixReference(),
                AdminId = tranDto.AdminId,
                UserId = tranDto.UserId
            };
            _adminTransactionRepository.Create(transactionAccess);
        }
        public List<AdminTransactionAccess> ShowMonthlyTrans(int adminId)
        {
            var trans = _adminTransactionRepository.GetAdminsMonthly(adminId);
            return trans;
        }
        public void AddTransactionBeforeScan(AdminTranDto adminTran)
        {
            AdminTransactionAccess adminTransaction = new AdminTransactionAccess
            {
                MoneyAmount = decimal.Parse(adminTran.MoneyAmount),
                Ref = adminTran.Ref,
                AdminId = adminTran.AdminId,                
            };
            _adminTransactionRepository.Create(adminTransaction);
        }
        public AdminTranExpireDate GetAdminTransaction(string reference)
        {
            var admintran = _adminTransactionRepository.GetAdminTransactionByRef(reference);
            AdminTranExpireDate expireDate = new AdminTranExpireDate
            {
                AdminId = admintran.AdminId,
                MoneyAmount = admintran.MoneyAmount.ToString(),
                ExpiryDate = admintran.CreateDateTime.AddMinutes(15).ToString(),
                Ref = admintran.Ref
            };
            return expireDate;
        }
        public void UpdateUserId(AdminUpdateUserIdAndBalanceDto userIdAndBalanceDto)
        {
            var tran = _adminTransactionRepository.GetAdminTransactionByRef(userIdAndBalanceDto.Ref);
            tran.UserId = userIdAndBalanceDto.UserId;
            _adminTransactionRepository.Update(tran);
        }
        public decimal UpdateUserBalance(AdminUpdateUserIdAndBalanceDto userIdAndBalanceDto)
        {
            var user = _userRepository.GetUserById(userIdAndBalanceDto.UserId);
            user.Balance = user.Balance + userIdAndBalanceDto.TopUpMoney;
            _userRepository.Update(user);
            return user.Balance;
        }
    }
}

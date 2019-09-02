using Krungsri.DataAccess.Interfaces;
using Krungsri.DataAccess.Models;
using Krungsri.Domain.Interfaces;
using Krungsri.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.Domain.Services
{
    public class MerchantTransactionService : IMerchantTransactionService
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly IMerchantTransactionRepository _merchantTransactionRepository;
        private readonly IAuthService _authService;
        public MerchantTransactionService(IMerchantRepository merchantRepository,IMerchantTransactionRepository merchantTransactionRepository, IAuthService authService)
        {
            _merchantRepository = merchantRepository;
            _merchantTransactionRepository = merchantTransactionRepository;
            _authService = authService;
        }
        public string BookBankToQr(int id)
        {
            var merchant = _merchantRepository.GetMerchantById(id);
            var book = merchant.BookBank;
            return book;
        }
        public void AddTransactionToHistory(MerchantTranDto tranDto)
        {
            MerchantTransactionAccess transactionAccess = new MerchantTransactionAccess
            {
                MoneyAmount = tranDto.MoneyAmount,
                Ref = _authService.GenerateSixReference(),
                MerchantId = tranDto.MerchantId,
                UserId = tranDto.UserId                
            };
            _merchantTransactionRepository.Create(transactionAccess);
        }
        public void ShowMonthlyTrans()
        {
            _merchantTransactionRepository.GetMerchantsMonthly();
        }        
    }
}

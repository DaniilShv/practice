using BankApi.Domain;
using BankApi.Domain.DTOs;
using BankApi.Infrastructure.Interfaces;
using BankApi.Service.Interfaces;

namespace BankApi.Service
{
    public class BankCardService(IBankCardRepository _bankCardRepository) : IBankCardService
    {
        static Random rnd = new Random();
        public async Task CreateBankCardAsync(Guid bankRecordId, CancellationToken token)
        {
            var card = new BankCard
            {
                Date = DateTime.UtcNow,
                CardNumber = (ulong)rnd.NextInt64((long)Math.Pow(10,15), (long)Math.Pow(10, 16)),
                CvvCode = (ushort)rnd.Next(100, 1000),
                BankRecordId = bankRecordId
            };

            await _bankCardRepository.CreateBankCardAsync(card, token);
        }

        public async Task PayCardAsync(Guid cardId, decimal sum, string nameSeller, CancellationToken token)
        {
            var card = new PayCardDto
            {
                CardId = cardId,
                Sum = sum
            };

            var payment = new PaymentHistory
            {
                Name = nameSeller,
                Date = DateTime.UtcNow,
                Total = sum
            };

            await _bankCardRepository.PayCardAsync(card, payment, token);
        }
    }
}

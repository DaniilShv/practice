using BankApi.Domain;
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
                Id = bankRecordId,
                Date = DateTime.UtcNow,
                CardNumber = (ulong)rnd.NextInt64(10 * 16, 10 * 17),
                CvvCode = (ushort)rnd.Next(100, 1000),
                BankRecordId = bankRecordId
            };

            await _bankCardRepository.CreateBankCardAsync(card, token);
        }
        
    }
}

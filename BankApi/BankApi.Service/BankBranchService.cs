using BankApi.Domain;
using BankApi.Infrastructure.Interfaces;
using BankApi.Service.Interfaces;

namespace BankApi.Service
{
    public class BankBranchService(IBankBranchRepository _bankBranchRepository) : IBankBranchService
    {
        public async Task CreateBankBranchAsync(Guid locationId, string address, 
            CancellationToken token)
        {
            var bank = new BankBranch
            {
                LocationId = locationId,
                Adress = address
            };

            await _bankBranchRepository.CreateBankBranchAsync(bank, token);
        }
    }
}

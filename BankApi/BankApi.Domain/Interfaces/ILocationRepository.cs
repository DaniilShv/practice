using BankApi.Domain.Entities;

namespace BankApi.Domain.Interfaces
{
    public interface ILocationRepository : IRepository<Location>, IExcelRepository
    {

    }
}

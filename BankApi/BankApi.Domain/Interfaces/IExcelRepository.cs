using System.Data;

namespace BankApi.Domain.Interfaces
{
    public interface IExcelRepository
    {
        public DataTable GetDataTable();

        public string GetTableName();
    }
}

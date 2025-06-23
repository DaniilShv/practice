namespace BankApi.Domain.Entities
{
    public class Credit
    {
        /// <summary>
        /// ID кредита (Primary Key)
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
    }
}

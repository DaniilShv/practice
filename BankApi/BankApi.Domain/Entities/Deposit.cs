namespace BankApi.Domain.Entities
{
    public class Deposit
    {
        /// <summary>
        /// ID вклада (Primary Key)
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
    }
}

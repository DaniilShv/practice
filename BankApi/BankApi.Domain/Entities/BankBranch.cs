namespace BankApi.Domain.Entities
{
    public class BankBranch
    {
        /// <summary>
        /// ID банковского отделения (Primary key)
        /// </summary>
        public Guid Id { get; set; }

        public Location Location { get; set; }

        /// <summary>
        /// Местоположение(город) банковского отделения (Foreign Key)
        /// </summary>
        public Guid LocationId { get; set; }

        /// <summary>
        /// Адрес банковского отделения
        /// </summary>
        public string Adress { get; set; }
    }
}

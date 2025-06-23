namespace BankApi.Domain.DTOs
{
    public class BankBranchCreateDto
    {
        /// <summary>
        /// ID Местоположения банковского отделения
        /// </summary>
        public Guid LocationId { get; set; }

        /// <summary>
        /// Адрес банковского отделения
        /// </summary>
        public string Adress { get; set; }
    }
}

namespace BankApi.Domain.Entities
{
    public class Location
    {
        /// <summary>
        /// ID местоположения (Primary Key)
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название города
        /// </summary>
        public string Name { get; set; }
    }
}

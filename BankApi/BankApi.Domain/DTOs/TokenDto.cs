namespace BankApi.Domain.DTOs
{
    public class TokenDto
    {
        /// <summary>
        /// JWT токен клиента системы банка
        /// </summary>
        public string Token { get; set; }
        
        /// <summary>
        /// refresh токен клиента системы банка
        /// </summary>
        public string RefreshToken { get; set; }
    }
}

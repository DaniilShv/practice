namespace BankApi.Domain.DTOs
{
    public class LoginDto
    {
        /// <summary>
        /// Логин для входа в банковскую систему
        /// </summary>
        public string Login { get; set; }
        
        /// <summary>
        /// Пароль для входа в банковскую систему
        /// </summary>
        public string Password { get; set; }
    }
}

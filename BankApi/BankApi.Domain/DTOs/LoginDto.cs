namespace BankApi.Domain.DTOs
{
    public class LoginDto
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string RefreshToken { get; set; }
    }
}

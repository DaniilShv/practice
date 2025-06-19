using System.Security.Claims;

namespace BankApi.Service.Interfaces
{
    public interface ITokenService
    {
        /// <summary>
        /// Создает Jwt token
        /// </summary>
        /// <param name="claims">Дополнительная информация</param>
        /// <returns>Jwt token</returns>
        string GetToken(IEnumerable<Claim> claims);

        /// <summary>
        /// Создает refresh token
        /// </summary>
        /// <returns>Refresh token</returns>
        string GenerateRefreshToken();

        /// <summary>
        /// Получает информацию о клиенте из jwt token 
        /// </summary>
        /// <param name="token">Jwt token</param>
        /// <returns>Информация из токена</returns>
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}

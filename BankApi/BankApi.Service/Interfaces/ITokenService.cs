using System.Security.Claims;

namespace BankApi.Service.Interfaces
{
    public interface ITokenService
    {
        string GetToken(IEnumerable<Claim> claims);

        string GenerateRefreshToken();

        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}

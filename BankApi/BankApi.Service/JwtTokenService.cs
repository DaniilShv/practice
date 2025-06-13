using BankApi.Service.Interfaces;
using BankApi.Service.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BankApi.Service
{
    public class JwtTokenService : ITokenService
    {
        private readonly IOptions<JwtSettings> _options;

        private readonly TokenValidationParameters _tokenValidation;

        public JwtTokenService(IOptions<JwtSettings> options)
        {
            _options = options;
            _tokenValidation = new TokenValidationParameters
            {
                ValidateIssuer = _options.Value.ValidateIssuer,
                ValidateAudience = _options.Value.ValidateAudience,
                ValidateLifetime = _options.Value.ValidateLifetime,
                ValidateIssuerSigningKey = _options.Value.ValidateIssuerSigningKey,
                ValidIssuer = _options.Value.Issuer,
                ValidAudience = _options.Value.Audience,
                IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.SecretKey))
            };
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using var rng = RandomNumberGenerator.Create();

            rng.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = tokenHandler.ValidateToken(token, _tokenValidation,
                out SecurityToken securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null ||
                !jwtSecurityToken.Header.Alg
                .Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return claims;
        }

        public string GetToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.SecretKey));

            var token = new JwtSecurityToken(
                issuer: _options.Value.Issuer,
                audience: _options.Value.Audience,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(_options.Value.TokenLifetime)),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256),
                claims: claims
                );

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}

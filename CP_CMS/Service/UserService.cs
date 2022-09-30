using Ecommerces_MS.helpers;
using Ecommerces_MS.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommerces_MS.Service
{
    public class UserService : IUserService
    {
        private readonly helperAppSettings _appSettings;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IConfiguration _configuration;
        public UserService(IHttpContextAccessor httpContextAccessor, IOptions<helperAppSettings> appSettings, IConfiguration configuration)
        {
            _appSettings = appSettings.Value;
            this.httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }
        public SecurityTokenModel GenerateToken(string username, string password , int RoleId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings").GetSection("Secret").Value);
            var sk = new SymmetricSecurityKey(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "http://ScoriaIT/mainsubsys",
                Audience = "http://ScoriaIT/subsys",
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, $"{username}"),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToUniversalTime().ToString(),
                    ClaimValueTypes.Integer64),
                    new Claim("accountnumber", username),
                    new Claim("currency", "$"),
                    new Claim("name", username),
                    new Claim(ClaimTypes.NameIdentifier, username)
                    }),
                Expires = DateTime.Now.AddMinutes(60),

                SigningCredentials = new SigningCredentials(sk, SecurityAlgorithms.HmacSha256Signature)
            };




            var token = tokenHandler.CreateToken(tokenDescriptor);


            var jwtSecurityToken = tokenHandler.WriteToken(token);


            //var jwtSecurityToken =new JwtSecurityTokenHandler().WriteToken(token)            
            // jwtSecurityToken. token.ValidTo;

            return new Models.SecurityTokenModel() { auth_token = jwtSecurityToken };
        }
    }
}

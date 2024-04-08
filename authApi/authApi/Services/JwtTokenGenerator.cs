using authApi.Models;
using authApi.Services.IServices;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace authApi.Services
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtOptions jwtOptions;

        public JwtTokenGenerator(IOptions<JwtOptions> jwtOptions)
        {
            this.jwtOptions = jwtOptions.Value;
        }
        

        public string GenerateToken(ApplicationUser applicationUser)
         {
             var tokenHandler = new JwtSecurityTokenHandler();

             var key = Encoding.ASCII.GetBytes(jwtOptions.Secret);

             var claimList = new List<Claim>
             {
                 new Claim(JwtRegisteredClaimNames.Sub,applicationUser.Id),
                 new Claim(JwtRegisteredClaimNames.Name,applicationUser.UserName.ToString()),
                 new Claim("role","USER"),
                 //new Claim("role",roles.FirstOrDefault(r_id => r_id.Id == applicationUser.Roleid)!.Name),

             };

             //szerepkör hozzáadása a tokenhez
             //claimList.AddRange(roles.Select(role=> new Claim(ClaimTypes.Role,role)));

             var rokenDescription = new SecurityTokenDescriptor
             {
                 Audience = jwtOptions.Audience,
                 Issuer = jwtOptions.Issuer,
                 Subject = new ClaimsIdentity(claimList),
                 Expires = DateTime.Now.AddDays(1),
                 SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
             };

             var token = tokenHandler.CreateToken(rokenDescription);

             return tokenHandler.WriteToken(token);
         }
        
    }
}

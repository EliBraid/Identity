

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWPConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JWTadd();
        }

        public static void JWTadd()
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, "6"));
            claims.Add(new Claim(ClaimTypes.Name, "小王八"));
            claims.Add(new Claim("Passport", "123456"));
            claims.Add(new Claim("QQ", "12789456"));
            claims.Add(new Claim(ClaimTypes.HomePhone, "13105254441"));
            claims.Add(new Claim(ClaimTypes.Role, "asdmin"));

            string key = "SUAHND-ADWADS-DAWDASDW";

            var expire = DateTime.Now.AddHours(1);

            byte[] setBytes = Encoding.UTF8.GetBytes(key);

            var secKey = new SymmetricSecurityKey(setBytes);
            var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(claims: claims, expires: expire, signingCredentials: credentials);

            string jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            Console.WriteLine(jwt);
        }
    }
}
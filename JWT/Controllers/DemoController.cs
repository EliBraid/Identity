using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IOptionsSnapshot<JWTSettings> jwtsettingOpt;

        public DemoController(IOptionsSnapshot<JWTSettings> jwtsettingOpt)
        {
            this.jwtsettingOpt = jwtsettingOpt;
        }

        [HttpPost]
        public ActionResult<string> Login(string username,string password)
        {
            if(username=="wyc" &&password == "123456")
            {
                List<Claim> claims= new List<Claim>();

                claims.Add(new Claim(ClaimTypes.NameIdentifier,"1"));
                claims.Add(new Claim(ClaimTypes.Name, username));

                string key = jwtsettingOpt.Value.SecKey;
                var exprie = DateTime.Now.AddSeconds(jwtsettingOpt.Value.ExpireSeconds);

                byte[] secBytes = Encoding.UTF8.GetBytes(key);

                var secKey = new SymmetricSecurityKey(secBytes);
                var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256Signature);

                var token = new JwtSecurityToken(claims: claims,expires: exprie,signingCredentials:credentials);

                string jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;
            }
            else
            {
                return BadRequest("验证失败");
            }

        }
    }
}

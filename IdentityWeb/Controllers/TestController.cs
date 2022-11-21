using IdentityWeb.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityWeb.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly UserManager<MyUser> userManager;
        private readonly RoleManager<MyRole> roleManager;

        public TestController(RoleManager<MyRole> roleManager, UserManager<MyUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        [HttpPost]
        public async Task<ActionResult<string>> Test1()
        {
            var roleExists = await roleManager.RoleExistsAsync("admin");
            if(!roleExists)
            {
                MyRole role = new MyRole()
                {
                    Name = "admin"
                };

                var result = await roleManager.CreateAsync(role);
                if (!result.Succeeded)
                {
                    return BadRequest("创建失败");
                }
            }
            var user = await userManager.FindByNameAsync("wyc");
            if(user == null)
            {
                user = new MyUser()
                {
                    UserName= "wyc",
                    Email="1632050253@qq.com",
                    EmailConfirmed=true,
                };
                var r = await userManager.CreateAsync(user, "123456");
                if (!r.Succeeded)
                {
                    return BadRequest("创建失败");
                }
            }
            if(!await userManager.IsInRoleAsync(user, "adimn"))
            {
                var result = await userManager.AddToRoleAsync(user, "admin");
                if (!result.Succeeded) return BadRequest("创建失败");
            }
            return Ok("ok");
            
        }
        [HttpPost]
        public async Task<ActionResult<string>> CheckPassword(CheckPwdRequest res)
        {
            string name = res.name;
            string pwd = res.password;
            
            var user =await userManager.FindByNameAsync(name);

            if (user == null )
            {
                return BadRequest("用户不存在");
            }
            if(await userManager.IsLockedOutAsync(user))
            {
                return BadRequest($"用户被锁定,锁定时间: {user.LockoutEnd}");
            }
            if(await userManager.CheckPasswordAsync(user, pwd))
            {
                await userManager.ResetAccessFailedCountAsync(user);
                return Ok("登录成功");
            }
            else
            {
                await  userManager.AccessFailedAsync(user);
                return BadRequest("用户名密码错误");
            }
        }

        [HttpPost]
        public async Task<ActionResult> SendResetPasswordToken(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                return BadRequest("用户不存在");

            }
           string token = await userManager.GeneratePasswordResetTokenAsync(user);

            Console.WriteLine(token);

            return Ok("ok");

        }
        [HttpPut]
        public async Task<ActionResult> ResetPassword(string name,string token,string newPassword)
        {
            var user = await userManager.FindByNameAsync(name);

            if(user == null)
            {
                return BadRequest("用户名不存在");
            }
            var result = await userManager.ResetPasswordAsync(user,token,newPassword);
            if (result.Succeeded)
            {
                await userManager.ResetAccessFailedCountAsync(user);

                return Ok("密码重置成功");
            }
            else
            {
                await userManager.AccessFailedAsync(user);
                return BadRequest("密码重置失败");
            }
        }

    }
}

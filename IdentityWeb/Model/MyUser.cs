using Microsoft.AspNetCore.Identity;

namespace IdentityWeb.Model
{
    public class MyUser : IdentityUser<long>
    {
        public string? WeiXinAccount { get; set; }

    }
}

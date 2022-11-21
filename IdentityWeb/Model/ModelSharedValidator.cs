using FluentValidation;
using IdentityWeb.Data;
using Microsoft.AspNetCore.Identity;

namespace IdentityWeb.Model
{
    public class ModelSharedValidator : AbstractValidator<ModelShared>
    {
        
        public ModelSharedValidator(UserManager<MyUser> userManager)
        {

            RuleFor(x => x.Name).NotNull().Length(0, 10).MustAsync(async (x,_) => await userManager.FindByNameAsync(x)==null)
                .WithMessage("用户名已经存在了");
        }
    }
}
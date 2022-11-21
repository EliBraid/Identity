using FluentValidation;
using IdentityWeb.Data;
using Microsoft.AspNetCore.Identity;

namespace IdentityWeb.Model
{
    public class ModelSharedValidator : AbstractValidator<ModelShared>
    {
        
        public ModelSharedValidator(UserManager<MyUser> userManager)
        {

            RuleFor(x => x.Name).NotNull().Length(0, 10).MustAsync(async (name,_) => await userManager.FindByNameAsync(name)==null)
                .WithMessage("用户名已经存在了");
        }
    }
}
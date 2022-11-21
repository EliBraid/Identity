using FluentValidation;

namespace JWT
{
    public class Login2Validation:AbstractValidator<Model>
    {
        
        public Login2Validation()
        {
            RuleFor(x=> x.Name).NotNull().Length(3,10).WithMessage("长度必须是3-10");

        }
    }
}

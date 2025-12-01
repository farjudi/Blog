using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
    {
        public void  RegisterUserCommandValidator()
        {
            RuleFor(x => x.FirstName).
                NotEmpty().WithMessage("نام نمی‌تواند خالی باشد.");
            RuleFor(x => x.LastName).
                NotEmpty().WithMessage("نام خانوادگی نمیتواند خالی باشد ");
            RuleFor(x => x.Email).
                NotEmpty().WithMessage("ایمیل الزامی هست ").
                EmailAddress().WithMessage("فرمت ایمیل صحیح نیست ");
            RuleFor(x => x.Password).
                NotEmpty().WithMessage("رمز عبور الزامی هست ")
                .MinimumLength(6).WithMessage("رمز عبور حداقل  6 کاراکتر باشد ");

        }
    }
}

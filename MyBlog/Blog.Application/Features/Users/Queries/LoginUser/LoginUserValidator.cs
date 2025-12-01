using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Users.Queries.LoginUser
{
    public class LoginUserValidator : AbstractValidator<LoginUserQuery>
    {
        public void LoginUserCommandValidator()
        {
            RuleFor(x => x.Email).
                NotEmpty().WithMessage("ایمیل الزامی هست ").
                EmailAddress().WithMessage("فرمت ایمیل صحیح نیست ");
            RuleFor(x => x.Password).
                    NotEmpty().WithMessage("رمز عبور الزامی هست ")
                    .MinimumLength(6).WithMessage("رمز عبور حداقل  6 کاراکتر باشد ");
        }
    }
}

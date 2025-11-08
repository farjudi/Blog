using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Exceptions
{
    public class DuplicateEmailException: DomainException
    {
        public string Email { get; }
        public DuplicateEmailException(string email): base($"ایمیل '{email}' قبلاً ثبت شده است", "DUPLICATE_EMAIL")
        {
            Email = email;

        }
    }
}

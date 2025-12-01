using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Exceptions
{
    public class DuplicateUserException:Exception
    {
        public DuplicateUserException(string message="نام کاربری یا ایمیل قبلا ثبت شده :)") : base(message)
        {
        }

    }
}

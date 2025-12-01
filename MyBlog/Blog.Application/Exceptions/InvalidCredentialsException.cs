using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Exceptions
{
    public class InvalidCredentialsException: Exception
    {
        public InvalidCredentialsException(string message = "نام کاربری و یا رمز عبور اشتباه هست "):base(message) { }
    }
}

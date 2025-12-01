using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Exceptions
{
    public class InvalidEmailException:Exception
    {
        public InvalidEmailException(string message = "ایمیل وارد شده معتبر نمی باشد"):base(message) { }

    }
}

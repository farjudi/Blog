using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Interfaces
{
    public  interface IPasswordHasher
    {
        //برای اینکه هش کنیم رمز رو 
        string Hash(string password);
        //رمز ساده رو میگیره و با رمز هش شده مقایسه میکنه 
        bool Verify(string password, string hashedPassword);

    }
}

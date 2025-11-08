using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Enums
{
    public enum Role
    {
        [Description("کاربر عادی ")]
        User=0,
        [Description("مدیر سیستم")]
        Admin =1

    }
}

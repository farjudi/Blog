using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Blog.Domain.ValueObjects
{
    public record Email
    {
        private static readonly Regex EmailRegex = new(
                 @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase
            );
        public string Value { get; }

        //برای اینکه از بیرون دسترسی به کانستارکتور ما نداشته باشن 
        private Email(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("ایمیل نمی تواند خالی باشد ", nameof(value));
            if (!EmailRegex.IsMatch(value))
                throw new ArgumentException(" فرمت ایمیل نامعتبر است ", nameof(value));

            Value = value.Trim().ToLowerInvariant();
        }

       // این متد به جای constructor استفاده میشه.
        public static Email From(string value) =>new(value);
        public override string ToString() => Value;
        //برای تبدیل string  به  email
        public static implicit operator string(Email email) => email.Value;

    }
}

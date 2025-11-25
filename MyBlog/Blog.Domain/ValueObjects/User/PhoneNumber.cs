using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Blog.Domain.ValueObjects.User
{
    public record PhoneNumber
    {
        private static readonly Regex PhoneRegex = new(
          @"^09\d{9}$", // فرمت: 09123456789
        RegexOptions.Compiled
            );



       public string Value { get; }

        private PhoneNumber(string value)
        {
            
                Value = value ?? string.Empty;

        }

        public static PhoneNumber From(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
                return Empty();

            var cleaned = value.Replace(" ", "").Replace("-", "");
            if(!PhoneRegex.IsMatch(cleaned))
                throw new ArgumentException("فرمت شماره تلفن نامعتبر است (مثال: 09123456789)", nameof(value));
            return new PhoneNumber(cleaned);
        }
        public bool IsEmpty() => string.IsNullOrEmpty(Value);
        public static PhoneNumber Empty() => new(string.Empty);
        public override string ToString() => Value;
        public static implicit operator string(PhoneNumber phone) => phone.Value;
    }

}

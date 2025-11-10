using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.ValueObjects
{
    public record UserId
    {
        public int Value {  get;}

        private UserId(int value)
        {
            if(value < 0)
                throw new ArgumentException("UserId cannot be negative", nameof(value));
            Value = value;
        }
        public static UserId From(int value) => new(value);
        internal static UserId New() => new(0);
        public override string ToString() => Value.ToString();
        public static implicit operator int(UserId userId) => userId.Value;
    }
}

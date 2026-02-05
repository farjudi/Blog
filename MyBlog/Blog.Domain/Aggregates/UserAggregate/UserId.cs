

namespace Blog.Domain.Aggregates.UserAggregate
{
    public record UserId
    {
        public int Value {  get;}

        private UserId(int value)
        {
            
            Value = value;
        }
        public static UserId From(int value) => new(value);
        public bool IsTemporary => Value <= 0;
     
        public override string ToString() => Value.ToString();
        public static implicit operator int(UserId userId) => userId.Value;
    }
}

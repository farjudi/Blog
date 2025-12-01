
namespace Blog.Domain.Exceptions
{
    public class DomainException:Exception
    {
        //شناسه متنی یکتا 
        public string Code { get; } 
        
        protected DomainException(string message,string code):base(message)
        {
            Code = code;
        }
        protected DomainException(string message, string code, Exception innerException)
          : base(message, innerException)
        {
            Code = code;
        }
        public DomainException(string message) : base(message)
        {
            Code = "DOMAIN_ERROR";
        }
    }
}

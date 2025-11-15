

namespace Blog.Domain.Exceptions
{  
    /// <summary>
    /// زمانی که ایمیل یا پسورد اشتباه باشه (در Login)
    /// </summary>
    public class InvalidCredentialsException : DomainException
    {
        public InvalidCredentialsException() : base("ایمیل یا رمز عبور اشتباه است", "INVALID_CREDENTIALS")
        {
        }

    }
}

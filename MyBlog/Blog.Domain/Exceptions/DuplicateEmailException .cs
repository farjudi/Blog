

namespace Blog.Domain.Exceptions
{
    public class DuplicateEmailException: DomainException
    {
        public string Email { get; }
        public DuplicateEmailException(string email): base($"ایمیل '{email}' قبلاً ثبت شده است", "DUPLICATE_EMAIL")
        {
            Email = email;

        }
    }
}



using Blog.Domain.ValueObjects.User;

namespace Blog.Domain.Aggregates.UserAggregate
{
    public class User
    {
        public UserId UserId { get; private set; }

        public FullName FullName { get; private set; }

        public Email Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string PasswordHash { get; private set; }

        public Role Role { get; private set; } = Role.User;
        public bool IsActive { get; private set; } = true;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        private User() { }

        #region Factory Methods
        /// <summary>
        /// ساخت کابر جدید ثبت نام 
        /// </summary>

        public static User CreateNewUser(
            string firstName,
            string lastName,
            Email email,
            string passwordHash,
            Role role = Role.User,
             string phoneNumber = "")
        {


            var fullName = FullName.From(firstName, lastName);
            var emailV0 = Email.From(email);
            var phone = string.IsNullOrWhiteSpace(phoneNumber)
                ? PhoneNumber.Empty()
                : PhoneNumber.From(phoneNumber);

            return new User
            {
              //  UserId = UserId.New(), // EF Core میده
                FullName = fullName,
                Email = email,
                PhoneNumber = phone,
                PasswordHash = passwordHash,
                Role = Role.User,
                IsActive = true,
                CreatedAt = DateTime.UtcNow

            };

        }
        /// <summary>
        /// ساخت کاربر توسظ ادمین 
        /// </summary>
        /// 
        public static User CreateAdminUser(
            string firstName,
            string lastName,
            Email email,
            string passwordHash,
            string phoneNumber = "")
        {

            var user = CreateNewUser(
                firstName,
                lastName,
                email,
                passwordHash,
                Role.Admin,
                phoneNumber);

            return user;
        }


        #endregion

        #region Business Methods

        public void Activate() {
            if (IsActive)
                throw new DomainException("کاربر فعال است ");
            IsActive = true;

        }
        public void Deactivate()
        {
            if (!IsActive)
                throw new DomainException("کاربر غیرفعال است ");
            IsActive = false;

        }
        #endregion
    }


}

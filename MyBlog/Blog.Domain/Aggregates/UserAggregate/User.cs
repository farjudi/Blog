using Blog.Domain.Enums;
using Blog.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Aggregates.UserAggregate
{
    public class User
    {
        public int UserId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Email Email { get; private set; }
        public string PhoneNumber { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; }
        public Role Role { get; private set; } = Role.User;
        public bool IsActive { get; private set; } = true;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        private User() { }

        public static User Create(string firstName, string lastName, string email, string phoneNumber, string passwordHash, Role role = Role.User)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("ایمیل نمی‌تواند خالی باشد");

            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("نام نمی‌تواند خالی باشد");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("نام خانوادگی نمی‌تواند خالی باشد");

            return new User
            {
                Email = email.Trim().ToLower(),
                PasswordHash = passwordHash,
                FirstName = firstName.Trim(),
                LastName = lastName.Trim(),
                PhoneNumber = phoneNumber ?? string.Empty,
                Role = Role.User,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

        }
        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;

    }
}

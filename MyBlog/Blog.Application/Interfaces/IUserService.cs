using Blog.Domain.ValueObjects.User;
using System;

public interface IUserService
{
    Task<bool> UserExistsAsync(string username, Email email);
    Task<User?> GetUserByEmailAsync(Email email);
     Task<bool> VerifyPasswordAsync(string password, string passwordHash);

    //Task<User> CreateUserAsync(User user);


}

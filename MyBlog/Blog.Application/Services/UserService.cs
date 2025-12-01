using Blog.Domain.Aggregates.UserAggregate;
using Blog.Domain.Repositories;
using Blog.Domain.ValueObjects.User;
using System;
using System.Threading.Tasks;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;

    }
    ////کاربر جدید 
    //public async Task<User> CreateUserAsync(User user)
    //{
    //    await _userRepository.AddAsync(user);
    //    return user;
    //}

    //دریافت کابر بر اساس ایمیل  
    public async Task<User?> GetUserByEmailAsync(Email email)
    {
        return await _userRepository.GetByEmailAsync(email);
    }

    //برسی وجود کاربر تکراری 
    public async Task<bool> UserExistsAsync(string username, Email email)
    {
        return await _userRepository.UserExistsAsync(username, email);
    }

    //برسی رمز عبور 
    // هش پسورد رو درست کن یادت نره 
    public async Task<bool> VerifyPasswordAsync(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
      
    }

  
}

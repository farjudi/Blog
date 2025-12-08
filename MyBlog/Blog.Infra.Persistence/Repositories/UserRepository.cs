using Blog.Domain.Aggregates.UserAggregate;
using Blog.Domain.Enums;
using Blog.Domain.Repositories;
using Blog.Domain.ValueObjects.User;
using Blog.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infra.Persistence.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context; 
        }

        //ثبت نام کن و یوزر رو اضافه کن 
        public async Task<User> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
       //     await _context.SaveChangesAsync();// ذخیره  در دیتا بیس 
            return user;

        }

        public  Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            return Task.CompletedTask;
        }

        public Task<bool> EmailExistAsync(Email email)
        {
            return _context.Users.AnyAsync(u=>u.Email==email);
        }

        public async Task<List<User>> GetAllActiveUsersAsync()
        {
            return await _context.Users
                .Where(u=>u.IsActive)
                .ToListAsync();
        }

        public async Task<List<User>> GetAllAdminsAsync()
        {
            return await _context.Users
                .Where(u=>u.Role==Role.Admin)
                .ToListAsync();
        }

        public async Task<User?> GetByEmailAsync(Email email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        }

        public async Task<User?> GetByIdAsync(UserId id)
        {
            //دیدی چیشد userid رو با کنفیگی که کردی تشخیص داد  int  عجبببببببب!! باحال بود 
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            return await _context.SaveChangesAsync(ct);
        }

        public Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            return Task.CompletedTask;
        }

        public async Task<bool> UserExistsAsync(string userName, Email email)
        {
            return await _context.Users
                 .AnyAsync(u => u.FullName.FirstName+" "+u.FullName.LastName == userName || u.Email == email);

        }
    }
}

using Blog.Application.Interfaces;
using Blog.Domain.Aggregates.UserAggregate;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Authentication
{
    public class CookieAuthenticationService : ICookieAuthenticationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieAuthenticationService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task SignInAsync(User user)
        {
            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.Value.ToString()),
            new Claim(ClaimTypes.Email, user.Email.Value),
            new Claim(ClaimTypes.Name, user.FullName.GetFullName()),
            new Claim(ClaimTypes.Role, user.Role.ToString())
           };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true, // یادآوری من (کوکی ماندگار)
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(14) // همخوان با تنظیمات کوکی
            };

            await _httpContextAccessor.HttpContext!.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        public async Task SingOutAsync()
        {
            await _httpContextAccessor.HttpContext!
                .SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}

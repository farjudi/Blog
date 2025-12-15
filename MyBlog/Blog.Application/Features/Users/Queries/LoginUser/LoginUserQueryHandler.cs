using Blog.Application.Interfaces; // برای IPasswordHasher و IJwtTokenGenerator
using Blog.Domain.Repositories;
using Blog.Domain.ValueObjects.User;
using MediatR;

namespace Blog.Application.Features.Users.Queries.LoginUser
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoginResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
       // private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginUserQueryHandler(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher
          //,  IJwtTokenGenerator jwtTokenGenerator
          )
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
     //       _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<LoginResponseDto> Handle(LoginUserQuery request, CancellationToken cancellationToken) 
        { 
            var emailVo = Email.From(request.Email);
            var user = await _userRepository.GetByEmailAsync(emailVo);

           
            if (user == null)
            {
                throw new Exception("نام کاربری یا رمز عبور اشتباه است.");
            }

          
            bool isPasswordValid = _passwordHasher.Verify(request.Password, user.PasswordHash);
            if (!isPasswordValid)
            {
                throw new Exception("نام کاربری یا رمز عبور اشتباه است.");
            }

          
            if (!user.IsActive)
            {
                throw new Exception("حساب کاربری شما غیرفعال شده است.");
            }

        
          // var token = _jwtTokenGenerator.GenerateToken(user);

         
            return new LoginResponseDto
            {
                UserId = user.UserId.Value,
                FullName = user.FullName.GetFullName(), // استفاده از متد دامین
           //    Token = token,
                Role = user.Role.ToString() // تبدیل Enum به string
            };
        }
    }
}
using Blog.Application.Interfaces;
using Blog.Domain.Aggregates.UserAggregate;
using Blog.Domain.Enums;
using Blog.Domain.Repositories;
using Blog.Domain.ValueObjects.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IApplicationDbContext _context;
        public RegisterUserCommandHandler(IUserRepository userRepository,IPasswordHasher passwordHasher, IApplicationDbContext context)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _context = context;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var emailVo = Email.From(request.Email);
            if (await _userRepository.EmailExistAsync(emailVo))
            {
                throw new Exception("شوما که با این ایمیل اومده بودی :)");
            }
            //hashig password
            var passwordHash = _passwordHasher.Hash(request.Password);

            var newUser=User.CreateNewUser(
                request.FirstName,
                request.LastName,
                emailVo,
                passwordHash,
                Role.User,
                request.PhoneNumber
                );

            await _userRepository.AddAsync(newUser);
            await _userRepository.SaveChangesAsync(cancellationToken);
          
            Console.WriteLine("REGISTER HANDLER HIT");
            return newUser.UserId.Value;
        
        }
    }
}

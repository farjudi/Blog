using System;
using Blog.Application.DTOs.UserDtos;
using Blog.Domain.Aggregates.UserAggregate;
public class UserMappingProfile
{
	public static UserResponseDto ToUserResponseDto(User user) 
	{
		return new UserResponseDto
		{
			UserId = user.UserId.Value,
			Email = user.Email.Value,
            FullName = user.FullName.GetFullName(),
            FirstName = user.FullName.FirstName,
			LastName = user.FullName.LastName,
			PhoneNumber = user.PhoneNumber.Value,
            Role = user.Role.ToString(),

            IsActive = user.IsActive,
			CreatedAt = user.CreatedAt
		};

    }
	public static LoginDto ToLoginDto(User user)
	{
		return new LoginDto
		{
			Email = user.Email,

            PasswordHash = user.PasswordHash,
        };
    }

	public static RegisterUserDto ToRegisterUserDto(User user)
	{
		return new RegisterUserDto { 	
			FirstName = user.FullName.FirstName,
			LastName = user.FullName.LastName,
			Email = user.Email.Value,
			PasswordHash = user.PasswordHash,
			PhoneNumber = user.PhoneNumber.Value
        };

    }

	public static LoginResponseDto ToLoginResponseDto(User user, string token)
	{
		return new LoginResponseDto
		{
            UserId = user.UserId.Value,
			//Token = token,
			Email = user.Email.Value,
			FullName = user.FullName.GetFullName(),
            Role = user.Role.ToString()


        };
    }

    
}

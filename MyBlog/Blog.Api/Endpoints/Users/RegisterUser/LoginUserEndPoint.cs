using Blog.Application.Features.Users.Queries.LoginUser;
using Blog.Application.Interfaces;
using MediatR;
using System.Runtime.CompilerServices;

namespace Blog.Api.Endpoints.Users.LoginUser
{
    public static class LoginUserEndPoint
    {
        public static RouteGroupBuilder MapLoginUserEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/login", async (LoginUserQuery query
                                              , IMediator mediator
                                              ,ICookieAuthenticationService cookieService) =>
            {
                var user = await mediator.Send(query);
                if (user == null)
                    return Results.Unauthorized();


                //  Cookie Authentication
              //  await cookieService.SignInAsync(user);

                return Results.Ok(new { Message = "Logged in successfully" });
            })
                .WithName("LoginUser");
            return group;
        }
    }
}

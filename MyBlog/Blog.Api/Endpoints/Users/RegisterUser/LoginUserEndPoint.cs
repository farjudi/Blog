using Blog.Application.Features.Users.Queries.LoginUser;
using MediatR;
using System.Runtime.CompilerServices;

namespace Blog.Api.Endpoints.Users.RegisterUser
{
    public static class LoginUserEndPoint
    {
        public static void MapLoginUserEndpoint(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapPost("/login", async (LoginUserQuery query, IMediator mediator) =>
            {
                var result = await mediator.Send(query);
                return Results.Ok(result);
            })
                .WithName("LoginUser");
        }
    }
}

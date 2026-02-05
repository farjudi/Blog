

using Blog.Application.Features.Users.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;

namespace Blog.Api.Endpoints.Users.RegisterUser
{
    public static class RegisterUserEndPoint
    {
        public static RouteGroupBuilder MapRegisterUserEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/register",async
                (RegisterUserCommand command,
                IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return Results.Ok(result);
            })
         .WithName("RegisterUser")
        .Produces(200)  
        .ProducesValidationProblem(400);

            return group;
      
        }


    }
}

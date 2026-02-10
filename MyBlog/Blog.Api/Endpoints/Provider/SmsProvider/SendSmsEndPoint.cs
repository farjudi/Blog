using Blog.Application.DTOs.SmsDtos;
using Blog.Application.Features.Sms;

namespace Blog.Api.Endpoints.Provider.SmsProvider
{


    public static class SendSmsEndPoint
    {
        public static RouteGroupBuilder MapSendSmsEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/send", async (
            SendSmsRequest request,
            SendSmsUseCase sendSmsUseCase) =>
            {

                var dto = new SendSmsDto(
                    request.PhoneNumber,
                    request.Message
                     );



                await sendSmsUseCase.ExecuteAsync(dto);
                return Results.Ok(new { message = "SMS sent successfully" });
            })
        .WithName("SendSms");
            return group;
        }
    }
}
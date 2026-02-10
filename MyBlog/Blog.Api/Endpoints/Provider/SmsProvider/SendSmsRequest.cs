namespace Blog.Api.Endpoints.Provider.SmsProvider
{
    public record SendSmsRequest(
        string PhoneNumber,
        string Message
    );
}

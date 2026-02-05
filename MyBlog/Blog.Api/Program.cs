using Blog.Api.Endpoints.Users.RegisterUser;
using Blog.Api.Endpoints.Users.LoginUser;
using Blog.Application;
using Blog.Infra.Persistence;
using Blog.Infrastructure;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
var builder = WebApplication.CreateBuilder(args);

///Dependency Injection
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure();



// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


//سیستم احراز هویت بر اساس کوکی 
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {

        options.ExpireTimeSpan = TimeSpan.FromDays(14);
        options.SlidingExpiration = true;// اگر کاربر فعال باشه، زمان انقضا تمدید بشه
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Lax; // امنیت CSRF

        options.Events=new CookieAuthenticationEvents
        {
            OnRedirectToLogin= context =>
            {
                context.Response.StatusCode= StatusCodes.Status401Unauthorized; // Unauthorized
                return Task.CompletedTask;
            },
            OnRedirectToAccessDenied= context =>
            {
                context.Response.StatusCode= StatusCodes.Status403Forbidden; ; // Forbidden
                return Task.CompletedTask;
            }
        };



    });
builder.Services.AddAuthorization(); //(برای [Authorize]






var  app = builder.Build();

//app.MapGroup("/api/users")
//   .MapRegisterUserEndpoint()
//   .MapLoginUserEndpoint();


app.MapGroup("/api/users")
   .MapRegisterUserEndpoint()
   .MapLoginUserEndpoint();

//app.MapGet("/", () => "hi every bady <..>");
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    //    app.MapOpenApi();
//}

if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        // به سوگر میگیم: "برو فایل رو دقیقا از این آدرس بردار"
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Blog API V1");
    });
    // این خط مال سیستم جدیده، فعلا برش دار تا با UseSwaggerUI تداخل نخوره
    // app.MapOpenApi(); 
}
app.MapGet("/a", () => "Blog.Api is running...") ;

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

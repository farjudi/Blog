using Blog.Application;
using Blog.Infra.Persistence;
using Blog.Infrastructure;
using Microsoft.OpenApi.Models;
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
//builder.Services.AddOpenApi();

var  app = builder.Build();

app.MapGet("/", () => "hi every bady <..>");
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

app.UseAuthorization();

app.MapControllers();

app.Run();

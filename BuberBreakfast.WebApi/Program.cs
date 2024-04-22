using BuberBreakfast.Application;
using BuberBreakfast.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer().AddSwaggerGen();
builder.Services.AddApplication().AddInfrastructure(builder.Configuration)
    .AddSingleton<ProblemDetailsFactory, BuberBreakfast.WebApi.Errors.ProblemDetailsFactory>();

var app = builder.Build();
app.UseHttpsRedirection().UseAuthorization().UseExceptionHandler("/error");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
using Application;
using Persistence;
using Shared;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationLayer();
builder.Services.AddSharedInfraestructure(Configuration);
builder.Services.AddPersistanceInfraestructure(Configuration);
builder.Services.AddApiVersioningExtension();

builder.Services.AddCors(o => o.AddPolicy("CORS", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));


var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    
}

app.UseCors("CORS");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseErrorHandlerMiddleware();

app.MapControllers();

app.Run();

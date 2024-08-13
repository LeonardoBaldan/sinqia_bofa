using AutoMapper;
using Sinqia.Bofa.Domain;
using Sinqia.Bofa.Service.Validation;
using Sinqia.Bofa.Service.Validation.Interface;
using Sinqia.Bofa.WebApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// automapper
var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<UserViewModel, UserModel>().ReverseMap();
});
IMapper mapper = config.CreateMapper();

builder.Services.AddTransient<IValidationUserService, ValidationUserService>();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

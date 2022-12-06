using AutoMapper;
using IdentityService.Business.AutoMapper;
using IdentityService.Business.Extensions;
using IdentityService.DataAccess.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Registration Extensions
builder.Services.AddBusinessRegistration();
builder.Services.AddDataAccessRegistration();
//
// AutoMapper Configuration
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new UserProfile());
});
//

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

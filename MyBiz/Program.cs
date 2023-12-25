using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using MyBiz.Core.Repositories;
using MyBiz.Data.DAL;
using MyBiz.Data.Repositories.Implementations;
using MyBiz.DTOs;
using MyBiz.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(opt =>
{
    opt.RegisterValidatorsFromAssembly(typeof(EmployeeCreateDtoValidatior).Assembly);

});
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("default2"));
});
builder.Services.AddAutoMapper(typeof(MapProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IFileService,FileService>();

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

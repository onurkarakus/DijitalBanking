using Customer.Business.Queries.Handlers;
using Customer.Domain.Interfaces.Respoistories;
using Customer.Domain.Interfaces.Respoistories.Base;
using Customer.Infrastructure;
using Customer.Infrastructure.DbContextInformation;
using Customer.Infrastructure.Repositories;
using Customer.Infrastructure.Repositories.Base;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddScoped<CustomerDbContext>();
builder.Services.AddDbContextPool<CustomerDbContext>(options => options.UseSqlServer(configuration["ConnectionString:CustomerDigitalBankDB"]));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("Customer.Business")));

builder.Services.AddAutoMapper(Assembly.Load("Customer.Domain"));

builder.Services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
builder.Services.AddTransient(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
builder.Services.AddTransient<ICustomerInformationRespository, CustomerInformationRepository>();

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

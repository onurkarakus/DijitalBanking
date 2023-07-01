using Account.Infrastructure.DbContextInformation;
using Account.Infrastructure.Repositories;
using Account.Infrastructure.Repositories.Interfaces;
using DigitalBanking.Common.Interfaces.Respoistory;
using DigitalBanking.Common.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddScoped<AccountDbContext>();
builder.Services.AddDbContextPool<AccountDbContext>(options => options.UseSqlServer(configuration["ConnectionString:AccountDigitalBankDB"]));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("Account.Business")));

builder.Services.AddAutoMapper(Assembly.Load("Account.Domain"));

builder.Services.AddTransient(typeof(IBaseRepository<,,>), typeof(BaseRepository<,,>));
builder.Services.AddTransient<IAccountCurrencyRepository, AccountCurrencyRepository>();
builder.Services.AddTransient<IAccountTypeRepository, AccountTypeRepository>();
builder.Services.AddTransient<IAccountInformationRepository, AccountInformationRepository>();

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

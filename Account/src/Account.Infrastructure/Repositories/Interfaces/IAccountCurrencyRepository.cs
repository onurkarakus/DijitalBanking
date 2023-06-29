using Account.Domain.DataModels;
using Account.Infrastructure.DbContextInformation;
using DigitalBanking.Common.Interfaces.Respoistory;

namespace Account.Infrastructure.Repositories.Interfaces;

public interface IAccountCurrencyRepository : IBaseRepository<AccountCurrency, int, AccountDbContext>
{

}

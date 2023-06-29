using Account.Domain.DataModels;
using Account.Infrastructure.DbContextInformation;
using Account.Infrastructure.Repositories.Interfaces;
using DigitalBanking.Common.Repositories;

namespace Account.Infrastructure.Repositories;

public class AccountCurrencyRepository : BaseRepository<AccountCurrency, int, AccountDbContext>, IAccountCurrencyRepository
{
    public AccountCurrencyRepository(AccountDbContext dbContext) : base(dbContext)
    {

    }
}

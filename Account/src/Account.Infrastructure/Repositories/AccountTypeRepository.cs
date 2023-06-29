using Account.Domain.DataModels;
using Account.Infrastructure.DbContextInformation;
using Account.Infrastructure.Repositories.Interfaces;
using DigitalBanking.Common.Repositories;

namespace Account.Infrastructure.Repositories;

public class AccountTypeRepository: BaseRepository<AccountType, int, AccountDbContext>, IAccountTypeRepository
{
    public AccountTypeRepository(AccountDbContext dbContext) : base(dbContext)
    {

    }
}
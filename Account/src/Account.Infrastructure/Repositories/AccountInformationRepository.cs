using Account.Domain.DataModels;
using Account.Infrastructure.DbContextInformation;
using Account.Infrastructure.Repositories.Interfaces;
using DigitalBanking.Common.Repositories;

namespace Account.Infrastructure.Repositories;

public class AccountInformationRepository: BaseRepository<AccountInformation, int, AccountDbContext>, IAccountInformationRepository
{
    public AccountInformationRepository(AccountDbContext dbContext) : base(dbContext)
    {

    }
}

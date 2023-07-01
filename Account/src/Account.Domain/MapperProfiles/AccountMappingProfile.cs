using Account.Domain.DataModels;
using Account.Domain.Models.ViewModels;
using AutoMapper;

namespace Account.Domain.MapperProfiles;

public class AccountMappingProfile: Profile
{
    public AccountMappingProfile()
    {
        CreateMap<AccountCurrency, AccountCurrencyViewModel>();
        CreateMap<AccountType, AccountTypeViewModel>();
        CreateMap<AccountInformation, AccountInformationViewModel>();
    }
}

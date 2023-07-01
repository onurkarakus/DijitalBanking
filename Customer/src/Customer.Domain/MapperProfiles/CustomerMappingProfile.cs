using AutoMapper;
using Customer.Domain.DataModels;
using Customer.Domain.Models.ViewModels;

namespace Customer.Domain.MapperProfiles;

public class CustomerMappingProfile: Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<CustomerInformation, CustomerInformationViewModel>();
    }
}

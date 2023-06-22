using AutoMapper;
using Customer.Domain.DataModels;
using Customer.Domain.Models;

namespace Customer.Domain.MapperProfiles;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<CustomerInformation, CustomerInformationDto>();        
    }
}

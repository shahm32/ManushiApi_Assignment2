using AutoMapper;
namespace ManushiApi.Entities
{ 
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
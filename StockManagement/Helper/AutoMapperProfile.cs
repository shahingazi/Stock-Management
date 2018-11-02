using AutoMapper;
using StockManagement.Data;
using StockManagement.Dtos;

namespace StockManagement.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, Credentials>().ForMember(x=>x.Username, opt=> opt.MapFrom(x=>x.Email));           
            CreateMap<Credentials, User>().ForMember(x=>x.Email, opt=>opt.MapFrom(x=>x.Username));
            
        }
    }
}

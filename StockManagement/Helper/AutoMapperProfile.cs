using AutoMapper;
using StockManagement.Data;
using StockManagement.Dtos;

namespace StockManagement.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, Credentials>();
            CreateMap<Credentials, User>();
        }
    }
}

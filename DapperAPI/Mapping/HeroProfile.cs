using AutoMapper;
using DapperAPI.Models;
using DapperAPI.Models.DTO_s;

namespace DapperAPI.Mapping
{
    public class HeroProfile : Profile
    {
        public HeroProfile()
        {
            CreateMap<Entity, EntityDTO>().ReverseMap();
        }
    }
}

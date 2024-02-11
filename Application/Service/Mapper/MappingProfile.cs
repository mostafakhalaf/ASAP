using AutoMapper;
using Common.ViewModels;
using Domain.Entities;

namespace Application.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<ClientViewModel, Client>().ReverseMap();
            CreateMap<List<PolygonApiResult>, List<PolygonApiResultViewModel>>().ReverseMap();

        }
    }
}

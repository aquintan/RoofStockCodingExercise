using AutoMapper;

namespace RoofStock.CodingExercise.Api.Infrastructure.Automapper
{
    using Domain;
    using Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PropertyModel, Property>()
                .ForMember(m => m.Guid, o => o.MapFrom(m => m.Id))
                .ForMember(m => m.Id, o => o.Ignore())
                .ReverseMap()
                .ForMember(m => m.Id, o => o.MapFrom(m => m.Guid));
        }
    }
}
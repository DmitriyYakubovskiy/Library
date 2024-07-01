using AutoMapper;
using Library.DataAccess.Entities;
using AngularLibrary.Server.Models;

namespace AngularLibrary.Server.Mappings;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<BookModel, BookEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
            .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year))
            .ForMember(dest => dest.Publisher, opt => opt.Ignore())
            .ForMember(dest => dest.Author, opt => opt.Ignore())
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
            .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year))
            .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.Publisher))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author));

        CreateMap<AuthorModel, AuthorEntity>().ReverseMap();
        CreateMap<PublisherModel, PublisherEntity>().ReverseMap();
    }
}

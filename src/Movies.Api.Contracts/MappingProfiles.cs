using AutoMapper;
using Movies.Api.Contracts.Entities;
using Movies.Api.Contracts.Models;

namespace Movies.Api.Contracts
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<MovieEntity, MovieDTO>().ReverseMap();

            CreateMap<RatingEntity, RatingDTO>();
            CreateMap<RatingDTO, RatingEntity>(MemberList.Source)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.MovieId, opt => opt.Ignore())
                .ForMember(dest => dest.Movie, opt => opt.Ignore());


            CreateMap<UserEntity, UserDTO>().ReverseMap();
            CreateMap<GenreEntity, GenreDTO>().ReverseMap();
        }
    }
}
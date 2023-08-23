using AutoMapper;
using PokemonReviewApp2.Dto;
using PokemonReviewApp2.Models;

namespace PokemonReviewApp2.Helper;

public class MappingProfiles : Profile{
    public MappingProfiles()
    {
        CreateMap<Pokemon, PokemonDto>();
        CreateMap<Category, CategoryDto>();
        CreateMap<Country, CountryDto>();
        CreateMap<Owner, OwnerDto>();
        CreateMap<Review, ReviewDto>();
        CreateMap<Reviwer, ReviwerDto>();
    }
}

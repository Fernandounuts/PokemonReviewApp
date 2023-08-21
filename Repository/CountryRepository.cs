using AutoMapper;
using PokemonReviewApp2.Data;
using PokemonReviewApp2.Interface;
using PokemonReviewApp2.Models;

namespace PokemonReviewApp2.Repository;

public class CountryRepository : ICountry {
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CountryRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public bool CountryExists(int countryId) {
        return _context.Countries.Any(c => c.Id == countryId);
    }

    public ICollection<Country> getCountries() {
        return _context.Countries.OrderBy(c => c.Name).ToList();
    }

    public ICollection<Country> GetCountries() {
        return _context.Countries.ToList();
    }

    public Country GetCountry(int Id) {
        return _context.Countries
            .Where(c => c.Id == Id)
            .FirstOrDefault();
    }

    public Country GetCountryByOwner(int ownerId) {
        return _context.Owners
            .Where(o => o.Id == ownerId)
            .Select(c => c.Country)
            .FirstOrDefault();
    }

    public ICollection<Owner> GetOwnersFromCountry(int countryId) {
        return _context.Owners.Where(c => c.Country.Id == countryId)
            .ToList();
    }
}

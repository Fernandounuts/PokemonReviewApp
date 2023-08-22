using PokemonReviewApp2.Models;

namespace PokemonReviewApp2.Interface;

public interface ICountry {
    ICollection<Country> GetCountries();
    Country GetCountry(int Id);
    Country GetCountryByOwner(int ownerId);
    ICollection<Owner> GetOwnersFromCountry(int countryId);
    bool CountryExists(int countryId);
}

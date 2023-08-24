using PokemonReviewApp2.Models;

namespace PokemonReviewApp2.Interface;

public interface IPokemon {
    ICollection<Pokemon> GetPokemons();
    Pokemon GetPokemon(int id);
    Pokemon GetPokemon(string Name);
    decimal GetPokemonRating(int pokeId);
    bool PokemonExists(int pokeId);
    bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon);
    bool Save();
}

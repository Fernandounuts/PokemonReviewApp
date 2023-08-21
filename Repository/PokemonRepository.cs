using PokemonReviewApp2.Data;
using PokemonReviewApp2.Interface;
using PokemonReviewApp2.Models;

namespace PokemonReviewApp2.Repository;

public class PokemonRepository : IPokemon {
    private readonly DataContext _context;

    public PokemonRepository(DataContext context) {
        _context = context;
    }

    public Pokemon GetPokemon(int id) {
        return _context.Pokemons.Where(p => p.Id == id).FirstOrDefault();
    }

    public Pokemon GetPokemon(string Name) {
        return _context.Pokemons.Where(p => p.Name == Name).FirstOrDefault();
    }

    public decimal GetPokemonRating(int pokeId) {
        var review = _context.Reviews.Where(p => p.Pokemon.Id == pokeId);
        if (review.Count() <= 0)
            return 0;
        return ((decimal)review.Sum(r => r.Rating) / review.Count());
    }

    public ICollection<Pokemon> GetPokemons() {
        return _context.Pokemons.OrderBy(p => p.Id).ToList();
    }

    public bool PokemonExists(int pokeId) {
        return _context.Pokemons.Any(p => p.Id == pokeId);
    }
}

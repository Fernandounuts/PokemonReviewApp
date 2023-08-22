using PokemonReviewApp2.Models;

namespace PokemonReviewApp2.Interface;

public interface IOwner {
    ICollection<Owner> GetOwners();
    Owner GetOwner(int ownerId);
    ICollection<Owner> GetOwnerOfAPokemon(int pokeId);
    ICollection<Pokemon> GetPokemonByOwner(int ownerId);
    bool OwnerExists(int ownerId);


}

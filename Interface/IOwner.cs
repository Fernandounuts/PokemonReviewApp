using PokemonReviewApp2.Models;

namespace PokemonReviewApp2.Interface;

public interface IOwner {
    ICollection<Owner> GetOwners();
    Owner GetOwner();
    ICollection<Owner> GetOwnerOfAPokemon(Owner owner);

}

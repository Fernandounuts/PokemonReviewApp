using PokemonReviewApp2.Models;

namespace PokemonReviewApp2.Interface;

public interface ICategory {
    ICollection<Category> GetCategories();
    Category GetCategory(int id);
    ICollection<Pokemon> GetPokemonByCategory(int categoryId);
}

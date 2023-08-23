using PokemonReviewApp2.Models;

namespace PokemonReviewApp2.Interface;

public interface IReview {
    ICollection<Review> GetReviews();
    Review GetReview(int id);
    ICollection<Review> GetReviewsFromAPokemon(int pokeId);
    bool ReviewExists(int reviewId);
}

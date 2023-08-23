using AutoMapper;
using PokemonReviewApp2.Data;
using PokemonReviewApp2.Interface;
using PokemonReviewApp2.Models;

namespace PokemonReviewApp2.Repository;

public class ReviewRepository : IReview {
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ReviewRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public Review GetReview(int id) {
        return _context.Reviews.Where(r => r.Id == id).FirstOrDefault();
    }

    public ICollection<Review> GetReviews() {
        return _context.Reviews.ToList();
    }

    public ICollection<Review> GetReviewsFromAPokemon(int pokeId) {
        return _context.Reviews.Where(r => r.Pokemon.Id == pokeId).ToList();
    }

    public bool ReviewExists(int reviewId) {
        return _context.Reviews.Any(r => r.Id == reviewId);
    }
}

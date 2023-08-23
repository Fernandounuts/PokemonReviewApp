using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonReviewApp2.Data;
using PokemonReviewApp2.Interface;
using PokemonReviewApp2.Models;

namespace PokemonReviewApp2.Repository;

public class ReviwerRepository : IReviwer {
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ReviwerRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ICollection<Review> GetReviewsByReviwer(int reviewerId) {
        return _context.Reviews.Where(r => r.Reviewer.Id == reviewerId).ToList();
    }

    public Reviwer GetReviwer(int reviwerId) {
        return _context.Reviwers.Where(r => r.Id == reviwerId).Include(e => e.Reviews).FirstOrDefault();
    }

    public ICollection<Reviwer> GetReviwers() {
        return _context.Reviwers.ToList();
    }

    public bool ReviwerExists(int reviwerId) {
        return _context.Reviwers.Any(r => r.Id == reviwerId);
    }
}

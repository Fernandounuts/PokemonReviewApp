using PokemonReviewApp2.Models;

namespace PokemonReviewApp2.Interface;

public interface IReviwer {
    ICollection<Reviwer> GetReviwers();
    Reviwer GetReviwer(int reviwerId);
    ICollection<Review> GetReviewsByReviwer(int reviewerId);
    bool ReviwerExists(int reviwerId);
}

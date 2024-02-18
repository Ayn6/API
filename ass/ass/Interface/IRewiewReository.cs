using ass.Models;

namespace ass.Interface
{
    public interface IRewiewReository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int id);
        ICollection<Review> GetReviewsOfPokemon(int pokeId);
        bool ReviewExists(int id);
    }
}

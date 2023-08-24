using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp2.Dto;
using PokemonReviewApp2.Interface;
using PokemonReviewApp2.Models;

namespace PokemonReviewApp2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewController : Controller{
    private readonly IReview _reviewRepository;
    private readonly IMapper _mapper;

    public ReviewController(IReview reviewRepository, IMapper mapper)
    {
        _reviewRepository = reviewRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
    public IActionResult GetReviews() {
        var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviews());
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(reviews);
    }

    [HttpGet("{reviewId}")]
    [ProducesResponseType(200, Type = typeof(Review))]
    [ProducesResponseType(400)]

    public IActionResult GetReview(int reviewId) {
        if (!_reviewRepository.ReviewExists(reviewId))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var review = _mapper.Map<ReviewDto>(_reviewRepository.GetReview(reviewId));
        return Ok(review);
    }

    [HttpGet("pokemon/{pokeId}")]
    [ProducesResponseType(200, Type = typeof(Review))]
    [ProducesResponseType(400)]
    public IActionResult GetReviewsForAPokemon(int pokeId) {
        var review = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviewsFromAPokemon(pokeId));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(review);
    }
}

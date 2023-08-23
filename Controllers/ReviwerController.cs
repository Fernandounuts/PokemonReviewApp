using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp2.Dto;
using PokemonReviewApp2.Interface;
using PokemonReviewApp2.Models;
using PokemonReviewApp2.Repository;

namespace PokemonReviewApp2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviwerController : Controller{
    private readonly IReviwer _reviwer;
    private readonly IMapper _mapper;

    public ReviwerController(IReviwer reviwer, IMapper mapper)
    {
        _reviwer = reviwer;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Reviwer>))]
    public IActionResult GetReviwers() {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var reviwers = _mapper.Map<List<ReviwerDto>>(_reviwer.GetReviwers());
        return Ok(reviwers);
    }

    /*[HttpGet("{reviwerId}")]
    [ProducesResponseType(200, Type = typeof(Reviwer))]
    [ProducesResponseType(400)]

    public IActionResult GetReviwer(int reviwerId) {
        if (!_reviwer.ReviwerExists(reviwerId))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        //var reviwer = _mapper.Map<ReviwerDto>(_reviwer.GetReviwer(reviwerId));
        var reviwer = _mapper.Map<ReviwerDto>(_reviwer.GetReviwer(reviwerId));

        return Ok(reviwer);
    } */
    [HttpGet("{reviewerId}")]
    [ProducesResponseType(200, Type = typeof(Reviwer))]
    [ProducesResponseType(400)]
    public IActionResult GetReviwer(int reviewerId) {
        if (!_reviwer.ReviwerExists(reviewerId))
            return NotFound();

        var reviewer = _mapper.Map<ReviwerDto>(_reviwer.GetReviwer(reviewerId));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(reviewer);
    }

    [HttpGet("{reviwerId}/reviews")]
    //[ProducesResponseType(400)]
    //[ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]

    public IActionResult GetReviewsByAReviwer(int reviwerId) {
        if (!_reviwer.ReviwerExists(reviwerId))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        //var reviews = _reviwer.GetReviewsByReviwer(reviwerId);
        //var reviews = _mapper.Map<List<ReviwerDto>>(
        //_reviwer.GetReviewsByReviwer(reviwerId));
        var reviews = _mapper.Map<List<ReviewDto>>(
            _reviwer.GetReviewsByReviwer(reviwerId));
        return Ok(reviews);
    }

}

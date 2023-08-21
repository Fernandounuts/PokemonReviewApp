using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp2.Data;
using PokemonReviewApp2.Dto;
using PokemonReviewApp2.Interface;
using PokemonReviewApp2.Models;
using PokemonReviewApp2.Repository;

namespace PokemonReviewApp2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountryController : Controller {
    private readonly ICountry _countryRepository;
    private readonly IMapper _mapper;

    public CountryController(ICountry countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
    public IActionResult GetCategories() {
        var countries = _mapper.Map<ICollection<CountryDto>>(_countryRepository.GetCountries());

        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        return Ok(categories);
    }

}

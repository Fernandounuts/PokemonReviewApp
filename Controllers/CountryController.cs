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

        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
        
        return Ok(countries);
    }

    [HttpGet("{countryId}")]
    [ProducesResponseType(200, Type = typeof(Country))]
    [ProducesResponseType(400)]
    public IActionResult GetCountry(int countryId) {
        if (!_countryRepository.CountryExists(countryId)) 
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var country = _mapper.Map<CountryDto>(_countryRepository.GetCountry(countryId));

        return Ok(country);
    }

    [HttpGet("/owners/{ownerId}")]
    [ProducesResponseType(200, Type = typeof(Country))]
    [ProducesResponseType(400)]
    public IActionResult GetCountryOfAnOwner(int ownerId) {
        var country = _mapper.Map<CountryDto>(_countryRepository.GetCountryByOwner(ownerId));
        if (!ModelState.IsValid)
            return BadRequest();

        if (!_countryRepository.CountryExists(ownerId))
            return NotFound();

        return Ok(country);

    }





}

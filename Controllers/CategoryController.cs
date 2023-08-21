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
public class CategoryController : Controller{
    private readonly ICategory _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryController(ICategory categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
    public IActionResult GetCategories() {
        var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());

        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        return Ok(categories);
    }

    [HttpGet("{categoryId}")]
    [ProducesResponseType(200, Type = typeof(Category))]
    [ProducesResponseType(400)]
    public IActionResult GetCategory(int categoryId) {
        if (!_categoryRepository.CategoryExists(categoryId))
            return NotFound();

        var category = _mapper.Map<CategoryDto>(_categoryRepository.GetCategory(categoryId));
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(category);
    }

    [HttpGet("pokemon/{categoryId}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
    [ProducesResponseType(400)]

    public IActionResult GetPokeonByCategory(int categoryId) {

        var pokemons = _mapper
            .Map<List<PokemonDto>>(_categoryRepository
            .GetPokemonByCategory(categoryId));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(pokemons);
    }
    
}

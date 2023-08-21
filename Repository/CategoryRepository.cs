﻿using PokemonReviewApp2.Data;
using PokemonReviewApp2.Interface;
using PokemonReviewApp2.Models;

namespace PokemonReviewApp2.Repository;

public class CategoryRepository : ICategory {
    private readonly DataContext _context;

    public CategoryRepository(DataContext context)
    {
        _context = context;
    }
    public bool CategoryExists(int id) {
        return _context.Categories.Any(c => c.Id == id);
    }

    public ICollection<Category> GetCategories() {
        return _context.Categories.OrderBy(c => c.Name).ToList();
    }

    public Category GetCategory(int id) {
        return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
    }

    public ICollection<Pokemon> GetPokemonByCategory(int categoryId) {
        return _context
            .PokemonCategories
            .Where(e => e.CategoryId == categoryId)
            .Select(c => c.Pokemon)
            .ToList();
    }
}

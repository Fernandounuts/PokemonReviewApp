﻿using PokemonReviewApp2.Data;
using PokemonReviewApp2.Interface;
using PokemonReviewApp2.Models;

namespace PokemonReviewApp2.Repository;

public class OwnerRepository : IOwner {
    private readonly DataContext _context;

    public OwnerRepository(DataContext context)
    {
        _context = context;
    }

    public Owner GetOwner(int ownerId) {
        return _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
    }

    public ICollection<Owner> GetOwnerOfAPokemon(int pokeId) {
        return _context.PokemonOwners
            .Where(p => p.Pokemon.Id == pokeId)
            .Select(o => o.Owner)
            .ToList();
    }

    public ICollection<Owner> GetOwners() {
        return _context.Owners.ToList();
    }

    public ICollection<Pokemon> GetPokemonByOwner(int ownerId) {
        return _context.PokemonOwners
            .Where(p => p.Owner.Id == ownerId)
            .Select(p => p.Pokemon)
            .ToList();
    }

    public bool OwnerExists(int ownerId) {
        throw new NotImplementedException();
    }
}

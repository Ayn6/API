﻿using ass.Data;
using ass.Interface;
using ass.Models;
using AutoMapper;

namespace ass.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;
        public CountryRepository(DataContext context, IMapper mapper)
        {
            _context = context;
        }

        public bool CountryExists(int id)
        {
            return _context.Countries.Any(c => c.Id == id);
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromCountry(int countryId)
        {
            return _context.Owners.Where(c => c.Country.Id == countryId).ToList();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        public bool CreateCountry(Country country)
        {
            _context.Add(country);
            return Save();
        }
    }
}

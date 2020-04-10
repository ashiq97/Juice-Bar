using JuiceBar.Data.Interfaces;
using JuiceBar.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuiceBar.Data.Repositories
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly AppDbContext _context;
        public DrinkRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Drink> Drinks => _context.Drinks.Include(c => c.Category);

        public IEnumerable<Drink> PreferredDrinks 
        {
            get =>_context.Drinks.Where(p => p.IsPreferredDrink).Include(c => c.Category);
            set => throw new NotImplementedException(); 
        }

        public Drink GetDrinkById(int id)
        {
            return _context.Drinks.FirstOrDefault(p => p.DrinkId == id);
        }
    }
}

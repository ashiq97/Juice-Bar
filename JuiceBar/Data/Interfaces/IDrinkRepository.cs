using JuiceBar.Data.Models;
using System.Collections.Generic;

namespace JuiceBar.Data.Interfaces
{
    public interface IDrinkRepository
    {
        IEnumerable<Drink> Drinks { get; }
        IEnumerable<Drink> PreferredDrinks { get; set; }
        Drink GetDrinkById(int id);
    }
}

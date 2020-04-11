using JuiceBar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuiceBar.VIewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Drink> PreferredDrinks{ get; set; }
    }
}

using JuiceBar.Data.Interfaces;
using JuiceBar.Data.Models;
using JuiceBar.VIewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuiceBar.Controllers
{
    public class DrinkController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDrinkRepository _drinkRepository;
        public DrinkController(ICategoryRepository categoryRepository,IDrinkRepository drinkRepository)
        {
            _categoryRepository = categoryRepository;
            _drinkRepository = drinkRepository;
        }

        //public ViewResult List()
        //{
        //    //var drinks = _drinkRepository.Drinks;
        //    //return View(drinks);

        //    DrinkListViewModel vm = new DrinkListViewModel();
        //    vm.Drinks = _drinkRepository.Drinks;
        //    vm.CurrentCategory = "Drink Category";

        //    return View(vm);
        //}

        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Drink> drinks;
            string currentCategory = string.Empty;
            
            if (string.IsNullOrEmpty(category))
            {
                drinks = _drinkRepository.Drinks.OrderBy(n => n.CategoryId);
                currentCategory = "All drinks";
            }
            else
            {
                if (string.Equals("Alcoholic", _category, StringComparison.OrdinalIgnoreCase))
                {
                    drinks = _drinkRepository.Drinks.Where(p => p.Category.CategoryName.Equals("Alcoholic"));
                }
                else
                {
                    drinks = _drinkRepository.Drinks.Where(p => p.Category.CategoryName.Equals("Non-alcoholic"));
                }

                currentCategory = _category;
            }

            var drinkListViewModel = new DrinkListViewModel()
            {
                CurrentCategory = currentCategory,
                Drinks = drinks
            };

            return View(drinkListViewModel);

        }

    }
}

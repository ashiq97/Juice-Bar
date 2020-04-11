using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JuiceBar.Data.Interfaces;
using JuiceBar.VIewModels;
using Microsoft.AspNetCore.Mvc;

namespace JuiceBar.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDrinkRepository _drinkRepository;
        public HomeController(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel()
            {
                PreferredDrinks = _drinkRepository.PreferredDrinks
            };
            return View(homeViewModel);
        }
    }
}
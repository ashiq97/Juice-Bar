﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JuiceBar.Data.Interfaces;
using JuiceBar.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace JuiceBar.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;
        public OrderController(IOrderRepository orderRepository,ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }
        public IActionResult CheckOut()
        {
            return View();
        }
    }
}
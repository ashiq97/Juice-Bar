using System;
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

        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppigCartItems = items;

            if(_shoppingCart.ShoppigCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some drinks first");
            }
            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckOutComplete");
            }

            return View(order);
        }

        public IActionResult CheckOutComplete()
        {
            ViewBag.checkOutCompleteMessage = "Thank you for your order";
            return View();
        }

    }
}
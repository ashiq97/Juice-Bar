using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuiceBar.Data.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext _context;
        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }
        public string ShoppingCartId { get; set; }
        public List<ShoppigCartItem> ShoppigCartItems { get; set; }


        public static ShoppingCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var NewContext = service.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(NewContext) { ShoppingCartId = cartId };
        }

        // Add to Cart
        public void AddToCart(Drink drink, int amount)
        {
            var shoppingCartItem = _context.ShoppigCartItems.SingleOrDefault(
                                            s => s.Drink.DrinkId == drink.DrinkId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppigCartItem
                {
                    ShoppingCartId = this.ShoppingCartId,
                    Drink = drink,
                    Amount = 1
                };
                _context.ShoppigCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public int RemoveFromCart(Drink drink)
        {
            var shoppingCartItem = _context.ShoppigCartItems.SingleOrDefault(
                                s => s.Drink.DrinkId == drink.DrinkId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _context.ShoppigCartItems.Remove(shoppingCartItem);
                }
            }
            _context.SaveChanges();
            return localAmount;
        }

        public List<ShoppigCartItem> GetShoppingCartItems()
        {
            return ShoppigCartItems ??
                (ShoppigCartItems = _context.ShoppigCartItems
                                        .Where(c => c.ShoppingCartId == ShoppingCartId)
                                        .Include(s => s.Drink).ToList());
        }


        public void ClearCart()
        {
            var cartItems = _context.ShoppigCartItems
                                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _context.Remove(cartItems);
            _context.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _context.ShoppigCartItems
                            .Where(c => c.ShoppingCartId == ShoppingCartId)
                            .Select(c => c.Drink.Price * c.Amount)
                            .Sum();
            return total;

        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuiceBar.Data.Models
{
    public class ShoppigCartItem
    {
        public int ShoppigCartItemId { get; set; }
        public Drink Drink { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }

    }
}

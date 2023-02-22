

using AppShop.Extensions;
using AppShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppShop.Components
{
    public class CartViewComponent: ViewComponent
    {
        private Cart _cart;
        public CartViewComponent(Cart cart)
        {
            _cart = cart;
        }
        public IViewComponentResult Invoke()
        {
            
             return View(_cart);
        }
    }
}

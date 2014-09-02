using SportsStore.Domain.Entities;
using System;
using System.Web.Mvc;

namespace SportsStore.WebUI.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // Get the cart from the session
            Cart cart = (Cart)controllerContext.HttpContext.Session[sessionKey];

            // Create the Cart if there wasn't one in the session data
            if(cart == null)
            {
                cart = new Cart();
                controllerContext.HttpContext.Session[sessionKey] = cart;
            }

            // Return the cart
            return cart;
        }
    }
}
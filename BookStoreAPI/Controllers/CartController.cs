using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        ICartBL cartBL;
        public CartController(ICartBL cartBL)
        {
            this.cartBL = cartBL;
        }

        [HttpPost]
        public ActionResult AddBookToCart(CartModel cartModel)
        {
            try
            {
                string result = this.cartBL.AddBookToCart(cartModel);
                if(result.Equals("Book added to cart successfully"))
                {
                    return this.Ok(new { success = true, message = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = result});
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpPut]
        public ActionResult UpdateCart(int CartId, int OrderQuantity)
        {
            try
            {
                string result = this.cartBL.UpdateCart(CartId, OrderQuantity);
                if (result.Equals("Cart Updated successfully"))
                {
                    return this.Ok(new { success = true, message = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = result });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpDelete]
        public ActionResult DeleteCart(int CartId)
        {
            try
            {
                string result = this.cartBL.DeleteCart(CartId);
                if (result.Equals("Cart deleted successfully"))
                {
                    return this.Ok(new { success = true, message = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = result });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        public ActionResult GetCartData(int UserId)
        {
            try
            {
                var result = this.cartBL.GetCartData(UserId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "The Books in the cart are : ", response = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = result });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

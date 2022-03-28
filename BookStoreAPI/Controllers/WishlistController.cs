using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        IWishlistBL wishlistBL;
        public WishlistController(IWishlistBL wishlistBL)
        {
            this.wishlistBL = wishlistBL;
        }

        [HttpPost]
        public ActionResult AddBookToWishlist(WishlistModel wishlistModel)
        {
            try
            {
                string result = this.wishlistBL.AddBookToWishlist(wishlistModel);
                if (result.Equals("Book added to wishlist successfully"))
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
        public ActionResult DeleteWishlist(int WishlistId)
        {
            try
            {
                string result = this.wishlistBL.DeleteWishlist(WishlistId);
                if (result.Equals("Wishlist deleted successfully"))
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
        public ActionResult GetWishlistData(int UserId)
        {
            try
            {
                var result = this.wishlistBL.GetWishlistData(UserId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "The Books in the wishlist are : ", response = result });
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

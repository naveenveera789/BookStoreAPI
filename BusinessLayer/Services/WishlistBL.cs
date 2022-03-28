using BusinessLayer.Interfaces;
using ModelLayer.Services;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class WishlistBL : IWishlistBL
    {
        IWishlistRL wishlistRL;
        public WishlistBL(IWishlistRL wishlistRL)
        {
            this.wishlistRL = wishlistRL;
        }
        public string AddBookToWishlist(WishlistModel wishlistModel)
        {
            try
            {
                return this.wishlistRL.AddBookToWishlist(wishlistModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string DeleteWishlist(int WishlistId)
        {
            try
            {
                return this.wishlistRL.DeleteWishlist(WishlistId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<GetWishlistModel> GetWishlistData(int UserId)
        {
            try
            {
                return this.wishlistRL.GetWishlistData(UserId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

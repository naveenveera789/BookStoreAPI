using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IWishlistBL
    {
        string AddBookToWishlist(WishlistModel wishlistModel);
        string DeleteWishlist(int WishlistId);
        List<GetWishlistModel> GetWishlistData(int UserId);
    }
}

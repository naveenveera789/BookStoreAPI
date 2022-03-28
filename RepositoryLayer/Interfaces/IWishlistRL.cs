using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IWishlistRL
    {
        string AddBookToWishlist(WishlistModel wishlistModel);
        string DeleteWishlist(int WishlistId);
        List<GetWishlistModel> GetWishlistData(int UserId);
    }
}

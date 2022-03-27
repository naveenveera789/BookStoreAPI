using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface ICartBL
    {
        string AddBookToCart(CartModel cartModel);
        string UpdateCart(int CartId, int OrderQuantity);
        string DeleteCart(int CartId);
        List<GetCartModel> GetCartData(int UserId);
    }
}

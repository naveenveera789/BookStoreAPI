using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Services
{
    public class GetWishlistModel
    {
        public int WishlistId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public BookModel bookModel { get; set; } 
    }
}

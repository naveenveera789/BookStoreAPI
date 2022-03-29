using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Services
{
    public class OrderBookModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int DiscountPrice { get; set; }
        public int OriginalPrice { get; set; }
        public string Image { get; set; }
    }
}

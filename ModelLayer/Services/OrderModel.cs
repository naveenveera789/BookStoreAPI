using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Services
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public int BookId { get; set; }
        public int TotalPrice { get; set; }
        public int QuantityToBuy { get; set; }
        public string OrderPlaced { get; set; }
    }
}

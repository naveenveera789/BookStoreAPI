using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Services
{
    public class GetOrderModel
    {
        public int OrderId { get; set; }
        public string OrderPlaced { get; set; }
        public OrderBookModel orderBookModel { get; set; }
        
    }
}

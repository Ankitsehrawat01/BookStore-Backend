using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class GetOrderModel
    {
        public long OrderId { get; set; }
        public long Order_Quantity { get; set; }
        public string OrderDate { get; set; }
        public long TotalPrice { get; set; }
        public long BookId { get; set; }
        public long AddressId { get; set; }
        public long UserId { get; set; }
        
    }
}

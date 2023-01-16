using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class OrderModel
    {
        //public long CartId { get; set; }
        //public long AddressId { get; set; }
        //public long BookId { get; set; }


        public long OrderId { get; set; }
        public long UserId { get; set; }
        public long AddressId { get; set; }
        public long BookId { get; set; }
        public long Price { get; set; }
        public long BookQuantity { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}

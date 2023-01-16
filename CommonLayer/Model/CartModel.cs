using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class CartModel
    {
        public long BookId { get; set; }
        public long Book_Quantity { get; set; }
    }
    public class CartModel1
    {
        public long CartId { get; set; }
        public long BookId { get; set; }
        public long UserId { get; set; }
        public long Book_Quantity { get; set; }
        public string Book_Name { get; set; }
        public string Author_Name { get; set; }
        public long Price { get; set; }
        public long Discount_Price { get; set; }
        public string Book_Image { get; set; }
    }
}

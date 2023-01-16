using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class BookModel
    {
        [Key]
        public long BookId { get; set; }
        public string Book_Name { get; set; }
        public string Author_Name { get; set; }
        public long Price { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
        public long Rating_Count { get; set; }
        public long Discount_Price { get; set; }
        public long Book_Quantity { get; set; }
        public string Book_Image { get; set; }
    }
}

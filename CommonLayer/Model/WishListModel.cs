﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class WishListModel
    {
        public long WishlistId { get; set; }
        public long BookId { get; set; }
        public long UserId { get; set; }
    }
}

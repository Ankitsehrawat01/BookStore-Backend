using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IWishListBL
    {
        public bool AddWishList(long BookId, long UserId);
        public bool deleteWishList(long WishListId, long UserId);
        public IEnumerable<WishListModel> getWishList(long UserId);
    }
}

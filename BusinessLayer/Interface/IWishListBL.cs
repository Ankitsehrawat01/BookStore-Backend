using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IWishListBL
    {
        public WishListModel AddWishList(WishListModel wishlistmodel, long UserId);
        public bool deleteWishList(long WishListId, long UserId);
        public object getWishList(long UserId);
    }
}

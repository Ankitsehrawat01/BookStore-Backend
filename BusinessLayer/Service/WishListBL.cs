using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class WishListBL : IWishListBL
    {
        private readonly IWishListRL iwishListRL;
        public WishListBL(IWishListRL iwishListRL)
        {
            this.iwishListRL = iwishListRL;
        }
        public bool AddWishList(long BookId, long UserId)
        {
            try
            {
                return iwishListRL.AddWishList(BookId, UserId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool deleteWishList(long WishListId, long UserId)
        {
            try
            {
                return iwishListRL.deleteWishList(WishListId, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<WishListModel> getWishList(long UserId)
        {
            try
            {
                return iwishListRL.getWishList(UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

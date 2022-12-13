using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class CartBL : ICartBL
    {
        private readonly ICartRL icartRL;
        public CartBL(ICartRL icartRL)
        {
            this.icartRL = icartRL;
        }
        public CartModel addCart(CartModel cartModel, long UserId)
        {
            try
            {
                return icartRL.addCart(cartModel, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool removeCart(int CartId)
        {
            try
            {
                return icartRL.removeCart(CartId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<CartModel> getCart(long UserId)
        {
            try
            {
                return icartRL.getCart(UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public CartModel updateCart(long CartId, CartModel cartModel, long UserId)
        {
            try
            {
                return icartRL.updateCart(CartId, cartModel, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ICartBL
    {
        public CartModel addCart(CartModel cartModel, long UserId);
        public bool removeCart(int CartId);
        public IEnumerable<CartModel1> getCart(long UserId);
        public CartModel updateCart(long CartId, CartModel cartModel, long UserId);
        public object getCartById(long CartId);
    }
}

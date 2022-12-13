using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ICartRL
    {
        public CartModel addCart(CartModel cartModel, long UserId);
        public bool removeCart(int CartId);
        public IEnumerable<CartModel> getCart(long UserId);
        public CartModel updateCart(long CartId, CartModel cartModel, long UserId);
    }
}

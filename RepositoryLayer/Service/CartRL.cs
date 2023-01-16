using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Service
{
    public class CartRL : ICartRL
    {
        private readonly IConfiguration icofiguration;
        public CartRL(IConfiguration icofiguration)
        {
            this.icofiguration = icofiguration;
        }

        SqlDataReader rd;
        List<CartModel1> cartModel1 = new List<CartModel1>();

        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStoreDb;Integrated Security=True;");

        public CartModel addCart(CartModel cartModel, long UserId)
        {
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("Sp_AddtoCart", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookId ", cartModel.BookId);
                    cmd.Parameters.AddWithValue("@Book_Quantity ", cartModel.Book_Quantity);
                    cmd.Parameters.AddWithValue("@UserId ", UserId);

                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();

                    if (result != 0)
                    {
                        return cartModel;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool removeCart(int CartId)
        {
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("Sp_DeleteCart", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CartId ", CartId);


                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();

                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<CartModel1> getCart(long UserId)
        {
            try
            {
                using (con)
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("Sp_GetCart", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId ", UserId);
                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        cartModel1.Add(new CartModel1()
                        {
                            CartId = Convert.ToInt32(rd["CartId"]),
                            Book_Quantity = (long)rd["Book_Quantity"],
                            BookId = Convert.ToInt32(rd["BookId"]),
                            UserId = Convert.ToInt32(rd["UserId"]),
                            Book_Image = rd["Book_Image"].ToString(),
                            Author_Name = rd["Author_Name"].ToString(),
                            Price = Convert.ToInt32(rd["Price"]),
                            Discount_Price = Convert.ToInt32(rd["Discount_Price"]),
                            Book_Name = rd["Book_Name"].ToString(),


                        });
                    }
                    return cartModel1;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public CartModel updateCart(long CartId, CartModel cartModel, long UserId)
        {
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("Sp_UpdateCart", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CartId ", CartId);
                    cmd.Parameters.AddWithValue("@Book_Quantity ", cartModel.Book_Quantity);

                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();

                    if (result != 0)
                    {
                        return cartModel;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public object getCartById(long CartId)
        {
            using (con)
                try
                {
                    SqlCommand cmd = new SqlCommand("Sp_GetCartbyId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CartId", CartId);
                    con.Open();
                    CartModel1 cartModel1 = new CartModel1();
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            cartModel1.CartId = Convert.ToInt32(rd["CartId"]);
                            cartModel1.Book_Name = rd["Book_Name"].ToString();
                            cartModel1.Author_Name = rd["Author_Name"].ToString();
                            cartModel1.Price = Convert.ToInt32(rd["Price"]);
                            cartModel1.Discount_Price = Convert.ToInt32(rd["Discount_Price"]);
                            cartModel1.Book_Quantity = Convert.ToInt32(rd["Book_Quantity"]);
                            cartModel1.Book_Image = rd["Book_Image"].ToString();
                        }
                        return cartModel1;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
        }
    }
}

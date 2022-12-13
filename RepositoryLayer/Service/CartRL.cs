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
        public IEnumerable<CartModel> getCart(long UserId)
        {
            List<CartModel> cartModel = new List<CartModel>();
            try
            {
                using (con)
                {
                    con.Open();

                    String query = "SELECT CartId, Book_Quantity, BookId FROM CartTable WHERE UserId = '" + UserId + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        cartModel.Add(new CartModel()
                        {
                            BookId = (long)rd["BookId"],
                            Book_Quantity = (long)rd["Book_Quantity"]


                        });
                    }
                    return cartModel;
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

    }
}

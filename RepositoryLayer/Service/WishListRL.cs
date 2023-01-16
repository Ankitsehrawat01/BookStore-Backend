using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Text;

namespace RepositoryLayer.Service
{
    public class WishListRL : IWishListRL
    {
        private readonly IConfiguration iconfiguration;

        public WishListRL(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
        }

        SqlDataReader sqlDataReader;
        List<WishListModel> wishlist = new List<WishListModel>();
        List<WishListModel1> wishlist1 = new List<WishListModel1>();

        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStoreDb;Integrated Security=True;");

        public bool AddWishList(long BookId, long UserId)
        {
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("AddWishList", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookId ", BookId);
                    cmd.Parameters.AddWithValue("@UserId ", UserId);

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
            catch (Exception)
            {

                throw;
            }
        }
        public bool deleteWishList(long WishListId, long UserId)
        {
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("Sp_DeleteWishList", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@WishListId ", WishListId);
                    cmd.Parameters.AddWithValue("@UserId ", UserId);

                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();

                    if (result > 0)
                    {
                        return true ;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<WishListModel> getWishList(long UserId)
        {
            using (con)
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("Sp_GetWishList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId ", UserId);
                    sqlDataReader = cmd.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        wishlist.Add(new WishListModel()
                        {
                            WishListId = Convert.ToInt32(sqlDataReader["WishListId"]),
                            BookId = Convert.ToInt32(sqlDataReader["BookId"]),
                            UserId = Convert.ToInt32(sqlDataReader["UserId"]),
                            Book_Image = sqlDataReader["Book_Image"].ToString(),
                            Author_Name = sqlDataReader["Author_Name"].ToString(),
                            Price = Convert.ToInt32(sqlDataReader["Price"]),
                            Discount_Price = Convert.ToInt32(sqlDataReader["Discount_Price"]),
                            Book_Name = sqlDataReader["Book_Name"].ToString(),

                        });
                    }
                    return wishlist;
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
    }
}

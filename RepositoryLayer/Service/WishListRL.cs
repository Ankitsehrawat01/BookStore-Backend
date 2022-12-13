using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

                    if (result != 0)
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

                    if (result != 0)
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
        public object getWishList(long UserId)
        {
            using (con)
                try
                {
                    SqlCommand cmd = new SqlCommand("Sp_GetWishList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    con.Open();
                    WishListModel wishListModel = new WishListModel();
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            wishListModel.WishlistId = Convert.ToInt32(rd["WishlistId"]);
                            wishListModel.BookId = Convert.ToInt32(rd["BookId"]);
                            wishListModel.UserId = Convert.ToInt32(rd["UserId"]);
                        }
                        return wishListModel;
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
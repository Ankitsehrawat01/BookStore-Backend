using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CommonLayer.Model;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Service
{
    public class OrderRL : IOrderRL
    {
        private readonly IConfiguration iconfiguration;
        public OrderRL(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
        }
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStoreDb;Integrated Security=True;");
        public OrderModel addOrder(OrderModel orderModel, long UserId)
        {
            using (con)
                try
                {

                    SqlCommand cmd = new SqlCommand("Sp_AddOrder", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    //cmd.Parameters.AddWithValue("@CartId", orderModel.CartId);
                    cmd.Parameters.AddWithValue("@AddressId", orderModel.AddressId);
                    //cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@BookId", orderModel.BookId);
                    cmd.Parameters.AddWithValue("@BookQuantity", orderModel.BookQuantity);

                    var result = cmd.ExecuteNonQuery();

                    if (result != 0)
                    {
                        return orderModel;
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
                finally
                {
                    con.Close();
                }
        }
        public bool CancelOrder(long OrderId)
        {
            using (con)
                try
                {
                    SqlCommand cmd = new SqlCommand("Sp_DeleteOrder", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    con.Open();
                    cmd.Parameters.AddWithValue("@OrderId", OrderId);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
        public IEnumerable<GetOrderModel> GetAllOrders()
        {
            List<GetOrderModel> orderModel = new List<GetOrderModel>();
            using (con)
                try
                {
                    con.Open();
                    String query = "SELECT OrderId, Order_Quantity, AddressId, BookId, UserId, TotalPrice, OrderDate FROM OrderTable";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        orderModel.Add(new GetOrderModel()
                        {
                            OrderId = (long)rd["OrderId"],
                            Order_Quantity = (long)rd["Order_Quantity"],
                            AddressId = (long)rd["AddressId"],
                            BookId = (long)rd["BookId"],
                            UserId = (long)rd["UserId"],
                            TotalPrice = (long)rd["TotalPrice"],
                            OrderDate = rd["OrderDate"].ToString()
                        });
                    }
                    return orderModel;
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

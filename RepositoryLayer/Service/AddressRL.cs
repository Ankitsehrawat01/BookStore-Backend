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
    public class AddressRL : IAddressRL
    {
        private readonly IConfiguration iconfiguration;
        public AddressRL(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
        }

        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStoreDb;Integrated Security=True;");

        public AddressModel addAddress(AddressModel addressModel, long UserId)
        {
            using (con)
                try
                {

                    SqlCommand cmd = new SqlCommand("Sp_AddAddress", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    cmd.Parameters.AddWithValue("@Address", addressModel.Address);
                    cmd.Parameters.AddWithValue("@City", addressModel.City);
                    cmd.Parameters.AddWithValue("@State", addressModel.State);
                    cmd.Parameters.AddWithValue("@TypeId", addressModel.TypeId);
                    cmd.Parameters.AddWithValue("@UserId", UserId);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return addressModel;
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
        public AddressModel updateAddress(AddressModel addressModel, long AddressId, long UserId)
        {
            using (con)
                try
                {
                    SqlCommand cmd = new SqlCommand("Sp_UpdateAddres", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    cmd.Parameters.AddWithValue("@Address", addressModel.Address);
                    cmd.Parameters.AddWithValue("@City", addressModel.City);
                    cmd.Parameters.AddWithValue("@State", addressModel.State);
                    cmd.Parameters.AddWithValue("@AddressId", AddressId);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return addressModel;
                    }
                    else
                    {
                        return addressModel;
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
        public IEnumerable<AddressModel> getAddress(long UserId)
        {
            using (con)
                try
                {
                    con.Open();
                    String query = "SELECT AddressId, Address, City, State, TypeId FROM AddressTable WHERE UserId = '" + UserId + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    List<AddressModel> address = new List<AddressModel>();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        address.Add(new AddressModel()
                        {
                            AddressId = (long)rd["AddressId"],
                            Address = rd["Address"].ToString(),
                            City = rd["City"].ToString(),
                            State = rd["State"].ToString(),
                            TypeId = (long)rd["TypeId"]
                        });
                    }
                    return address;
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
        public bool removeAddress(long AddressId)
        {
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("Sp_DeleteAddress", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AddressId ", AddressId);
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

    }
}

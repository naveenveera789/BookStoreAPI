using Microsoft.Extensions.Configuration;
using ModelLayer.Services;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class AddressRL : IAddressRL
    {
        private SqlConnection con;
        private readonly IConfiguration configuration;
        public AddressRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string AddAddress(AddressModel addressModel)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("AddAddress", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", addressModel.UserId);
                    cmd.Parameters.AddWithValue("@Address", addressModel.Address);
                    cmd.Parameters.AddWithValue("@City", addressModel.City);
                    cmd.Parameters.AddWithValue("@State", addressModel.State);
                    cmd.Parameters.AddWithValue("@TypeId", addressModel.TypeId);
                    con.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result != 1)
                    {
                        return "Address added successfully";
                    }
                    else
                    {
                        return "Address is not added";
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }

        public List<AddressModel> GetAddressById(int UserId)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    List<AddressModel> address = new List<AddressModel>();
                    SqlCommand cmd = new SqlCommand("GetAddressById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            AddressModel addressModel = new AddressModel();
                            addressModel.AddressId = Convert.ToInt32(dr["AddressId"]);
                            addressModel.UserId = Convert.ToInt32(dr["UserId"]);
                            addressModel.Address = dr["Address"].ToString();
                            addressModel.City = dr["City"].ToString();
                            addressModel.State = dr["State"].ToString();
                            addressModel.TypeId = Convert.ToInt32(dr["TypeId"]);
                            address.Add(addressModel);
                        }
                        return address;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }

        public List<AddressModel> GetAllAddress()
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    List<AddressModel> address = new List<AddressModel>();
                    SqlCommand cmd = new SqlCommand("GetAllAddress", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            AddressModel addressModel = new AddressModel();
                            addressModel.AddressId = Convert.ToInt32(dr["AddressId"]);
                            addressModel.UserId = Convert.ToInt32(dr["UserId"]);
                            addressModel.Address = dr["Address"].ToString();
                            addressModel.City = dr["City"].ToString();
                            addressModel.State = dr["State"].ToString();
                            addressModel.TypeId = Convert.ToInt32(dr["TypeId"]);
                            address.Add(addressModel);
                        }
                        return address;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }

        public string UpdateAddress(AddressModel addressModel)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("UpdateAddress", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AddressId", addressModel.AddressId);
                    cmd.Parameters.AddWithValue("@Address", addressModel.Address);
                    cmd.Parameters.AddWithValue("@City", addressModel.City);
                    cmd.Parameters.AddWithValue("@State", addressModel.State);
                    cmd.Parameters.AddWithValue("@TypeId", addressModel.TypeId);
                    con.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result != 1)
                    {
                        return "Address updated successfully";
                    }
                    else
                    {
                        return "Address is not updated";
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }

        public string DeleteAddress(int AddressId)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("DeleteAddress", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AddressId", AddressId);
                    con.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result != 1)
                    {
                        return "Address deleted successfully";
                    }
                    else
                    {
                        return "Address is not deleted";
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }
    }
}

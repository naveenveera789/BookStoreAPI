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
    public class OrderRL :IOrderRL
    {
        private SqlConnection con;
        private readonly IConfiguration configuration;
        public OrderRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string AddOrder(OrderModel orderModel)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("AddOrder", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", orderModel.UserId);
                    cmd.Parameters.AddWithValue("@AddressId", orderModel.AddressId);
                    cmd.Parameters.AddWithValue("@BookId", orderModel.BookId);
                    cmd.Parameters.AddWithValue("@QuantityToBuy", orderModel.QuantityToBuy);
                    con.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result == 2)
                    {
                        return "Invalid BookId";
                    }
                    else if (result == 1)
                    {
                        return "Invalid UserId";
                    }
                    else
                    {
                        return "Order is placed successfully";
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

        public List<GetOrderModel> GetAllOrders(int UserId)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    List<GetOrderModel> order = new List<GetOrderModel>();
                    SqlCommand cmd = new SqlCommand("GetAllOrders", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            GetOrderModel orderModel = new GetOrderModel();
                            OrderBookModel orderBookModel = new OrderBookModel();
                            orderModel.OrderId = Convert.ToInt32(dr["OrderId"]);
                            orderModel.OrderPlaced = dr["OrderPlaced"].ToString();
                            orderBookModel.BookId = Convert.ToInt32(dr["BookId"]);
                            orderBookModel.BookName = dr["BookName"].ToString();
                            orderBookModel.AuthorName = dr["AuthorName"].ToString();
                            orderBookModel.DiscountPrice = Convert.ToInt32(dr["DiscountPrice"]);
                            orderBookModel.OriginalPrice = Convert.ToInt32(dr["OriginalPrice"]);
                            orderBookModel.Image = dr["Image"].ToString();
                            orderModel.orderBookModel = orderBookModel;
                            order.Add(orderModel);
                        }
                        return order;
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

        public string DeleteOrder(int OrderId)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("DeleteOrder", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderId", OrderId);
                    con.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result != 1)
                    {
                        return "Order cancelled successfully";
                    }
                    else
                    {
                        return "Order is not cancelled";
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

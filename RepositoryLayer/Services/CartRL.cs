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
    public class CartRL : ICartRL
    {
        private SqlConnection con;
        private readonly IConfiguration configuration;
        public CartRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string AddBookToCart(CartModel cartModel)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using(con)
                {
                    SqlCommand cmd = new SqlCommand("AddBookToCart", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", cartModel.UserId);
                    cmd.Parameters.AddWithValue("@BookId", cartModel.BookId);
                    cmd.Parameters.AddWithValue("@OrderQuantity", cartModel.OrderQuantity);
                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    if(result != 0)
                    {
                        return "Book added to cart successfully";
                    }
                    else
                    {
                        return "Book is not added to cart";
                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }

        public string UpdateCart(int CartId, int OrderQuantity)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("UpdateCart", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CartId", CartId);
                    cmd.Parameters.AddWithValue("@OrderQuantity", OrderQuantity);
                    con.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if(result != 1)
                    {
                        return "Cart Updated successfully";
                    }
                    else
                    {
                        return "Cart is not updated";
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

        public string DeleteCart(int CartId)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("DeleteCart", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CartId", CartId);
                    con.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result != 1)
                    {
                        return "Cart deleted successfully";
                    }
                    else
                    {
                        return "Cart is not deleted";
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

        public List<GetCartModel> GetCartData(int UserId)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    List<GetCartModel> cart = new List<GetCartModel>();
                    SqlCommand cmd = new SqlCommand("GetCart", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if(dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            GetCartModel cartModel = new GetCartModel();
                            BookModel bookModel = new BookModel();
                            bookModel.BookName = dr["BookName"].ToString();
                            bookModel.AuthorName = dr["AuthorName"].ToString();
                            bookModel.DiscountPrice = Convert.ToInt32(dr["DiscountPrice"]);
                            bookModel.OriginalPrice = Convert.ToInt32(dr["OriginalPrice"]);
                            bookModel.BookDescription = dr["BookDescription"].ToString();
                            bookModel.Rating = Convert.ToDouble(dr["Rating"]);
                            bookModel.Image = dr["Image"].ToString();
                            bookModel.ReviewCount = Convert.ToInt32(dr["ReviewCount"]);
                            bookModel.BookCount = Convert.ToInt32(dr["BookCount"]);
                            cartModel.CartId = Convert.ToInt32(dr["CartId"]);
                            cartModel.UserId = Convert.ToInt32(dr["UserId"]);
                            cartModel.BookId = Convert.ToInt32(dr["BookId"]);
                            cartModel.OrderQuantity = Convert.ToInt32(dr["OrderQuantity"]);
                            cartModel.bookModel = bookModel;
                            cart.Add(cartModel);
                        }
                        return cart;
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
    }
}

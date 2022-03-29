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
    public class FeedbackRL : IFeedbackRL
    {
        private SqlConnection con;
        private readonly IConfiguration configuration;
        public FeedbackRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string AddFeedback(FeedbackModel feedbackModel)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("AddFeedback", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", feedbackModel.UserId);
                    cmd.Parameters.AddWithValue("@BookId", feedbackModel.BookId);
                    cmd.Parameters.AddWithValue("@Comments", feedbackModel.Comments);
                    cmd.Parameters.AddWithValue("@OverallRating", feedbackModel.OverallRating);
                    con.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result == 2)
                    {
                        return "Invalid BookId";
                    }
                    else if (result == 1)
                    {
                        return "Already Feedback is given for this book";
                    }
                    else
                    {
                        return "Feedback added successfully";
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

        public List<GetFeedbackModel> GetFeedback(int BookId)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    List<GetFeedbackModel> feedback = new List<GetFeedbackModel>();
                    SqlCommand cmd = new SqlCommand("GetFeedback", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", BookId);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            GetFeedbackModel feedbackModel = new GetFeedbackModel();
                            FeedbackUserDetails details = new FeedbackUserDetails();
                            feedbackModel.FeedbackId = Convert.ToInt32(dr["FeedbackId"]);
                            feedbackModel.UserId = Convert.ToInt32(dr["UserId"]);
                            feedbackModel.BookId = Convert.ToInt32(dr["BookId"]);
                            feedbackModel.Comments = dr["Comments"].ToString();
                            feedbackModel.OverallRating = Convert.ToInt32(dr["Overallrating"]);
                            details.FullName = dr["FullName"].ToString();
                            details.EmailId = dr["EmailId"].ToString();
                            feedbackModel.details = details;
                            feedback.Add(feedbackModel);
                        }
                        return feedback;
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

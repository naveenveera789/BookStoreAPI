using BusinessLayer.Interfaces;
using ModelLayer.Services;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class FeedbackBL : IFeedbackBL
    {
        IFeedbackRL feedbackRL;
        public FeedbackBL(IFeedbackRL feedbackRL)
        {
            this.feedbackRL = feedbackRL;
        }

        public string AddFeedback(FeedbackModel feedbackModel)
        {
            try
            {
                return this.feedbackRL.AddFeedback(feedbackModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<GetFeedbackModel> GetFeedback(int BookId)
        {
            try
            {
                return this.feedbackRL.GetFeedback(BookId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IFeedbackBL
    {
        string AddFeedback(FeedbackModel feedbackModel);
        List<GetFeedbackModel> GetFeedback(int BookId);
    }
}

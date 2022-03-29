using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IFeedbackRL
    {
        string AddFeedback(FeedbackModel feedbackModel);
        List<GetFeedbackModel> GetFeedback(int BookId);
    }
}

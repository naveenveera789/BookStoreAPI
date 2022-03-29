using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        IFeedbackBL feedbackBL;
        public FeedbackController(IFeedbackBL feedbackBL)
        {
            this.feedbackBL = feedbackBL;
        }

        [HttpPost]
        public ActionResult AddFeedback(FeedbackModel feedbackModel)
        {
            try
            {
                string result = this.feedbackBL.AddFeedback(feedbackModel);
                if (result.Equals("Feedback added successfully"))
                {
                    return this.Ok(new { success = true, message = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = result });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        public ActionResult GetFeedback(int BookId)
        {
            try
            {
                var result = this.feedbackBL.GetFeedback(BookId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "The Feedback for the BookId is : ", response = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = result });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

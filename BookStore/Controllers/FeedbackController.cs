using BusinessLayer.Interface;
using CommonLayer.Model;
using Experimental.System.Messaging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackBL iFeedbackBL;
        public FeedbackController(IFeedbackBL iFeedbackBL)
        {
            this.iFeedbackBL = iFeedbackBL;
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult addFeedback(FeedbackModel feedbackModel)
        {
            long UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

            var response = iFeedbackBL.addFeedback(feedbackModel, UserId);
            if(response != null)
            {
                return Ok(new { success = true, Message = "Feedback Added", data = response} );
            }
            else
            {
                return BadRequest(new { success = false, message = "Feedback Not Added", data = response });
            }
        }
        [Authorize]
        [HttpGet]
        [Route("Get")]
        public IActionResult getFeedback(long UserId)
        {
            try
            {
                int UserID = Convert.ToInt32(User.Claims.FirstOrDefault(g => g.Type == "UserId").Value);
                var result = iFeedbackBL.getFeedback(UserId);

                if (result != null)
                {
                    return Ok(new { Success = true, Message = " Get Feedback Successful ", Data = result });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Get Feedback Unsuccessful " });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}

using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IFeedbackBL
    {
        public bool addFeedback(FeedbackModel feedbackModel, long UserId);
        public IEnumerable<FeedbackModel> getFeedback(long UserId);
    }
}

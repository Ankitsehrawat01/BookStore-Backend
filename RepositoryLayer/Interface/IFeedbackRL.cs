using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IFeedbackRL
    {
        public bool addFeedback(FeedbackModel feedbackModel, long UserId);
        public IEnumerable<FeedbackModel> getFeedback(long UserId);
    }
}

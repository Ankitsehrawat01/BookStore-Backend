using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class FeedbackBL : IFeedbackBL
    {
        private readonly IFeedbackRL iFeedbackRL;
        public FeedbackBL(IFeedbackRL iFeedbackRL)
        {
            this.iFeedbackRL = iFeedbackRL;
        }
        public bool addFeedback(FeedbackModel feedbackModel, long UserId)
        {
            try
            {
                return iFeedbackRL.addFeedback(feedbackModel, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<FeedbackModel> getFeedback(long UserId)
        {
            try
            {
                return iFeedbackRL.getFeedback(UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

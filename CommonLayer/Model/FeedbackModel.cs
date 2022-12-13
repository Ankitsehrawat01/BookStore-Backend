using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class FeedbackModel
    {
        public long FeedbackId { get; set; }
        public long Rating { get; set; }
        public string Comment { get; set; }
        public long BookId { get; set; }
    }
}

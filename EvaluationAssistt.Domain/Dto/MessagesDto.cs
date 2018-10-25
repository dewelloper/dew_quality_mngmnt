using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Domain.Dto
{
    public class MessagesDto
    {
        public int MessageId { get; set; }

        public int FromId { get; set; }

        public string Sender { get; set; }

        public int ToId { get; set; }

        public string To { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }

        public bool IsRead { get; set; }
    }
}

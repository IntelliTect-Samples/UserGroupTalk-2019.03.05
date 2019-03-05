using System;
using System.Collections.Generic;
using System.Text;

namespace UserGroupSite.Domain.Models
{
    public class EventSpeaker
    {
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int SpeakerId { get; set; }
        public Speaker Speaker { get; set; }
    }
}

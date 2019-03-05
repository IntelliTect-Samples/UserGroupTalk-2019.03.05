using System;
using System.Collections.Generic;
using System.Text;

namespace UserGroupSite.Domain.Models
{
    public class Event : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public ICollection<EventSpeaker> EventSpeakers { get; set; }
    }
}

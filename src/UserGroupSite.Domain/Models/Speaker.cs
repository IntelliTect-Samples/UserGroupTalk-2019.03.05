using System;
using System.Collections.Generic;
using System.Text;

namespace UserGroupSite.Domain.Models
{
    public class Speaker : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Bio { get; set; }
        public ICollection<EventSpeaker> SpeakerEvents { get; set; }
    }
}

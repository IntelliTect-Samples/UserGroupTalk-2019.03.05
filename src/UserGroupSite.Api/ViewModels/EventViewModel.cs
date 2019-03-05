using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserGroupSite.Api.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public int LocationId { get; set; }
        public LocationViewModel Location { get; set; }
        public ICollection<SpeakerViewModel> Speakers { get; set; }
    }
}

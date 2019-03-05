using System;
using System.Collections.Generic;
using System.Text;

namespace UserGroupSite.Domain.Models
{
    public class Location : Entity
    {
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}

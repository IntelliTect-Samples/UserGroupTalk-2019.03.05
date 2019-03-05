using System;
using System.Collections.Generic;
using System.Text;
using UserGroupSite.Domain.Interfaces;

namespace UserGroupSite.Domain.Models
{
    public class Entity : IEntity
    {
        public int Id { get; set; }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserGroupSite.Api.ViewModels;
using UserGroupSite.Domain.Models;

namespace UserGroupSite.Api.Models
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<Event, EventViewModel>()
                .ForMember(evm => evm.Speakers, opt => opt.MapFrom(e => e.EventSpeakers.Select(es => es.Speaker)));
            CreateMap<EventInputViewModel, Event>();

            CreateMap<Speaker, SpeakerViewModel>();
            CreateMap<SpeakerInputViewModel, Speaker>();

            CreateMap<Location, LocationViewModel>();
            CreateMap<LocationInputViewModel, Location>();
        }
    }
}

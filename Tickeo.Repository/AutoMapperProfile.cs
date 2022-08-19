using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tickeo.Core.DTOs;
using Tickeo.Core.Entities;

namespace Tickeo.Repository
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Event, TickeoEventResponseItem>().ForMember(dest=> dest.Status , opt=>opt.MapFrom(src => src.Status));
            CreateMap<EventTicket, EventTicketDto>();
        }
    }
}

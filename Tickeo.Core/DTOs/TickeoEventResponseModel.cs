using System;
using System.Collections.Generic;
using System.Text;

namespace Tickeo.Core.DTOs
{
    public class TickeoEventResponseModel : BaseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Address EventAddress { get; set; }
        public string Creator { get; set; }
        public string Category { get; set; }
        public string Thumbnail { get; set; }
        public string FullImage { get; set; }
        public string Status { get; set; }
        public string Direction { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Timezone { get; set; }

        public string Type { get; set; }
        public List<EventTicketDto> ListOfTickets { get; set; }
        public string Likes { get; set; }

    }

    public class TickeoEventResponseItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Address EventAddress { get; set; }
        public string Creator { get; set; }
        public string Category { get; set; }
        public string Thumbnail { get; set; }
        public string FullImage { get; set; }
        public string Status { get; set; }
        public string Direction { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Timezone { get; set; }

        public string Type { get; set; }
        public List<EventTicketDto> ListOfTickets { get; set; }
        public string Likes { get; set; }

    }
    public class TickeoEventResponseList : BaseResponse
    {
        public List<TickeoEventResponseItem> TickeoEvents { get; set; }
    }
}

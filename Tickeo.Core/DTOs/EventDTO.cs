using System;
using System.Collections.Generic;
using System.Text;

namespace Tickeo.Core.DTOs
{
    public class EventDTO
    {
        public string Name { get; set; }
        public string AddressStreet { get; set; }
        public string AddressState { get; set; }
        public string AddressCountry { get; set; }
        public string AddressLatitude { get; set; }
        public string AddressLongitude { get; set; }
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
    }

    public class Address
    {
        public string AddressStreet { get; set; }
        public string AddressState { get; set; }
        public string AddressCountry { get; set; }
        public string AddressLatitude { get; set; }
        public string AddressLongitude { get; set; }
    }
}

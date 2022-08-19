using System;
using System.Collections.Generic;
using System.Text;

namespace Tickeo.Core.DTOs
{
    public class MintTicketReq
    {
        public string token_name { get; set; }
        public string token_symbol { get; set; }
        public string ticket_uri { get; set; }
        public int token_number { get; set; }
        public int token_price { get; set; }
        public long event_endtime { get; set; }
        public string proxy { get; set; }
    }
}

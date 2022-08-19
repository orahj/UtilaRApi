using System;
using System.Collections.Generic;
using System.Text;

namespace Tickeo.Core.DTOs
{
    public class MintTicketRes
    {
        public int code { get; set; }
        public MintTicketResult result { get; set; }
        public int version { get; set; }
    }

    public class MintTicketResult
    {
        public string Owner { get; set; }
        public int TokenId { get; set; }
        public string TicketToken { get; set; }
    }
}

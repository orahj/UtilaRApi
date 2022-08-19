using System;
using System.Collections.Generic;
using System.Text;

namespace Tickeo.Core.DTOs
{
    public class PurchaseTicketRes
    {
        public int code { get; set; }
        public PurchaseTicketResult result { get; set; }
        public int version { get; set; }
    }

    public class PurchaseTicketResult
    {
        public string Buyer { get; set; }
        public int Amount { get; set; }
    }
}

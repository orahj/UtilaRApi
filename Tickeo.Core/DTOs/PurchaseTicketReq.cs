using System;
using System.Collections.Generic;
using System.Text;

namespace Tickeo.Core.DTOs
{
    public class PurchaseTicketReq
    {
        public string ticket_contract_address { get; set; }
        public int number_of_ticket { get; set; }

    }
}

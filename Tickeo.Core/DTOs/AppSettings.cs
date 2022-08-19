using System;
using System.Collections.Generic;
using System.Text;

namespace Tickeo.Core.DTOs
{
    public class AppSettings
    {
        public string EmailUrl { get; set; }
        public string SMTP { get; set; }
        public int Port { get; set; }
        public string FromEmail { get; set; }
        public string FromPassword { get; set; }
        public string BlockChainBaseUrl { get; set; }
    }
}

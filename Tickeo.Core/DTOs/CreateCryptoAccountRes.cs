using System;
using System.Collections.Generic;
using System.Text;

namespace Tickeo.Core.DTOs
{
    public class CreateCryptoAccountRes
    {
        public int code { get; set; }
        public CreateCryptoAccountResult result { get; set; }
        public int version { get; set; }
    }

    public class CreateCryptoAccountResult
    {
        public string ID { get; set; }
        public string proxyAddress { get; set; }
    }
}

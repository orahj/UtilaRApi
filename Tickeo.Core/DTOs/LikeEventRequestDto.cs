using System;
using System.Collections.Generic;
using System.Text;

namespace Tickeo.Core.DTOs
{
    public  class LikeEventRequestDto
    {
        public string UserId { get; set; }
        public string EventId { get; set; }
    }
}

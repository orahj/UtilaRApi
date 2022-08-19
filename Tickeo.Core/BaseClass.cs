using System;
using System.Collections.Generic;
using System.Text;

namespace Tickeo.Core
{
   public class BaseClass
    {
        public BaseClass()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}

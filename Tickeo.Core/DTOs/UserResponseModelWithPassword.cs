using System;
using System.Collections.Generic;
using System.Text;

namespace Tickeo.Core.DTOs
{
    public class UserResponseModelWithPassword:UserResponseModel
    {
        public string Password { get; set; }
    }
}

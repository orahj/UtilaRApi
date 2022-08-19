using System;
using System.Collections.Generic;
using System.Text;

namespace Tickeo.Core.DTOs
{
   public  class UserResponseModel:BaseResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        // public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ProgressLevel { get; set; }
        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string ReferralCode { get; set; }
        public string TempTestRef { get; set; }
        public List<UserEvent> UserEvents { get; set; }

    }
}

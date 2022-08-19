using System;
using System.Collections.Generic;
using System.Text;

namespace Tickeo.Core.DTOs
{
    public class UserDto
    {
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string AccountNumber { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string ProgressLevel { get; set; }
        public string UserName { get; set; }
        public string PreferredName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Nationality { get; set; }
        public string Gender { get; set; }
        public string Title { get; set; }
        public string AccountType { get; set; }

        public string MaritalStatus { get; set; }
        public string Occupation { get; set; }
        public string Hobby { get; set; }
        public string ReferralCode { get; set; }
        //public string NOKFirstName { get; set; }
        //public string NOKMiddleName { get; set; }
        //public string NOKLastName { get; set; }
        //public string NOKAddress { get; set; }
        //public string NOKPhoneNumber { get; set; }
        //public string NOKRelationship { get; set; }
        //public string NOKFullName { get; set; }
        public string SessionKey { get; set; }
        public bool IsDefaultPassword { get; set; }
    }
}

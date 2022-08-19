using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tickeo.Core.DTOs
{
    public class AddUserWithEmailRequestDto
    {
       
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        public string MiddleName { get; set; }
      
    }
}

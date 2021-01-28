using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace todo_core_webapi.Models
{
    public class AuthenticationRequest
    {
        [Required]
        public string VUserId { get; set; }
        [Required]
        public string VPassword { get; set; }
    }
}

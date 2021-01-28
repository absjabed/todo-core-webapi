using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace todo_core_webapi.Models
{
    public class UserRegistrationModel
    {
        public string VUserId { get; set; }
        public string VPassword { get; set; }
        public string VFullName { get; set; }
        public DateTime? DDateOfBirth { get; set; }
    }
}

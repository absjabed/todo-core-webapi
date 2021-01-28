using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace todo_core_webapi.Dtos
{
    public class UserInfoTableDto
    {
        public int IAutoId { get; set; }
        public string VUserId { get; set; }
        [JsonIgnore]
        public string VPassword { get; set; }
        public string VFullName { get; set; }
        public DateTime? DDateOfBirth { get; set; }
        public bool? BIsActive { get; set; }
    }
}

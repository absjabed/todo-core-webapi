using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using todo_core_webapi.Dtos;

namespace todo_core_webapi.Models
{
    public class AuthenticationResponse
    {
        public Boolean isAuthenticated { get; set; }
        public Boolean isRegistrationSucceed { get; set; }
        public string vMessage { get; set; }
        public UserInfoTableDto userObj {get; set;}
    }
}

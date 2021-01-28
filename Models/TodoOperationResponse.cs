using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace todo_core_webapi.Models
{
    public class TodoOperationResponse
    {
        public Boolean isSucceeed { get; set; }
        public string vMessage { get; set; }
    }
}

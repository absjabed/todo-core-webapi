using System;
using System.Collections.Generic;

namespace todo_core_webapi.Entities
{
    public partial class UserInfoTable
    {
        public UserInfoTable()
        {
            TodoTable = new HashSet<TodoTable>();
        }

        public int IAutoId { get; set; }
        public string VUserId { get; set; }
        public string VPassword { get; set; }
        public string VFullName { get; set; }
        public DateTime? DDateOfBirth { get; set; }
        public bool? BIsActive { get; set; }

        public virtual ICollection<TodoTable> TodoTable { get; set; }
    }
}

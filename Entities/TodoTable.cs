using System;
using System.Collections.Generic;

namespace todo_core_webapi.Entities
{
    public partial class TodoTable
    {
        public int IAutoId { get; set; }
        public string VUserId { get; set; }
        public string VTodoId { get; set; }
        public string VTodoTitle { get; set; }
        public string VTodoDescription { get; set; }
        public DateTime? DDate { get; set; }
        public string TTime { get; set; }
        public string VLocation { get; set; }
        public string TNotifyTime { get; set; }
        public string VColorLabel { get; set; }
        public bool? BIsDone { get; set; }
        public bool? BIsDeleted { get; set; }
        public DateTime? DDateOfEntry { get; set; }

        public virtual UserInfoTable VUser { get; set; }
    }
}

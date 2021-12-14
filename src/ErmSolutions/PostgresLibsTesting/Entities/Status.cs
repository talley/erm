using System;
using System.Collections.Generic;

namespace PostgresLibsTesting.Entities
{
    public partial class Status
    {
        public Status()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public bool Status1 { get; set; }
        public string Description { get; set; } = null!;
        public DateOnly Createdat { get; set; }
        public string Createdby { get; set; } = null!;
        public string? Updatedat { get; set; }
        public string? Updatedby { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}

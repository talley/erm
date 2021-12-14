using System;
using System.Collections.Generic;

namespace PostgresLibsTesting.Entities
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Rolename { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool? Active { get; set; }
        public string Createdby { get; set; } = null!;
        public string? Updatedat { get; set; }
        public string? Updatedby { get; set; }
        public string Createdat { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}

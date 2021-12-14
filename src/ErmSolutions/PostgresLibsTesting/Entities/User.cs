using System;
using System.Collections.Generic;

namespace PostgresLibsTesting.Entities
{
    public partial class User
    {
        public User()
        {
            Userpasswords = new HashSet<Userpassword>();
        }

        public Guid Userid { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Rolename { get; set; } = null!;
        public bool Status { get; set; }
        public DateOnly? Lastupdate { get; set; }
        public DateOnly Createdat { get; set; }
        public string Createdby { get; set; } = null!;
        public string? Updatedat { get; set; }
        public string? Updatedby { get; set; }

        public virtual Role RolenameNavigation { get; set; } = null!;
        public virtual Status StatusNavigation { get; set; } = null!;
        public virtual ICollection<Userpassword> Userpasswords { get; set; }
    }
}

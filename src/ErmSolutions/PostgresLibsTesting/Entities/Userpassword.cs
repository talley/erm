using System;
using System.Collections.Generic;

namespace PostgresLibsTesting.Entities
{
    public partial class Userpassword
    {
        public int Id { get; set; }
        public Guid Userid { get; set; }
        public byte[] Password { get; set; } = null!;
        public DateOnly Lastlogin { get; set; }
        public DateOnly Createdat { get; set; }
        public string Createdby { get; set; } = null!;
        public string? Updatedat { get; set; }
        public string? Updatedby { get; set; }

        public virtual User User { get; set; } = null!;
    }
}

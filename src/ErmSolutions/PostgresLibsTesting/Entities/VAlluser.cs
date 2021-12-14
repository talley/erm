using System;
using System.Collections.Generic;

namespace PostgresLibsTesting.Entities
{
    public partial class VAlluser
    {
        public Guid? Userid { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Rolename { get; set; }
        public bool? Status { get; set; }
        public DateOnly? Lastupdate { get; set; }
        public DateOnly? Createdat { get; set; }
        public string? Createdby { get; set; }
        public string? Updatedat { get; set; }
        public string? Updatedby { get; set; }
    }
}

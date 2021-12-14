using System;
using System.Collections.Generic;

namespace PostgresLibsTesting.Entities
{
    public partial class Region
    {
        public Region()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Regionname { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool? Status { get; set; }
        public DateOnly Createdat { get; set; }
        public string Createdby { get; set; } = null!;
        public string? Updatedat { get; set; }
        public string? Updatedby { get; set; }

        public virtual State StateNavigation { get; set; } = null!;
        public virtual ICollection<Employee> Employees { get; set; }
    }
}

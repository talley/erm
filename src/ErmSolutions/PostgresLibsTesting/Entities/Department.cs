using System;
using System.Collections.Generic;

namespace PostgresLibsTesting.Entities
{
    public partial class Department
    {
        public Department()
        {
            DeptManagers = new HashSet<DeptManager>();
        }

        public int DeptNo { get; set; }
        public string DeptName { get; set; } = null!;
        public string DeptDesc { get; set; } = null!;
        public DateOnly Createdat { get; set; }
        public string Createdby { get; set; } = null!;
        public string? Updatedat { get; set; }
        public string? Updatedby { get; set; }

        public virtual ICollection<DeptManager> DeptManagers { get; set; }
    }
}

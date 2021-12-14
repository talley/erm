using System;
using System.Collections.Generic;

namespace PostgresLibsTesting.Entities
{
    public partial class Salary
    {
        public Guid EmpNo { get; set; }
        public int Salary1 { get; set; }
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set; }
        public DateOnly Createdat { get; set; }
        public string Createdby { get; set; } = null!;
        public string? Updatedat { get; set; }
        public string? Updatedby { get; set; }

        public virtual Employee EmpNoNavigation { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace PostgresLibsTesting.Entities
{
    public partial class Title
    {
        public int Id { get; set; }
        public string Title1 { get; set; } = null!;
        public DateOnly FromDate { get; set; }
        public DateOnly? ToDate { get; set; }
        public DateOnly Createdat { get; set; }
        public string Createdby { get; set; } = null!;
        public string? Updatedat { get; set; }
        public string? Updatedby { get; set; }
    }
}

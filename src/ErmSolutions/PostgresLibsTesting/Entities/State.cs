using System;
using System.Collections.Generic;

namespace PostgresLibsTesting.Entities
{
    public partial class State
    {
        public State()
        {
            Employees = new HashSet<Employee>();
            Regions = new HashSet<Region>();
        }

        public int Id { get; set; }
        public string State1 { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool? Status { get; set; }
        public DateOnly Createdat { get; set; }
        public string Createdby { get; set; } = null!;
        public string? Updatedat { get; set; }
        public string? Updatedby { get; set; }

        public virtual Country CountryNavigation { get; set; } = null!;
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Region> Regions { get; set; }
    }
}

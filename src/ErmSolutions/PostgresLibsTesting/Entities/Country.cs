using System;
using System.Collections.Generic;

namespace PostgresLibsTesting.Entities
{
    public partial class Country
    {
        public Country()
        {
            Employees = new HashSet<Employee>();
            States = new HashSet<State>();
        }

        public int Id { get; set; }
        public string Iso { get; set; } = null!;
        public string Country1 { get; set; } = null!;
        public string Nicename { get; set; } = null!;
        public string? Iso3 { get; set; }
        public short? Numcode { get; set; }
        public int Phonecode { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<State> States { get; set; }
    }
}

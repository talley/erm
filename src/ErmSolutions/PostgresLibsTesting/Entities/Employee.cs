using System;
using System.Collections.Generic;

namespace PostgresLibsTesting.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            DeptManagers = new HashSet<DeptManager>();
            Salaries = new HashSet<Salary>();
        }

        public Guid EmpNo { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Middlename { get; set; } = null!;
        public DateOnly Dob { get; set; }
        public string Titre { get; set; } = null!;
        public char Gender { get; set; }
        public string Address { get; set; } = null!;
        public string? Address1 { get; set; }
        public string Country { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Regionname { get; set; } = null!;
        public string Zip { get; set; } = null!;
        public string Pobox { get; set; } = null!;
        public string Telephone { get; set; } = null!;
        public string? Fax { get; set; }
        public string Email { get; set; } = null!;
        public string? Facebook { get; set; }
        public string? Twitter { get; set; }
        public DateOnly Createdat { get; set; }
        public string Createdby { get; set; } = null!;
        public string? Updatedat { get; set; }
        public string? Updatedby { get; set; }

        public virtual Country CountryNavigation { get; set; } = null!;
        public virtual Region RegionnameNavigation { get; set; } = null!;
        public virtual State StateNavigation { get; set; } = null!;
        public virtual ICollection<DeptManager> DeptManagers { get; set; }
        public virtual ICollection<Salary> Salaries { get; set; }
    }
}

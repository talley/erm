namespace Erm.Core.En.Domains
{
    public partial class DeptManager
    {
        public Guid EmpNo { get; set; }
        public int DeptNo { get; set; }
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set; }
        public DateOnly Createdat { get; set; }
        public string Createdby { get; set; } = null!;
        public string? Updatedat { get; set; }
        public string? Updatedby { get; set; }

        public virtual Department DeptNoNavigation { get; set; } = null!;
        public virtual Employee EmpNoNavigation { get; set; } = null!;
    }
}
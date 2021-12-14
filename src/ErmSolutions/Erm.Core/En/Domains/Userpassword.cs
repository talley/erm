namespace Erm.Core.En.Domains
{
    public partial class Userpassword
    {
        [Key]
        public int Id { get; set; }
        public Guid Userid { get; set; }
        public byte[] Password { get; set; } = null!;
        public DateTime Lastlogin { get; set; }
        public DateTime Createdat { get; set; }
        public string Createdby { get; set; } = null!;
        public string? Updatedat { get; set; }
        public string? Updatedby { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
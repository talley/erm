
namespace Erm.Web.Areas.En.ViewModels
{
    public record AddUserVm
    {

        public Guid Userid { get; set; }
        [Required(ErrorMessage = "FirstName is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Username is Required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Role name is Required")]
        public string Rolename { get; set; }
        public bool Status { get; set; } = false;
        public DateTime? Lastupdate { get; set; }
        [Required(ErrorMessage = "Created at is Required")]
        public DateTime Createdat { get; set; }=DateTime.Now;
        [Required(ErrorMessage = "Created by is Required")]
        public string Createdby { get; set; } =Environment.MachineName;
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erm.Web.Areas.En.FluentValidations
{
    public class AddUserVmValidator : AbstractValidator<AddUserVm>
    {
        public AddUserVmValidator()
        {
            RuleFor(x => x.Username).NotNull().WithMessage("Username is Required");
            RuleFor(x => x.Password).NotNull().WithMessage("Password is Required");
            RuleFor(x => x.Rolename).NotNull().WithMessage("Role Name is Required");
            RuleFor(x=>x.Status).NotNull().WithMessage("Status is Required");
            RuleFor(x => x.Createdat).NotNull().WithMessage("Created At is Required");
            RuleFor(x => x.Createdby).NotNull().WithMessage("Created At is Required");
        }
    }
}

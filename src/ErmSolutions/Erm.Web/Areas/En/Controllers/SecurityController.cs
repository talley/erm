using Erm.Core.En.Domains;
using Erm.Infrastructure.En.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erm.Web.Areas.En.Controllers
{
    [Area("En")]
    public class SecurityController:BaseController
    {
        private IRepository<User> _userrepos;
        private IRepository<Role> _rolesrepos;
        private IMapper _mapper;

        public SecurityController(IRepository<User> userrepos, IMapper mapper, IRepository<Role> rolesrepos)
        {
            _userrepos =userrepos;
            _mapper = mapper;
            _rolesrepos = rolesrepos;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddUser()
        {
            var roles = await _rolesrepos.findAllAsync().ConfigureAwait(false);
            var rolessels = new List<SelectListItem>();
            roles.ForEach(r =>
            {
                rolessels.Add(new SelectListItem { 
                Text=r.Rolename,Value=r.Rolename
                });
            });
            ViewBag.Roles = rolessels;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserVm model)
        {
            if (ModelState.IsValid)
            {
                TempData["notice"] = "User successfully created";
            }
            var roles = await _rolesrepos.findAllAsync().ConfigureAwait(false);
            var rolessels = new List<SelectListItem>();
            roles.ForEach(r =>
            {
                rolessels.Add(new SelectListItem
                {
                    Text = r.Rolename,
                    Value = r.Rolename
                });
            });
            ViewBag.Roles = rolessels;
            return View(model);
        }

        [HttpGet]
        public  async Task<IActionResult> Users()
        {
            var users = await _userrepos.findAllAsync().ConfigureAwait(false);
            List<UserVm> usersvm = new List<UserVm>();
            users.ForEach(u =>
            {
                usersvm.Add(ConvertToUserVm(u));
            });

            var roles=await _rolesrepos.findAllAsync().ConfigureAwait(false);
            ViewBag.Roles = roles;
            return View(usersvm);
        }

        #region Functions
          public UserVm ConvertToUserVm(User user)
          {
            return new UserVm
            {
                Createdat=user.Createdat,Createdby=user.Createdby,Lastupdate=user.Lastupdate,Password=user.Password,
                Rolename=user.Rolename,Status=user.Status,Updatedat=user.Updatedat,Updatedby=user.Updatedby,
                Userid=user.Userid,Username=user.Username
            };
          }

        public User ConvertToUser(UserVm user)
        {
            return new User
            {
                Createdat = user.Createdat,
                Createdby = user.Createdby,
                Lastupdate = user.Lastupdate,
                Password = user.Password,
                Rolename = user.Rolename,
                Status = user.Status,
                Updatedat = user.Updatedat,
                Updatedby = user.Updatedby,
                Userid = user.Userid,
                Username = user.Username
            };
        }
        #endregion
    }
}

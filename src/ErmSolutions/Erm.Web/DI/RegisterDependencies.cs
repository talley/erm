using Erm.Core.En.Domains;
using Erm.Infrastructure.En.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erm.Web.DI
{
    public static class RegisterDependencies
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IRepository<User>,UsersRepository>();
            services.AddTransient<IRepository<Role>, RolesRepository>();
            services.AddTransient<IRepository<Userpassword>, UserPasswordsRepository>();
        }
    }
}

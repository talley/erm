
namespace Erm.Web.Mappers
{
    public  class MapRegistrations:Profile
    {
        public MapRegistrations()
        {
            CreateMap<User, UserVm>();
            CreateMap<UserVm,User>();
            CreateMap<List<User>, List<UserVm>>();
            CreateMap<List<UserVm>, List<User>>();
        }
       
    }
}

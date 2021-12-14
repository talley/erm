
namespace Erm.Infrastructure.En.Repositories
{
    public class RolesRepository : IRepository<Role>
    {
        public int Delete(Role model)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Role model)
        {
            throw new NotImplementedException();
        }

        public Role find(Role model)
        {
            throw new NotImplementedException();
        }

        public List<Role> findAll()
        {
            IEnumerable<Role> roles = new List<Role>();

            using(IDbConnection pgcon=new Npgsql.NpgsqlConnection(DatabaseConfig.ConnectionString))
            {
                roles = pgcon.Query<Role>("SELECT * FROM Roles as r ORDER BY r.rolename");
            }
            return roles.AsList();
        }

        public async Task<List<Role>> findAllAsync()
        {
            IEnumerable<Role> roles = new List<Role>();

            using (IDbConnection pgcon = new Npgsql.NpgsqlConnection(DatabaseConfig.ConnectionString))
            {
                roles =await pgcon.QueryAsync<Role>("SELECT * FROM Roles as r ORDER BY r.rolename");
            }
            return roles.AsList();
        }

        public Role findById(dynamic id)
        {
            throw new NotImplementedException();
        }

        public int SaveOrUpdate(Role model)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveOrUpdateAsync(Role model)
        {
            throw new NotImplementedException();
        }
    }
}

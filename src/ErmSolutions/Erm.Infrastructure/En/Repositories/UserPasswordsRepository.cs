
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erm.Infrastructure.En.Repositories
{
    public class UserPasswordsRepository : IRepository<Userpassword>
    {
        public int Delete(Userpassword model)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Userpassword model)
        {
            throw new NotImplementedException();
        }

        public Userpassword find(Userpassword model)
        {
            throw new NotImplementedException();
        }

        public List<Userpassword> findAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Userpassword>> findAllAsync()
        {
            throw new NotImplementedException();
        }

        public Userpassword findById(dynamic id)
        {
            throw new NotImplementedException();
        }

        public int SaveOrUpdate(Userpassword model)
        {
            var sb = new StringBuilder();
            bool bresult =false;
            int result = 0;
            try
            {
                if (model.Id == 0)
                {
                    sb.Append("INSERT INTO public.userpasswords(userid, password, lastlogin, createdat, createdby)");
                    sb.Append($"VALUES('{model.Userid}','{model.Password}','{model.Lastlogin}','{model.Createdat}','{model.Createdby}')");
                    using (IDbConnection pgcon = new NpgsqlConnection(DatabaseConfig.ConnectionString))
                    {
                        result = pgcon.Execute(sb.ToString());
                    }
                }
                else
                {
                    using (IDbConnection pgcon = new NpgsqlConnection(DatabaseConfig.ConnectionString))
                    {
                        bresult = pgcon.Update(model);
                        if (bresult)
                        {
                            result = 1;
                        }
                        else
                        {
                            result = 500;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }

        public async Task<int> SaveOrUpdateAsync(Userpassword model)
        {
            var sb = new StringBuilder();
            bool bresult = false;
            int result = 0;
            try
            {
                if (model.Id == 0)
                {
                    sb.Append("INSERT INTO public.userpasswords(userid, password, lastlogin, createdat, createdby)");
                    sb.Append($"VALUES('{model.Userid}','{model.Password}','{model.Lastlogin}','{model.Createdat}','{model.Createdby}')");
                    using (IDbConnection pgcon = new NpgsqlConnection(DatabaseConfig.ConnectionString))
                    {
                        result =await pgcon.ExecuteAsync(sb.ToString());
                    }
                }
                else
                {
                    using (IDbConnection pgcon = new NpgsqlConnection(DatabaseConfig.ConnectionString))
                    {
                        bresult =await pgcon.UpdateAsync(model);
                        if (bresult)
                        {
                            result = 1;
                        }
                        else
                        {
                            result = 500;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }
    }
}

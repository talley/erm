using Dapper;
using System.Data;
using Erm.Core.En.Domains;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erm.Commons.Configs;
using Dapper.Contrib.Extensions;

namespace Erm.Infrastructure.En.Repositories
{
    public class UsersRepository : IRepository<User>
    {
        private UserPasswordsRepository userpassrepos = new();
        public int Delete(User model)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(User model)
        {
            throw new NotImplementedException();
        }

        public User find(User model)
        {
            throw new NotImplementedException();
        }

        public List<User> findAll()
        {
            IEnumerable<User> users = new List<User>(); 
           using(IDbConnection pgcon=new Npgsql.NpgsqlConnection(DatabaseConfig.ConnectionString))
           {
                users= pgcon.Query<User>("SELECT * FROM Users");
           }
            return users.AsList();
        }

        public async Task<List<User>> findAllAsync()
        {
            IEnumerable<User> users = new List<User>();
            using (IDbConnection pgcon = new Npgsql.NpgsqlConnection(DatabaseConfig.ConnectionString))
            {
                users =await pgcon.QueryAsync<User>("SELECT * FROM Users");
            }
            return users.AsList();
        }

        public User findById(dynamic id)
        {
            throw new NotImplementedException();
        }

        public int SaveOrUpdate(User model)
        {
            int result = 0;
            bool bresult = false;
            var sb = new StringBuilder();
            try
            {
                if (model.Userid == Guid.Empty)
                {
                    sb.Append("username,password,rolename,status,email,firstname,lastname,createdat,createdby)");
                    sb.Append($"VALUES('{model.Username}','{model.Password}','{model.Rolename}','{model.Status}','{model.Email}','{model.Firstname}','{model.LastName}',");
                    sb.Append($"'{model.Createdat}','{model.Createdby}')");
                    using (IDbConnection pgcon = new NpgsqlConnection(DatabaseConfig.ConnectionString))
                    {
                        result = pgcon.Execute(sb.ToString());
                        if (result > 0)
                        {
                            var intresult=userpassrepos.SaveOrUpdate(new Userpassword
                            {
                                Createdat = DateTime.Now,Createdby=model.Createdby,Password=System.Text.Encoding.UTF8.GetBytes(model.Password),
                                Userid = model.Userid
                            });
                            if (intresult > 0)
                            {
                                ClearPasswordFieldInUsersTable(model.Userid);
                            }
                        }
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
                            if (result > 0)
                            {
                                ClearPasswordFieldInUsersTable(model.Userid);
                            }
                        }
                        else
                        {
                            result = 500;
                        }
                    }
                }
            }
            catch (Exception ex) when(ex!=null)
            {
                throw ex;
            }
            return result;
        }

        private void ClearPasswordFieldInUsersTable(Guid userid)
        {
            try
            {
                using (IDbConnection pgcon = new NpgsqlConnection(DatabaseConfig.ConnectionString))
                {
                    int result = pgcon.Execute($"UPDATE Users SET Password='[MASKED]' WHERE UserId='{userid}'");
                }
            }
            catch (Exception ex) when(ex!=null)
            {
                throw ex;
            }
        }

        public async Task<int> SaveOrUpdateAsync(User model)
        {
            int result = 0;
            bool bresult = false;
            var sb = new StringBuilder();
            try
            {
                if (model.Userid == Guid.Empty)
                {
                    sb.Append("username,password,rolename,status,email,firstname,lastname,createdat,createdby)");
                    sb.Append($"VALUES('{model.Username}','{model.Password}','{model.Rolename}','{model.Status}','{model.Email}','{model.Firstname}','{model.LastName}',");
                    sb.Append($"'{model.Createdat}','{model.Createdby}')");
                    using (IDbConnection pgcon = new NpgsqlConnection(DatabaseConfig.ConnectionString))
                    {
                        result =await pgcon.ExecuteAsync(sb.ToString());
                        if (result > 0)
                        {
                            ClearPasswordFieldInUsersTable(model.Userid);
                        }
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
                            if (result > 0)
                            {
                                ClearPasswordFieldInUsersTable(model.Userid);
                            }
                        }
                        else
                        {
                            result = 500;
                        }
                    }
                }
            }
            catch (Exception ex) when (ex != null)
            {
                throw ex;
            }
            return result;
        }
    }
}


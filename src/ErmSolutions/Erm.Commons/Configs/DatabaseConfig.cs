

namespace Erm.Commons.Configs
{
    public static class DatabaseConfig
    {
        //var connString = "Host=192.168.1.227;Username=app_user;Password=Iamsmart27@;Database=northwind";
        private static string staging_db = "ErmDev";
        private static string prod_db = "ermprod";

        private static string staging_user = "app_user";
        private static string prod_user = "app_user";

        private static string staging_user_pass = "Iamsmart27@";
        private static string prod_user_pass = "Iamsmart27@";

        public static string Password
        {
            get
            {
                if (Live.IsLive)
                {
                    return prod_user_pass;
                }
                return staging_user_pass;
            }
        }
        public static string User
        {
            get
            {
                if (Live.IsLive)
                {
                    return prod_user ;
                }
                return staging_user;
            }
        }
        private static string Database
        {
            get
            {
                if (Live.IsLive)
                {
                    return prod_db;
                }
                else
                {
                    return staging_db;
                }
            }
        }
        public static string ConnectionString
        {
            get
            {
                var server = ServerConfig.Server;
                return $"Host={server};Username={User};Password={Password};Database={Database}";
            }
        }
    }
}

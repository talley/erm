

namespace Erm.Commons.Configs
{
    public static class ServerConfig
    {
        private static string staging_server = "192.168.1.227";
        private static string production_server = "192.168.1.227";
        public static string Server
        {
            get
            {
                if (Live.IsLive)
                {
                    return production_server;
                }
                else
                {
                    return staging_server;
                }
            }
        }
    }
}

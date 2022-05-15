namespace ElusiveAPI.modules
{
    public class vars
    {

        private string admin_key;
        private string api_key;

        private string server_ip;

        public void set_server_ip(string host)
        {
            this.server_ip = host;
        }
        public void set_api_key(string key)
        {
            this.api_key = key;
        }
        public string get_api_key()
        {
            return this.api_key;
        }
        public void set_admin_key(string key)
        {
            this.admin_key = key;
        }
        public string get_admin_key()
        {
            return this.admin_key;
        }
        public string get_server()
        {
            return this.server_ip;
        }
    }
}

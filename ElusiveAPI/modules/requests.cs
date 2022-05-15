using System;
using System.Text;
using System.Net;
using System.IO;

namespace ElusiveAPI.modules
{
    class requests
    {
        public static string call_api(string endpoint, string method, string postData = null)
        {          
            try
            {

                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(endpoint);

                if (method == "GET")
                {
                    Request.Method = "GET";
                }
                else if (method == "POST")
                {
                    Request.Method = "POST";
                    Request.ContentType = "application/x-www-form-urlencoded";

                    var data = Encoding.ASCII.GetBytes(postData);
                    Request.ContentLength = data.Length;

                    using (var stream = Request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }
                else
                {
                    throw new Exception("Invalid Request Method");
                }
                HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
                StreamReader ReadResponseStream = new StreamReader(Response.GetResponseStream());
                string response_string = ReadResponseStream.ReadToEnd();
                return response_string;
            }
            catch (Exception ex)
            {
                return "Caught exception " + ex.ToString();
            }
        }
    }
}

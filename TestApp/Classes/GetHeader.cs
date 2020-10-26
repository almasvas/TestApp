using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Classes
{
    public class GetHeader
    {
        public static string Get(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url + "headers");
                HttpResponseMessage response = client.GetAsync("").Result;
                response.EnsureSuccessStatusCode();
                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Result: " + result);
                return result;
            }                        
        }
    }
}

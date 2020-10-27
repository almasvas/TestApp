using System;
using System.Net.Http;

namespace TestApp.Classes
{
    public class GetData
    {
        public static string Get(string host)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(host + "data");
                    HttpResponseMessage response = client.GetAsync("").Result;
                    response.EnsureSuccessStatusCode();
                    string result = response.Content.ReadAsStringAsync().Result;
                    return result;
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Произошла ошибка во время запроса данных: {e.Message}");
            }
        }
    }
}

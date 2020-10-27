using System;
using System.Net.Http;

namespace TestApp.Classes
{
    public class GetHeader
    {
        public static string[] Get(string host)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(host + "headers");
                    HttpResponseMessage response = client.GetAsync("").Result;
                    response.EnsureSuccessStatusCode();
                    string result = response.Content.ReadAsStringAsync().Result;
                    string[] resArray = result.Split(',');

                    return resArray;
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Произошла ошибка во время запроса списка идентификаторов: {e.Message}");
            }
        }
    }
}

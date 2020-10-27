using System;
using System.Net.Http;

namespace TestApp.Classes
{
    public class ClearData
    {
        public static void Clear(string host)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    Uri uri = new Uri(host + "clear");
                    HttpResponseMessage response = client.PostAsync(uri, null).Result;
                    response.EnsureSuccessStatusCode();
                    string result = response.Content.ReadAsStringAsync().Result; 
                }
            }
            catch(Exception e)
            {
                throw new Exception($"Произошла ошибка во время запроса на очистку данных: {e.Message}");
            }            
        }
    }
}

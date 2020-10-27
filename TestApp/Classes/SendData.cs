using System;
using System.Collections.Generic;
using System.Net.Http;

namespace TestApp.Classes
{
    public class SendData
    {
        public static void Send(string host, string data, string uid)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    Uri uri = new Uri(host + "insertData");
                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("HEADER", uid),
                        new KeyValuePair<string, string>("DATA", data),
                    });
                    HttpResponseMessage response = client.PostAsync(uri, content).Result;
                    
                    if(response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        throw new Exception($"Произошла ошибка во время отправки данных (400 BadRequest): неверный формат данных");
                    }
                    
                    string result = response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Произошла ошибка во время отправки данных: {e.Message}");
            }
        }
    }
}

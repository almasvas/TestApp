using System.Threading;
using System.Threading.Tasks;

namespace TestApp.Classes
{
    public class ProcessingData
    {
        public static void Process(string host)
        {
            string[] uids = GetHeader.Get(host);
            Thread.Sleep(20000); //для проверки того, что во время работы этого потока, интерфес активен и можно запускать другие потоки
            ParallelLoopResult result = Parallel.ForEach(uids, (uuid) =>
                                                                {
                                                                    Thread.Sleep(2000);
                                                                    var data = GetData.Get(host);
                                                                    var bytes = System.Text.Encoding.UTF8.GetBytes(data);
                                                                    SendData.Send(host, System.Convert.ToBase64String(bytes), uuid);
                                                                });
        }
    }
}

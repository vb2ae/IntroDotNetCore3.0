using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncStreamDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await foreach (var number in GenerateSequence())
            {
                Console.WriteLine(number);
            }

            await foreach (var location in GetISSLocationSequence())
            {
                Console.WriteLine(location);
            }
        }


        public static async System.Collections.Generic.IAsyncEnumerable<int> GenerateSequence()
        {
            for (int i = 0; i < 20; i++)
            {
                await Task.Delay(100);
                yield return i;
            }
        }


        public static async System.Collections.Generic.IAsyncEnumerable<string> GetISSLocationSequence()
        {
            using HttpClient http = new HttpClient();
            for (int i = 0; i < 20; i++)
            {
                var json = await http.GetStringAsync("http://api.open-notify.org/iss-now.json");
                await Task.Delay(2000);
                yield return json;
            }
        }

    }
}

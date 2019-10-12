using Grpc.Net.Client;
using GrpcServiceDemo;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace gRPCClientDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Task.Delay(1000);
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

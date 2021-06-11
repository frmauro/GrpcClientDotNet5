using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Grpc.Core;
using SalesProductApi;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            using var channel = GrpcChannel.ForAddress("http://localhost:5000", new GrpcChannelOptions { Credentials = ChannelCredentials.Insecure });
            var client = new ProductServiceProto.ProductServiceProtoClient(channel);

            // var reply = await client.SendProductAsync(new ProductRequest { Id = 1,  Description = "Product 001", Amount = "200", Price = "200", Status = "Active"});
            // Console.WriteLine("Response Product: " + reply.Message);
            // Console.WriteLine("Press any key to exit...");            

            // var reply = await client.GetProductsAsync(new Empty {});
            // Console.WriteLine("Response Product: " + reply);
            // Console.WriteLine("Press any key to exit...");            

            var reply = await client.GetProductAsync(new SalesProductApi.ProductId { Id = 1 });
            Console.WriteLine("Response Product: " + reply);
            Console.WriteLine("Press any key to exit...");            


            //Console.WriteLine("Hello World!");
        }
    }
}

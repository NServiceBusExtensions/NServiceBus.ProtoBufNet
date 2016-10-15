using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.ProtoBuf;

class Program
{
    static void Main()
    {
        AsyncMain().GetAwaiter().GetResult();
    }

    static async Task AsyncMain()
    {
        var endpointConfiguration = new EndpointConfiguration("ProtoBufSerializerSample");
        endpointConfiguration.UseSerialization<ProtoBufSerializer>();
        endpointConfiguration.EnableInstallers();
        endpointConfiguration.SendFailedMessagesTo("error");
        endpointConfiguration.UsePersistence<InMemoryPersistence>();

        var endpoint = await Endpoint.Start(endpointConfiguration);
        try
        {
            var message = new MyMessage
            {
                DateSend = DateTime.Now,
            };
            await endpoint.SendLocal(message);
            Console.WriteLine("\r\nPress any key to stop program\r\n");
            Console.Read();
        }
        finally
        {
            await endpoint.Stop();
        }
    }
}
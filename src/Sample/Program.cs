using NServiceBus;
using NServiceBus.ProtoBuf;
#pragma warning disable CS0618

class Program
{
    static async Task Main()
    {
        var configuration = new EndpointConfiguration("ProtoBufSerializerSample");
        configuration.UseSerialization<ProtoBufSerializer>();
        configuration.UseTransport<LearningTransport>();
        configuration.UsePersistence<LearningPersistence>();

        var endpoint = await Endpoint.Start(configuration);
        var message = new MyMessage
        {
            Name = "immediate",
        };
        await endpoint.SendLocal(message);

        Console.WriteLine("\r\nPress any key to stop program\r\n");
        Console.Read();
        await endpoint.Stop();
    }
}
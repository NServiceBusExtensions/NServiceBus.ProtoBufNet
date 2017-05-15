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
        endpointConfiguration.UseTransport<LearningTransport>();
        endpointConfiguration.UsePersistence<LearningPersistence>();

        var endpoint = await Endpoint.Start(endpointConfiguration)
            .ConfigureAwait(false);
        try
        {
            var message = new MyMessage
            {
                Name = "immediate",
            };
            await endpoint.SendLocal(message)
                .ConfigureAwait(false);

            await endpoint.ScheduleEvery(
                    timeSpan: TimeSpan.FromSeconds(5),
                    task: pipelineContext =>
                    {
                        var delayed = new MyMessage
                        {
                            Name = "delayed",
                        };
                        return pipelineContext.SendLocal(delayed);
                    })
                .ConfigureAwait(false);
            Console.WriteLine("\r\nPress any key to stop program\r\n");
            Console.Read();
        }
        finally
        {
            await endpoint.Stop()
                .ConfigureAwait(false);
        }
    }
}
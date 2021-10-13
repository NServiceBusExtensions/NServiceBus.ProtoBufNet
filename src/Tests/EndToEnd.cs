using NServiceBus;
using NServiceBus.ProtoBuf;
using ProtoBuf;
using Xunit;

public class EndToEnd
{
    static ManualResetEvent manualResetEvent = new(false);
    string endpointName = "EndToEnd";

    [Fact]
    public async Task Write()
    {
        var configuration = new EndpointConfiguration(endpointName);
        configuration.UsePersistence<LearningPersistence>();
        configuration.UseTransport<LearningTransport>();
        configuration.UseSerialization<ProtoBufSerializer>();
        var typesToScan = TypeScanner.NestedTypes<EndToEnd>();
        configuration.SetTypesToScan(typesToScan);
        var endpointInstance = await Endpoint.Start(configuration);
        var message = new MessageToSend
        {
            Property = "PropertyValue"
        };
        await endpointInstance.SendLocal(message);
        manualResetEvent.WaitOne();
        await endpointInstance.Stop();
    }

    [ProtoContract]
    public class MessageToSend :
        IMessage
    {
        [ProtoMember(1)]
        public string? Property { get; set; }
    }

    class MessageHandler :
        IHandleMessages<MessageToSend>
    {
        public Task Handle(MessageToSend message, IMessageHandlerContext context)
        {
            manualResetEvent.Set();
            return Task.CompletedTask;
        }
    }
}
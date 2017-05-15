using System.Threading;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using NServiceBus.ProtoBuf;
using NUnit.Framework;
using ProtoBuf;

[TestFixture]
public class EndToEnd
{
    static ManualResetEvent manualResetEvent = new ManualResetEvent(false);
    string endpointName = "EndToEnd";

    [Test]
    public async Task Write()
    {
        var endpointConfiguration = new EndpointConfiguration(endpointName);
        endpointConfiguration.UsePersistence<LearningPersistence>();
        endpointConfiguration.UseTransport<LearningTransport>();
        endpointConfiguration.UseSerialization<ProtoBufSerializer>();
        var typesToScan = TypeScanner.NestedTypes<EndToEnd>();
        endpointConfiguration.SetTypesToScan(typesToScan);
        var endpointInstance = await Endpoint.Start(endpointConfiguration)
            .ConfigureAwait(false);
        var message = new MessageToSend
        {
            Property = "PropertyValue"
        };
        await endpointInstance.SendLocal(message)
            .ConfigureAwait(false);
        manualResetEvent.WaitOne();
        await endpointInstance.Stop().ConfigureAwait(false);
    }

    [ProtoContract]
    public class MessageToSend :
        IMessage
    {
        [ProtoMember(1)]
        public string Property { get; set; }
    }

    class MessageHandler :
        IHandleMessages<MessageToSend>
    {
        private static ILog log = LogManager.GetLogger<MessageHandler>();
        public Task Handle(MessageToSend message, IMessageHandlerContext context)
        {
            log.Info(message.Property);
            manualResetEvent.Set();
            return Task.CompletedTask;
        }
    }

}
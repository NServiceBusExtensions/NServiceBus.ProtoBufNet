using NServiceBus.Serialization;
using ProtoBuf.Meta;

class MessageSerializer :
    IMessageSerializer
{
    RuntimeTypeModel runtimeTypeModel;

    public MessageSerializer(string? contentType, RuntimeTypeModel? runtimeTypeModel)
    {
        if (runtimeTypeModel == null)
        {
            this.runtimeTypeModel = RuntimeTypeModel.Default;
        }
        else
        {
            this.runtimeTypeModel = runtimeTypeModel;
        }

        if (contentType == null)
        {
            ContentType = "protobuf";
        }
        else
        {
            ContentType = contentType;
        }
    }

    public void Serialize(object message, Stream stream)
    {
        var messageType = message.GetType();
        if (messageType.Name.EndsWith("__impl"))
        {
            throw new("Interface based message are not supported. Create a class that implements the desired interface.");
        }

        runtimeTypeModel.Serialize(stream, message);
    }

    public object[] Deserialize(Stream stream, IList<Type> messageTypes)
    {
        var messageType = messageTypes.First();
        var message = runtimeTypeModel.Deserialize(stream, null, messageType);
        return new[] { message };
    }

    public string ContentType { get; }
}
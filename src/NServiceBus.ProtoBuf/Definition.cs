using NServiceBus.MessageInterfaces;
using NServiceBus.Serialization;
using NServiceBus.Settings;

namespace NServiceBus.ProtoBuf;

/// <summary>
/// Defines the capabilities of the ProtoBuf serializer
/// </summary>
public class ProtoBufSerializer :
    SerializationDefinition
{
    /// <summary>
    /// <see cref="SerializationDefinition.Configure"/>
    /// </summary>
    public override Func<IMessageMapper, IMessageSerializer> Configure(ReadOnlySettings settings) =>
        _ =>
        {
            var runtimeTypeModel = settings.GetRuntimeTypeModel();
            var contentTypeKey = settings.GetContentTypeKey();
            return new MessageSerializer(contentTypeKey, runtimeTypeModel);
        };
}
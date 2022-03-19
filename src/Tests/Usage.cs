using NServiceBus;
using NServiceBus.ProtoBuf;
using ProtoBuf.Meta;

class Usage
{
    Usage(EndpointConfiguration configuration)
    {
        #region ProtoBufSerialization

        configuration.UseSerialization<ProtoBufSerializer>();

        #endregion
    }

    void CustomSettings(EndpointConfiguration configuration)
    {
        #region ProtoBufCustomSettings

        var model = RuntimeTypeModel.Create();
        model.IncludeDateTimeKind = true;
        var serialization = configuration.UseSerialization<ProtoBufSerializer>();
        serialization.RuntimeTypeModel(model);

        #endregion
    }

    void ContentTypeKey(EndpointConfiguration configuration)
    {
        #region ProtoBufContentTypeKey

        var serialization = configuration.UseSerialization<ProtoBufSerializer>();
        serialization.ContentTypeKey("custom-key");

        #endregion
    }
}
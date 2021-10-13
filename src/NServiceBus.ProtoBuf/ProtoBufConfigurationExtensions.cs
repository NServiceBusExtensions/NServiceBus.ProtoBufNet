using NServiceBus.Configuration.AdvancedExtensibility;
using NServiceBus.Serialization;
using NServiceBus.Settings;
using ProtoBuf.Meta;

namespace NServiceBus.ProtoBuf;

/// <summary>
/// Extensions for <see cref="SerializationExtensions{T}"/> to manipulate how messages are serialized via ProtoBuf.
/// </summary>
public static class ProtoBufConfigurationExtensions
{
    /// <summary>
    /// Configures the <see cref="RuntimeTypeModel"/> to use.
    /// </summary>
    /// <param name="config">The <see cref="SerializationExtensions{T}"/> instance.</param>
    /// <param name="runtimeTypeModel">The <see cref="RuntimeTypeModel"/> to use.</param>
    public static void RuntimeTypeModel(this SerializationExtensions<ProtoBufSerializer> config, RuntimeTypeModel runtimeTypeModel)
    {
        var settings = config.GetSettings();
        settings.Set(runtimeTypeModel);
    }

    internal static RuntimeTypeModel GetRuntimeTypeModel(this ReadOnlySettings settings)
    {
        return settings.GetOrDefault<RuntimeTypeModel>();
    }

    /// <summary>
    /// Configures string to use for <see cref="Headers.ContentType"/> headers.
    /// </summary>
    /// <remarks>
    /// Defaults to "wire".
    /// </remarks>
    /// <param name="config">The <see cref="SerializationExtensions{T}"/> instance.</param>
    /// <param name="contentTypeKey">The content type key to use.</param>
    public static void ContentTypeKey(this SerializationExtensions<ProtoBufSerializer> config, string contentTypeKey)
    {
        Guard.AgainstEmpty(contentTypeKey, nameof(contentTypeKey));
        var settings = config.GetSettings();
        settings.Set("NServiceBus.ProtoBuf.ContentTypeKey", contentTypeKey);
    }

    internal static string GetContentTypeKey(this ReadOnlySettings settings)
    {
        return settings.GetOrDefault<string>("NServiceBus.ProtoBuf.ContentTypeKey");
    }
}
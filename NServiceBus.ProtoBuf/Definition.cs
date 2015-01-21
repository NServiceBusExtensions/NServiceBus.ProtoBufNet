namespace NServiceBus.ProtoBuf
{
    using System;
    using NServiceBus.Serialization;

    /// <summary>
    /// Defines the capabilities of the ProtoBuf serializer
    /// </summary>
    public class ProtoBufSerializer : SerializationDefinition
    {
        /// <summary>
        /// <see cref="SerializationDefinition.ProvidedByFeature"/>
        /// </summary>
        protected override Type ProvidedByFeature()
        {
            return typeof(SerializationFeature);
        }
    }

}

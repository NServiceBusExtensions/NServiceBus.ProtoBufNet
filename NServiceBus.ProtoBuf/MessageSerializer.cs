﻿namespace NServiceBus.ProtoBuf
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using global::ProtoBuf;
    using NServiceBus.Serialization;

    /// <summary>
    /// ProtoBuf serializer.
    /// </summary>
    public class MessageSerializer : IMessageSerializer
    {
        
        /// <summary>
        /// <see cref="IMessageSerializer.Serialize"/>
        /// </summary>
        public void Serialize(object message, Stream stream)
        {
            var messageType = message.GetType();
            if (messageType.Name.EndsWith("__impl"))
            {
                throw new Exception("Interface based message are not currently supported. Create a class that implements your desired interface. If you want to send an interface feel free to send a pull request.");
            }

            Serializer.Serialize(stream, message);
        }

        /// <summary>
        /// <see cref="IMessageSerializer.Deserialize"/>
        /// </summary>
        public object[] Deserialize(Stream stream, IList<Type> messageTypes)
        {
            if (messageTypes.Count > 1)
            {
                throw new Exception("Batch messages are not supported.");                
            }

            var method = typeof(Serializer).GetMethod("Deserialize");
            method = method.MakeGenericMethod(messageTypes[0]);
            var invoke = method.Invoke(this, new object[] { stream });
            return new []{ invoke};
        }

        /// <summary>
        /// Gets the content type into which this serializer serializes the content to 
        /// </summary>
        public string ContentType
        {
            get { return "ProtoBuf"; }
        }

    }
}
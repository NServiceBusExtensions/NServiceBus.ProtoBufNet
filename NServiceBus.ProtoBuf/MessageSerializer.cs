using System;
using System.Collections.Generic;
using System.IO;
using NServiceBus.Serialization;
using ProtoBuf.Meta;

namespace NServiceBus.ProtoBuf
{

    class MessageSerializer : IMessageSerializer
    {
        RuntimeTypeModel runtimeTypeModel;

        public MessageSerializer(string contentType, RuntimeTypeModel runtimeTypeModel)
        {
            if (contentType == null)
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
                throw new Exception("Interface based message are not supported. Create a class that implements the desired interface.");
            }

            runtimeTypeModel.Serialize(stream, message);
        }

        public object[] Deserialize(Stream stream, IList<Type> messageTypes)
        {
            var message = runtimeTypeModel.Deserialize(stream, null, messageTypes[0]);
            return new[]{ message};
        }

        public string ContentType { get; }
    }

}
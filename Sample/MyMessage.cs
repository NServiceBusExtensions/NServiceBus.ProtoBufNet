using System;
using NServiceBus;
using ProtoBuf;

[ProtoContract]
public class MyMessage : IMessage
{
    [ProtoMember(1)]
    public DateTime DateSend { get; set; }
}

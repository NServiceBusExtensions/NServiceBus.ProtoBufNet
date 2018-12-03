using NServiceBus;
using ProtoBuf;

[ProtoContract]
public class MyMessage : IMessage
{
    [ProtoMember(1)]
    public string Name { get; set; }
}
using System;
using ProtoBuf;

namespace NServiceBus.ProtoBuf
{
    [ProtoContract]
    public class ScheduledTaskWrapper
    {
        [ProtoMember(1)]
        public Guid TaskId { get; set; }

        [ProtoMember(2)]
        public string Name { get; set; }

        [ProtoMember(3)]
        public TimeSpan Every { get; set; }
    }
}
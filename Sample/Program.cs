using System;
using NServiceBus;
using NServiceBus.ProtoBuf;

class Program
{
    static void Main()
    {
        var busConfig = new BusConfiguration();
        busConfig.EndpointName("ProtoBufSerializerSample");
        busConfig.UseSerialization<ProtoBufSerializer>();
        busConfig.EnableInstallers();
        busConfig.UsePersistence<InMemoryPersistence>();
        using (var bus = Bus.Create(busConfig))
        {
            bus.Start();
            bus.SendLocal(new MyMessage
                          {
                              DateSend = DateTime.Now,
                          });
            Console.WriteLine("\r\nPress any key to stop program\r\n");
            Console.Read();
        }
    }
}
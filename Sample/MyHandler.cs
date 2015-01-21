using System;
using NServiceBus;

class MyHandler : IHandleMessages<MyMessage>
{
    public void Handle(MyMessage message)
    {
        Console.WriteLine("Hello from MyHandler " + message.DateSend);
    }
}
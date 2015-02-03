![Icon](https://raw.githubusercontent.com/SimonCropp/NServiceBus.ProtoBuf/master/Icon/package_icon.png)

NServiceBus.ProtoBuf
===========================

Add support for [NServiceBus](http://particular.net/NServiceBus) message serialization via [ProtoBuf](https://code.google.com/p/protobuf-net/)

## The nuget package  [![NuGet Status](http://img.shields.io/nuget/v/NServiceBus.ProtoBuf.svg?style=flat)](https://www.nuget.org/packages/NServiceBus.ProtoBuf/)

https://nuget.org/packages/NServiceBus.ProtoBuf/

    PM> Install-Package NServiceBus.ProtoBuf

## Usage

```
var busConfig = new BusConfiguration();
busConfig.UseSerialization<ProtoBufSerializer>();
```

## Icon

<a href="http://thenounproject.com/term/robot/10415/" target="_blank">Robot</a> designed by <a href="http://thenounproject.com/Soto/" target="_blank">Sotirios Papavasilopoulos</a> from The Noun Project

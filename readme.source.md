# <img src="/src/icon.png" height="30px"> NServiceBus.ProtoBufNet

[![Build status](https://ci.appveyor.com/api/projects/status/7cptj0com9mlc5k6/branch/master?svg=true)](https://ci.appveyor.com/project/SimonCropp/nservicebus-ProtoBufNet)
[![NuGet Status](https://img.shields.io/nuget/v/NServiceBus.ProtoBuf.svg)](https://www.nuget.org/packages/NServiceBus.ProtoBuf/)

Add support for [NServiceBus](https://docs.particular.net/nservicebus/) message serialization via [ProtoBuf](https://github.com/mgravell/protobuf-net)

toc

<!--- StartOpenCollectiveBackers -->

[Already a Patron? skip past this section](#endofbacking)


## Community backed

**It is expected that all developers [become a Patron](https://opencollective.com/nservicebusextensions/order/6976) to use any of these libraries. [Go to licensing FAQ](https://github.com/NServiceBusExtensions/Home/#licensingpatron-faq)**


### Sponsors

Support this project by [becoming a Sponsors](https://opencollective.com/nservicebusextensions/order/6972). The company avatar will show up here with a link to your website. The avatar will also be added to all GitHub repositories under this organization.


### Patrons

Thanks to all the backing developers! Support this project by [becoming a patron](https://opencollective.com/nservicebusextensions/order/6976).

<img src="https://opencollective.com/nservicebusextensions/tiers/patron.svg?width=890&avatarHeight=60&button=false">

<!--- EndOpenCollectiveBackers -->

<a href="#" id="endofbacking"></a>


## NuGet package

https://nuget.org/packages/NServiceBus.ProtoBuf/


## Usage

snippet: ProtobufSerialization

This serializer does not support [messages defined as interfaces](https://docs.particular.net/nservicebus/messaging/messages-as-interfaces). If an explicit interface is sent, an exception will be thrown with the following message:

```
Interface based message are not supported.
Create a class that implements the desired interface
```

Instead, use a public class with the same contract as the interface. The class can optionally implement any required interfaces.


### Custom Settings

Customizes the `SerializerOptions` used for serialization.

snippet: ProtoBufCustomSettings


### Custom content key

When using [additional deserializers](https://docs.particular.net/nservicebus/serialization/#specifying-additional-deserializers) or transitioning between different versions of the same serializer it can be helpful to take explicit control over the content type a serializer passes to NServiceBus (to be used for the [ContentType header](https://docs.particular.net/nservicebus/messaging/headers#serialization-headers-nservicebus-contenttype)).

snippet: ProtoBufContentTypeKey


## Release Notes

See [closed milestones](../../milestones?state=closed).


## Icon

[Robot](https://thenounproject.com/term/robot/10415/) designed by [Sotirios Papavasilopoulos](https://thenounproject.com/Soto/) from [The Noun Project](https://thenounproject.com).
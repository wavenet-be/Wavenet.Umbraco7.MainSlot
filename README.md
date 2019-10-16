# Wavenet.Umbraco7.MainSlot
Avoids access to 2 instances of Umbraco backoffice during A/B testing.

![wavenet-be MyGet Build Status](https://www.myget.org/BuildSource/Badge/wavenet-be?identifier=8be56f45-55d2-44f4-899d-37447585f07f)

## How to install
Just install this package with Nuget and you are good to go!

## How does it work?
Azure uses a special cookie during A/B testing ([more information](https://github.com/uglide/azure-content/blob/master/articles/app-service-web/app-service-web-test-in-production-get-start.md)).  
This package will intercept the access to Umbraco backoffice and will override the Azure cookie to ensure Umbraco access only from the main slot.  
Without this package you will have issues:
```
You will designate a single server to be the backoffice server for which your editors will log into for editing content.
Umbraco will not work correctly if the backoffice is behind the load balancer.
```
https://our.umbraco.com/Documentation/Getting-Started/Setup/Server-Setup/Load-Balancing/flexible  


## Packages
| **Stable Release**
|-
| [![NuGet](https://img.shields.io/nuget/v/Wavenet.Umbraco7.MainSlot.svg)](https://www.nuget.org/packages/Wavenet.Umbraco7.MainSlot)
| **Early Access**
| [![MyGet](https://img.shields.io/myget/wavenet-be/vpre/Wavenet.Umbraco7.MainSlot.svg)](https://www.myget.org/feed/wavenet-be/package/nuget/Wavenet.Umbraco7.MainSlot)

# SeleniumConfigurator

[![NuGet version (SeleniumConfigurator)](https://img.shields.io/nuget/v/SeleniumConfigurator.svg?style=flat-square)](https://www.nuget.org/packages/SeleniumConfigurator/)


Selenium Configurator automatically downloads matching drivers for installed browsers.
<br>The project supports Edge and Chrome.
<br>Other browsers will be supported later.

Usage
----


##### Chrome
```csharp
string driverPath = SeleniumConfigurator.Chrome.GetDriverPath();
var service = ChromeDriverService.CreateDefaultService(driverPath);
var driver = new ChromeDriver(service);
```

##### Edge
```csharp
string driverPath = SeleniumConfigurator.Edge.GetDriverPath();
var service = EdgeDriverService.CreateDefaultService(driverPath);
var driver = new EdgeDriver(service);
```

Developer
----
`이호원 (Howon Lee) a.k.a hoyo321 or kck4156, airtaxi`

License
----
MIT License

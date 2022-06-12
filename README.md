# net-generic-host-boilerplate
This is a .NET 6 boilerplate for [generic host console apps](https://docs.microsoft.com/en-us/dotnet/core/extensions/generic-host). 

If you're like me and frequently in need of creating long running .NET 6 console apps, then you can use this. It's especially good if your structure and implementation grows over time. 

It covers the basic necessities of a generic host console app:
- Logging, via `Microsoft.Extensions.Logging`. You can plug your own if you want.
- Dependency injection.
- Async/await processing inside the `BackgroundService` instance.
- Configuration, through environment vars and/or `appsettings.json`.

## Attribution

Based on: [https://github.com/marceln/net-generic-host-boilerplate](https://github.com/marceln/net-generic-host-boilerplate)

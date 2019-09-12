# feature-flag (FeatureFlag)

Simple feature flag (feature toggle) in .NET and .NET Core.

## Install [FeatureFlag](https://www.nuget.org/packages/FeatureFlag)

* Package Manager

```bash
Install-Package FeatureFlag -Version 1.0.0
```

* .NET CLI

```bash
dotnet add package FeatureFlag --version 1.0.0
```

* PackageReference

```xml
<PackageReference Include="FeatureFlag" Version="1.0.0" />
```

* Paket CLI

```bash
paket add FeatureFlag --version 1.0.0
```

## Simple example of using the library

* Creating a class `HelloWorldFeature`.

```c#
public class HelloWorldFeature : SimpleFeatureFlag
{
    public HelloWorldFeature(bool featureEnabled) : base(featureEnabled)
    {
    }
}
```

* Creating a class `CalendarFeature`.

```c#
public class CalendarFeature : SimpleFeatureFlag
{
    public CalendarFeature(bool featureEnabled) : base(featureEnabled)
    {
    }
}
```

* Initialization of objects: `HelloWorldFeature`, `CalendarFeature`.

```c#
var helloWorldFeature = new HelloWorldFeature(false);
var calendarFeature = new CalendarFeature(true);
```

* Example of use feature flags.

```c#
if(helloWorldFeature.FeatureEnabled)
    Console.WriteLine("Hello World!");

if (calendarFeature.FeatureEnabled)
    Console.WriteLine($"{DateTime.Now.Year:0000}-{DateTime.Now.Month:00}-{DateTime.Now.Day:00}");
```

Result:

```bash
2019-09-12
```

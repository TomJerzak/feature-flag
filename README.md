# feature-flag (FeatureFlag)

Simple feature flag (feature toggle) in .NET and .NET Core.

## Install [FeatureFlag](https://www.nuget.org/packages/FeatureFlag)

* Package Manager

```bash
Install-Package FeatureFlag -Version 1.2.0
```

* .NET CLI

```bash
dotnet add package FeatureFlag --version 1.2.0
```

* PackageReference

```xml
<PackageReference Include="FeatureFlag" Version="1.2.0" />
```

* Paket CLI

```bash
paket add FeatureFlag --version 1.2.0
```

## Available feature flags

* SimpleFeatureFlag
* ExpirationFeatureFlag

## Simple example of usage ([FeatureFlag.Example](https://github.com/TomJerzak/feature-flag/tree/master/samples/FeatureFlag.Example))

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

* Usage example of the feature flags.

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

## Web example of usage with appsettings ([FeatureFlag.Web](https://github.com/TomJerzak/feature-flag/tree/master/samples/FeatureFlag.Web))

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

* Creating a class `ExpirationHelloWorldFeature`.

```c#
public class ExpirationHelloWorldFeature : ExpirationFeatureFlag
{
    public ExpirationHelloWorldFeature(DateTime expirationDate) : base(expirationDate)
    {
    }
}
```

* Configuring `appsettings.Development.json`

```json
{
  "FeatureFlag": {
    "CalendarFeature": true,
    "HelloWorldFeature": true,
    "ExpirationHelloWorldFeature": "9999-12-31"
  }
}
```

* Creating a class `SettingsSections`

```c#
public static class SettingsSections
{
    public const string FeatureFlag = "FeatureFlag";
}
```

* Creating a class `FeatureFlagWrapper` and initialization of objects with default values: `HelloWorldFeature`, `CalendarFeature`.

```c#
public static class FeatureFlagWrapper
{
    public static readonly HelloWorldFeature HelloWorldFeature = new HelloWorldFeature(false);
    public static readonly CalendarFeature CalendarFeature = new CalendarFeature(false);
    public static readonly ExpirationFeatureFlag ExpirationHelloWorldFeature = new ExpirationHelloWorldFeature(DateTime.Now);

    public static void LoadFeatureFlags(IConfiguration configuration, string featureFlagSectionName)
    {
        HelloWorldFeature.SetFeatureEnabled(configuration.GetSection($"{featureFlagSectionName}:{nameof(HelloWorldFeature)}"));
        CalendarFeature.SetFeatureEnabled(configuration.GetSection($"{featureFlagSectionName}:{nameof(CalendarFeature)}"));
        ExpirationHelloWorldFeature.SetFeatureEnabled(configuration.GetSection($"{featureFlagSectionName}:{nameof(ExpirationHelloWorldFeature)}"));
    }
}
```

* Load feature flags from `Startup.cs`.

```c#
public void ConfigureServices(IServiceCollection services)
{
    FeatureFlagWrapper.LoadFeatureFlags(Configuration, SettingsSections.FeatureFlag);
    ...
}
```

* Usage examples of the feature flags.

```c#
// Usage example of the feature flag in Controller
public IActionResult Index()
{
    if(FeatureFlagWrapper.HelloWorldFeature.FeatureEnabled)
        Console.WriteLine("Hello World!");

    return View();
}
```

```html
<!-- Usage example of the feature flag in View (Razor) -->
@using FeatureFlag.Web.FeatureFlags
@{
    ViewData["Title"] = "Home Page";
}

@if (FeatureFlagWrapper.HelloWorldFeature.FeatureEnabled)
{
    <h3>Hello World!</h3>
}

@if (FeatureFlagWrapper.CalendarFeature.FeatureEnabled)
{
    var today = $"{DateTime.Now.Year:0000}-{DateTime.Now.Month:00}-{DateTime.Now.Day:00}";
    <h3>@today</h3>
}

@if (FeatureFlagWrapper.ExpirationHelloWorldFeature.FeatureEnabled)
{
    <h3>Expiration Hello World!</h3>
}
```

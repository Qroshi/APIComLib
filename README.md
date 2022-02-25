# APIComLib

Unofficial .NET SDK for wLLightBox led controller


## Frameworks supported

 - [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)



## Dependencies

 - [Newtonsoft.Json 13.0.1](https://www.nuget.org/packages/Newtonsoft.Json/)
## Documentation for API Endpoints
All URIs are ralative to [wLightBox API](https://app.swaggerhub.com/apis-docs/ela-compil/api-type_w_light_box/20200518)
| Method  |  HTTP request |  Description |
|---|---|---|
| GetCurrentStateAsync|**GET** /api/rgbw/state|Returns current state of lighting.|
| GetCurrentStateExtAsync|**GET** /api/rgbw/extended/state|Returns extended parameters of lighting.|
| SetColorAsync|**POST** /api/rgbw/set|Sets color of lighting and returns current state of lighting.|
| SetColorExtAsync|**POST** /api/rgbw/extended/set|Sets color of lighting and returns extended parameters of lighting.|
| SetEffectAsync|**POST** /api/rgbw/set|Sets effect and returns current state of lighting.|
| SetEffectExtAsync|**POST** /api/rgbw/extended/set|Sets effectand returns extended parameters of lighting.|
| SetFavColorsAsync|**POST** /api/rgbw/extended/set|Sets favorite colors and returns extended parameters of lighting.|
| GetSettingsAsync|**GET** /api/settings/state|Returns wLightBox settings.|
| SetSettingsAsync|**POST** /api/settings/set|Sets wLightBox settings and returns current settings.|

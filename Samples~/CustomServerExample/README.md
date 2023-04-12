# Custom server example

### Components:
* `CustomSettingsProvider.cs` - example of implementation all necessary interfaces for custom server - IEndpointsProvider, IAuthenticationInterceptor, IClientSettings
  * `IEndpointsProvider` - provides endpoints for all requests
  * `IAuthenticationInterceptor` - implements authentication logic - custom auth token, custom headers, etc
  * `IClientSettings` - provides settings for client - just log level now 
* `CustomServerExample.cs` - example of usage requests with custom server
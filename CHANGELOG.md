## 0.2.1 (2023-03-23)
Improved log message formatting

#### Added
- Internal `Serializer` class which encapsulate `Newtonsoft.Json` library

#### Modified
- Simplified internal data transfer objects


## 0.2.0 (2023-03-20)
Made toolkit more suitable for usage with custom OpenAI server
`IEndpointProvider` was replaced by `IAuthenticationInterceptor` which allow developer work with authorization headers directly.
Implementations for working with OpenAI server was added.
`CustomServerExample` was added as example of working with custom server.

#### Added
- IAuthenticationInterceptor
- OpenAIAuthenticationInterceptor
- OpenAIClient
- OpenAIEndpointsProvider
- CustomServerExample

#### Changed
- IEndpointsProvider
- IClientSettings

#### Removed
- `Factory` class


## 0.1.0 (2023-03-15)
Initial release

#### Added
- Models service 
- Completions service
- Chat service
- Edits service
- Images service
- Audio service
- Moderations service
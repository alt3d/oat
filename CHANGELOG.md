## 0.3.0 (2023-04-12)
Rework files and folders structure. 
Improve samples - add comments and readme files.

#### Added
- Readme files to all categories of samples
- Comments to all samples scripts

#### Changed
- Client code moved to `Runtime` folder
- Examples moved to `Samples` folder
- Sample scripts are divided into different folders according to their category

#### Removed
- `Examples` scene

## 0.2.1 (2023-03-23)
Improved log message formatting

#### Added
- Internal `Serializer` class which encapsulate `Newtonsoft.Json` library

#### Changed
- Simplified internal data transfer objects

## 0.2.0 (2023-03-20)
Made toolkit more suitable for usage with custom OpenAI server
`IEndpointProvider` was replaced by `IAuthenticationInterceptor` which allow developer work with authorization headers
directly.
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
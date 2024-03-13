# Unity Open AI Toolkit

## Open AI API wrapper for Unity.
* This is a **community** library. No affiliation with OpenAI
* This library is primarily intended for integration into a **client-side application**, so it does not include methods designed for customization of models

## Features:
* All Unity build platforms support.
* Unity specific types integration. Responses for image requests contains Texture2D, for example.
* Async and non-async methods.
* The syntax follows the OpenAI documentation as closely as possible.
* Extensive xml documentation. Every single class, method and property is covered by comments
* Every request has a simple example of integration.
* ChatGPT analogue as demo example.

## OpenAI API coverage:
* ✅ Models
* ✅ Completions
* ✅ Chat
* ✅ Edits
* ✅ Images
* ✅ Audio
* ✅ Moderations
* ❌ Embeddings
* ❌ Files
* ❌ Fine-tunes

## Install
1. Unity Package Manager. 
    * Open the Package Manager Window
    * Click the `+` icon in the top left hand corner
    * Select `Add package from git URL`
    * Paste the url: `https://github.com/alt3d/unity-openai-toolkit.git`
2. Unity Assets Package. 
    * Go to [releases page](https://github.com/alt3d/unity-openai-toolkit/releases) and download the package.
    * Once downloaded, import package into the Unity project.

## Quick start:
1. Create OpenAI account and get API key
2. Install OpenAI Toolkit package
3. Create a new `OpenAIClient`
4. Create text completion request and pass `model` and `prompt` as parameters
5. Send request and handle the response
```csharp
var client = new OpenAIClient("<your open ai api key>");
var request = new CompletionRequest("text-davinci-003", "Say this is a test");
client.Completion.CreateCompletion(request, response => Debug.Log($"Message: {response.Choices[0].Text}"));
```

## How to implement client for your own custom OpenAI server
1. Create one or several classes implemented necessary interfaces:
   1. `IEndpointsProvider` - contains all endpoints for your server
   2. `IAuthenticationInterceptor` - contains all authentication logic for your server
   3. `IClientSettings` - contains client settings
2. Create a new `OpenAIToolkit.Client` and configure it with your custom classes
   ```csharp
   var client = new Client()
                .SetAuthenticationInterceptor(SettingsProvider)
                .SetEndpointsProvider(SettingsProvider)
                .SetClientSettings(SettingsProvider);
   ```
3. Use the client to send requests to your server

## References
[Unity OpenAI Toolkit Site](https://unityopenaitoolkit.com/)</br>
[Unity OpenAI Toolkit Code Reference](https://unityopenaitoolkit.com/code-reference/)</br>
[OpenAI's API Documentation](https://platform.openai.com/docs/introduction/overview)</br>
[OpenAI's API Reference](https://platform.openai.com/docs/api-reference/introduction)
# Other samples

### Components:
* `CreateModerationSample.cs` - example of classification if text violates OpenAI's Content Policy
* `ListModelsSample.cs` - example of listing all available models
* `RetrieveModelSample.cs` - example of retrieving a basic information about a model

### How to test the create moderation sample:
1. Add the component to a game object.
2. Set up the `ApiKey` field.
3. Set up the `Prompt` field.
4. Select the `Send request` or `Send request async` option from the component's context menu.
5. Wait for the response.
6. Check the logs for the result - was the text flagged as violating the Content Policy or not.

### How to test the list models sample:
1. Add the component to a game object.
2. Set up the `ApiKey` field.
3. Select the `Send request` or `Send request async` option from the component's context menu.
4. Wait for the response.
5. Check the logs for the result - a count of available models.

### How to test the retrieve model sample:
1. Add the component to a game object.
2. Set up the `ApiKey` field.
3. Set up the `Model` field.
4. Select the `Send request` or `Send request async` option from the component's context menu.
5. Wait for the response.
6. Check the logs for the result - a basic information about the model.
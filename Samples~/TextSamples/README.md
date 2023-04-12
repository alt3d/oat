# Text samples

### Components:
* `CreateCompletionSample.cs` - example of text completion
* `CreateEditSample.cs` - example of text editing
* `CreateChatCompletionSample.cs` - example of completion for chat messages

### How to test create completion sample:
1. Add component to the some game object
2. Setup `ApiKey` field
3. Set up `Model` field
4. Set up `Prompt` field
5. Select `Send request` or `Send request async` item from component's context menu
6. Wait for the response
7. Check logs for completion

### How to test create edit sample:
1. Add component to the some game object
2. Setup `ApiKey` field
3. Set up `Model` field
4. Set up `Prompt` field
5. Set up `Instruction` field
6. Select `Send request` or `Send request async` item from component's context menu
7. Wait for the response
8. Check logs for edited text

### How to test create chat completion sample:
1. Add component to the some game object
2. Setup `ApiKey` field
3. Set up `Model` field
4. Set up `Message` field
5. Select `Send request` or `Send request async` item from component's context menu
6. Wait for the response
7. Check logs for completion
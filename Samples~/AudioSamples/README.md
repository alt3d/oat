# Audio samples

**Note! These examples only work in the editor.
In a real application, you need to implement your own method of obtaining audio data as a byte array.**

### Components:
* `CreateTranscriptionSample.cs` - example of transcription of audio file
* `CreateTranslationSample.cs` - example of translation of audio file

### Assets:
* `TranscriptionSampleTrack.wav` - audio sample track for transcription (English)
* `TranslationSampleTrack.wav` - audio sample track for translation (German to English)

### How to test:
1. Add the component to a game object.
2. Set up the `ApiKey` field.
3. Drag and drop an audio file into the `AudioClip` field.
4. Select the `Send request` or `Send request async` option from the component's context menu.
5. Wait for the response.
6. Check the logs for the transcription or translation.
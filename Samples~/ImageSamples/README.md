# Image samples

### Components:
* `CreateImageSample.cs` - example of image generation based on prompt
* `CreateImageEditSample.cs` - example of image editing based on original image and prompt
* `CreateImageVariantSample.cs` - example of image variant generation based on original image

### Assets:
* `SourceImage.png` - original image for editing
* `MaskImage.png` - mask image for editing with a transparent area where the original image will be edited.
* `VariationSource.png` - original image for variant generation

### How to test create image sample:
1. Add the component to a game object.
2. Set up the `ApiKey` field.
3. Set up the `Prompt` field.
4. Select `Image size` item from the dropdown list.
5. Select `Response format` item from the dropdown list.
    * `Url` - for getting the image url only
    * `Texture2D` - for getting the image as a Texture2D
6. Select the `Send request` or `Send request async` option from the component's context menu.
7. Wait for the response.
8. Check the logs for the url of the generated image
9. Check the cube game object with generated image on it (if you selected `Texture2D` response format)

### How to test create image edit sample:
1. Add the component to a game object.
2. Set up the `ApiKey` field.
3. Set up the `Prompt` field.
4. Drag and drop the `SourceImage.png` file into the `SourceImage` field.
5. Drag and drop the `MaskImage.png` file into the `MaskImage` field.
6. Select `Image size` item from the dropdown list.
7. Select `Response format` item from the dropdown list.
   * `Url` - for getting the image url only
   * `Texture2D` - for getting the image as a Texture2D
8. Select the `Send request` or `Send request async` option from the component's context menu.
9. Wait for the response.
10. Check the logs for the url of the edited image
11. Check the cube game object with generated image on it (if you selected `Texture2D` response format)

### How to test create image variant sample:
1. Add the component to a game object.
2. Set up the `ApiKey` field.
3. Drag and drop the `VariationSource.png` file into the `SourceImage` field.
4. Select `Image size` item from the dropdown list.
5. Select `Response format` item from the dropdown list.
   * `Url` - for getting the image url only
   * `Texture2D` - for getting the image as a Texture2D
6. Select the `Send request` or `Send request async` option from the component's context menu.
7. Wait for the response.
8. Check the logs for the url of the generated image
9. Check the cube game object with generated image on it (if you selected `Texture2D` response format)
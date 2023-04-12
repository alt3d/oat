using UnityEngine;

namespace OpenAIToolkit.Samples
{
    public class CreateImageVariantSample : MonoBehaviour
    {
        public string ApiKey;
        public Texture2D SourceImage;
        public int Count = 1;
        public ImageSize ImageSize = ImageSize.x256;
        public ImageResponseFormat ResponseFormat = ImageResponseFormat.Texture2D;
        private GameObject View;

        [ContextMenu("Send request")]
        public void SendRequest()
        {
            // Delete the view if it exists
            DeleteView();

            // Create a new OpenAI client
            var client = new OpenAIClient(ApiKey);

            // Create a new create image variant request and set the parameters
            var request = new CreateImageVariantRequest(SourceImage) {
                Count = Count,
                Size = ImageSize,
                ResponseFormat = ResponseFormat
            };

            // Send the request and handle the response in the callback
            client.Image.CreateImageVariant(request, HandleResponse);
        }

        [ContextMenu("Send request (async)")]
        public async void SendRequestAsync()
        {
            // Delete the view if it exists
            DeleteView();

            // Create a new OpenAI client
            var client = new OpenAIClient(ApiKey);

            // Create a new create image variant request and set the parameters
            var request = new CreateImageVariantRequest(SourceImage) {
                Count = Count,
                Size = ImageSize,
                ResponseFormat = ResponseFormat
            };

            // Send the request asynchronously and await the response
            var response = await client.Image.CreateImageVariantAsync(request);

            // Handle the response
            HandleResponse(response);
        }

        private void HandleResponse(CreateImageVariantResponse response)
        {
            // Check if the request was successful and create a view if it was or log an error if it wasn't
            if (response.Successful)
            {
                // Get the first image data from the response
                var imageData = response.Images[0];

                // Log the image url
                Debug.Log($"CreateImageVariant.Success. Image url: {imageData.Url}");

                // Create a view if the response format is Texture2D
                if (response.ResponseFormat == ImageResponseFormat.Texture2D)
                {
                    // Create a cube game object and rename it
                    View = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    View.name = "CreateImageVariantExampleView";

                    // Set the texture from the image data to the cube's material
                    View.GetComponent<Renderer>().sharedMaterial.mainTexture = imageData.Texture;
                }
            }
            else
            {
                Debug.LogError($"CreateImageVariant.Error. Message: {response.Error.Message}");
            }
        }

        private void DeleteView()
        {
            if (!View)
                return;

            if (Application.isPlaying)
                Destroy(View);
            else
                DestroyImmediate(View);
        }
    }
}
using UnityEngine;

namespace OpenAIToolkit.Examples
{
    public class CreateImageVariantExample : MonoBehaviour
    {
        public string ApiKey;
        public Texture2D Image;
        public int Count = 1;
        public ImageSize ImageSize = ImageSize.x256;
        public ImageResponseFormat ResponseFormat = ImageResponseFormat.Texture2D;
        private GameObject View;

        [ContextMenu("Send request")]
        public void SendRequest()
        {
            DeleteView();

            var client = Factory.CreateClient(ApiKey);

            var request = new CreateImageVariantRequest(Image) {
                Count = Count,
                Size = ImageSize,
                ResponseFormat = ResponseFormat
            };

            client.Image.CreateImageVariant(request, HandleResponse);
        }

        [ContextMenu("Send request (async)")]
        public async void SendRequestAsync()
        {
            DeleteView();

            var client = Factory.CreateClient(ApiKey);

            var request = new CreateImageVariantRequest(Image) {
                Count = Count,
                Size = ImageSize,
                ResponseFormat = ResponseFormat
            };

            var response = await client.Image.CreateImageVariantAsync(request);
            HandleResponse(response);
        }

        private void HandleResponse(CreateImageVariantResponse response)
        {
            if (response.Successful)
            {
                var imageData = response.Images[0];
                Debug.Log($"CreateImageVariant.Success. Image url: {imageData.Url}");

                if (response.ResponseFormat == ImageResponseFormat.Texture2D)
                {
                    View = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    View.name = "CreateImageVariantExampleView";
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
            if (View)
            {
                if (Application.isPlaying)
                    Destroy(View);
                else
                    DestroyImmediate(View);
            }
        }
    }
}
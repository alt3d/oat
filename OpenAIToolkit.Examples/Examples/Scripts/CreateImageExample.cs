using UnityEngine;

namespace OpenAIToolkit.Examples
{
    public class CreateImageExample : MonoBehaviour
    {
        public string ApiKey;
        public string Prompt = "A cute baby sea otter wearing a beret";
        public int Count = 1;
        public ImageSize ImageSize = ImageSize.x256;
        public ImageResponseFormat ResponseFormat = ImageResponseFormat.Texture2D;
        private GameObject View;

        [ContextMenu("Send request")]
        public void SendRequest()
        {
            DeleteView();

            var client = new OpenAIClient(ApiKey);

            var request = new CreateImageRequest(Prompt) {
                ResponseFormat = ResponseFormat,
                Count = Count,
                Size = ImageSize
            };

            client.Image.CreateImage(request, HandleResponse);
        }

        [ContextMenu("Send request async")]
        private async void SendRequestAsync()
        {
            DeleteView();

            var client = new OpenAIClient(ApiKey);

            var request = new CreateImageRequest(Prompt) {
                ResponseFormat = ResponseFormat,
                Count = Count,
                Size = ImageSize
            };

            var response = await client.Image.CreateImageAsync(request);
            HandleResponse(response);
        }

        private void HandleResponse(CreateImageResponse response)
        {
            if (response.Successful)
            {
                var imageData = response.Images[0];
                Debug.Log($"CreateImage.Success. Image url: {imageData.Url}");

                if (response.ResponseFormat == ImageResponseFormat.Texture2D)
                {
                    View = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    View.name = "CreateImageExampleView";
                    View.GetComponent<Renderer>().sharedMaterial.mainTexture = imageData.Texture;
                }
            }
            else
            {
                Debug.LogError($"CreateImage.Error. Message: {response.Error.Message}");
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
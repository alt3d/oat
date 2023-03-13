using UnityEngine;

namespace OpenAIToolkit.Examples
{
    public class CreateImageEditExample : MonoBehaviour
    {
        public string ApiKey;
        public string Prompt = "A sunlit indoor lounge area with a pool containing a flamingo";
        public Texture2D Image;
        public Texture2D Mask;
        public int Count = 1;
        public ImageSize ImageSize = ImageSize.x256;
        public ImageResponseFormat ResponseFormat = ImageResponseFormat.Texture2D;
        private GameObject View;

        [ContextMenu("Send request")]
        public void SendRequest()
        {
            DeleteView();

            var client = Factory.CreateClient(ApiKey);

            var request = new CreateImageEditRequest(Image, Prompt) {
                Mask = Mask,
                ResponseFormat = ResponseFormat,
                Count = Count,
                Size = ImageSize
            };

            client.Image.CreateImageEdit(request, HandleResponse);
        }

        [ContextMenu("Send request async")]
        private async void SendRequestAsync()
        {
            DeleteView();

            var client = Factory.CreateClient(ApiKey);

            var request = new CreateImageEditRequest(Image, Prompt) {
                Mask = Mask,
                ResponseFormat = ResponseFormat,
                Count = Count,
                Size = ImageSize
            };

            var response = await client.Image.CreateImageEditAsync(request);
            HandleResponse(response);
        }

        private void HandleResponse(CreateImageEditResponse response)
        {
            if (response.Successful)
            {
                var imageData = response.Images[0];
                Debug.Log($"CreateImageEdit.Success. Image url: {imageData.Url}");

                if (response.ResponseFormat == ImageResponseFormat.Texture2D)
                {
                    View = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    View.name = "CreateImageEditExampleView";
                    View.GetComponent<Renderer>().sharedMaterial.mainTexture = imageData.Texture;
                }
            }
            else
            {
                Debug.LogError($"CreateImageEdit.Error. Message: {response.Error.Message}");
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
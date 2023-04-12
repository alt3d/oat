using UnityEngine.Networking;

namespace OpenAIToolkit
{
    /// <summary>
    ///     OpenAI Authentication Interceptor
    /// </summary>
    public class OpenAIAuthenticationInterceptor : IAuthenticationInterceptor
    {
        private readonly string ApiKey;
        private readonly string Organization;

        /// <summary>
        ///     Create a new OpenAI Authentication Interceptor
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="organization"></param>
        public OpenAIAuthenticationInterceptor(string apiKey, string organization = null)
        {
            ApiKey = apiKey;
            Organization = organization;
        }

        /// <summary>
        ///     Implement OpenAI authorization headers
        /// </summary>
        /// <param name="webRequest"></param>
        public void Intercept(UnityWebRequest webRequest)
        {
            webRequest.SetRequestHeader("Authorization", $"Bearer {ApiKey}");

            if (!string.IsNullOrWhiteSpace(Organization))
                webRequest.SetRequestHeader("OpenAI-Organization", Organization);
        }
    }
}
using UnityEngine.Networking;

namespace OpenAIToolkit
{
    /// <summary>
    ///     An interface for authentication interceptors.
    /// </summary>
    public interface IAuthenticationInterceptor
    {
        /// <summary>
        ///     Intercepts a web request.
        /// </summary>
        /// <param name="webRequest"> Web request for interception</param>
        void Intercept(UnityWebRequest webRequest);
    }
}
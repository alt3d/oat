using System.Collections.Generic;

namespace OpenAIToolkit
{
    /// <summary>
    ///     Create moderation response
    /// </summary>
    public class CreateModerationResponse : BaseResponse
    {
        /// <summary>
        ///     The ID of the moderation.
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        ///     Model used for the moderation.
        /// </summary>
        public string Model { get; internal set; }

        /// <summary>
        ///     Moderation results.
        /// </summary>
        public List<ModerationResult> Results { get; internal set; }
    }
}
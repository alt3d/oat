using System.Collections.Generic;

namespace OpenAIToolkit
{
    /// <summary>
    ///     Model data in OpenAI.
    /// </summary>
    public class Model
    {
        /// <summary>
        ///     The unique identifier.
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        ///     Represents the time when the model was created. The value is expressed in Unix timestamp format.
        /// </summary>
        public int Created { get; internal set; }

        /// <summary>
        ///     The account that owns the Model.
        /// </summary>
        public string OwnedBy { get; internal set; }

        /// <summary>
        ///     The permissions associated with the Model.
        /// </summary>
        public List<Permission> Permissions { get; internal set; }

        /// <summary>
        ///     The root ID of the Model.
        /// </summary>
        public string Root { get; internal set; }

        /// <summary>
        ///     The parent ID of the Model.
        /// </summary>
        public string Parent { get; internal set; }
    }
}
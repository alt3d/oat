using System;

namespace OpenAIToolkit
{
    [Serializable]
    internal class ErrorDto
    {
        public ErrorDataDto error;

        public Error Parse()
        {
            return new Error {
                Message = error.message,
                Type = error.type,
                Param = error.param,
                Code = error.code
            };
        }
    }
}
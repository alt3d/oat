using System;
using System.Collections.Generic;

namespace OpenAIToolkit
{
    [Serializable]
    internal class ImageResponseDto
    {
        public int created;
        public List<ImageDataDto> data;
    }
}
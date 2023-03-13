using System;

namespace OpenAIToolkit
{
    internal static class Extensions
    {
        public static string GetStringValue(this ImageSize size)
        {
            switch (size)
            {
                case ImageSize.x256: return "256x256";
                case ImageSize.x512: return "512x512";
                case ImageSize.x1024: return "1024x1024";
                default: throw new ArgumentException($"Invalid ImageSize: {size}");
            }
        }

        public static string GetStringValue(this ChatRole role)
        {
            switch (role)
            {
                case ChatRole.System: return "system";
                case ChatRole.User: return "user";
                case ChatRole.Assistant: return "assistant";
                default: throw new ArgumentException($"Invalid ChatRole: {role}");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;

namespace OpenAIToolkit
{
    internal static class Ensure
    {
        public static void ArgumentNotNull(string arg, string argName)
        {
            if (string.IsNullOrWhiteSpace(arg))
                throw new ArgumentNullException(argName);
        }

        public static void ArgumentNotNull(object arg, string argName)
        {
            if (arg == null)
                throw new ArgumentNullException(argName);
        }

        public static void ArgumentNotNull<T>(List<T> list, string argName)
        {
            if (list == null)
                throw new ArgumentNullException(argName);

            if (list.Count == 0)
                throw new ArgumentException("List cannot be empty", argName);
        }

        public static void FileExists(string filepath)
        {
            if (!File.Exists(filepath))
                throw new FileNotFoundException(filepath);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace MimeTypeMap.List
{
    public static class MimeTypeMap
    {
        /// <summary>
        /// Gets the MIME by file extension.
        /// </summary>
        /// <param name="extension">The file extension.</param>
        /// <returns>List&lt;System.String&gt;Mime List.</returns>
        /// <remarks>if there is no matching mimetype then will retrun "application/octet-stream"</remarks>
        public static IEnumerable<string> GetMimeType(string extension)
        {
            if (string.IsNullOrWhiteSpace(extension))
            {
                throw new ArgumentNullException(nameof(extension), "extension argument is null or empty.");
            }

            if (!extension.StartsWith("."))
            {
                extension = $".{extension}";
            }

            if (IsSpecialExtension(extension))
            {
                return specialMappings.TryGetValue(extension, out List<string> mime) ? mime : new List<string>() { "application/octet-stream" };
            }

            return new List<string>() { MimeTypes.MimeTypeMap.GetMimeType(extension) ?? "application/octet-stream" };
        }

        /// <summary>
        /// Gets the extensions by mime type.
        /// </summary>
        /// <param name="mimeType">Type of the MIME.</param>
        /// <returns>IEnumerable&lt;System.String&gt; All known file extensions.</returns>
        public static IEnumerable<string> GetExtension(string mimeType)
        {
            if (string.IsNullOrWhiteSpace(mimeType))
            {
                throw new ArgumentNullException(nameof(mimeType));
            }

            if (mimeType.StartsWith("."))
            {
                throw new ArgumentException($"Requested mime type is not valid: {mimeType}", nameof(mimeType));
            }

            if (IsSpecialMimeType(mimeType))
            {
                var extension = specialMappings.FirstOrDefault(x => x.Value.Contains(mimeType, StringComparer.OrdinalIgnoreCase)).Key;
                return new List<string>() { extension };
            }

            return new List<string>() { MimeTypes.MimeTypeMap.GetExtension(mimeType) };
        }

        private static bool IsSpecialExtension(string extension)
        {
            return extension == ".mp3" || extension == ".zip";
        }

        private static bool IsSpecialMimeType(string mimeType)
        {
            var extension = specialMappings.FirstOrDefault(x => x.Value.Contains(mimeType, StringComparer.OrdinalIgnoreCase)).Key;
            return extension == ".mp3" || extension == ".zip";
        }

        private static Dictionary<string, List<string>> specialMappings =
            new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
            {
                {".mp3", new List<string>() {"audio/mpeg", "audio/mpeg3", "audio/x-mpeg-3"}},
                {".zip", new List<string>() {"application/zip", "application/octet-stream", "application/x-zip-compressed"} }
            };
    }
}

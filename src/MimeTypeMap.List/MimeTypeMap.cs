using System;
using System.Collections.Generic;
using System.Linq;

namespace MimeTypeMap.List
{
    public static class MimeTypeMap
    {
        private static readonly Lazy<IDictionary<string, List<string>>> Mappings;
        private static readonly Dictionary<string, List<string>> SpecialMappings =
            new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
            {
                {".mp3", new List<string>() {"audio/mpeg", "audio/mpeg3", "audio/x-mpeg-3"}},
                {".zip", new List<string>() {"application/zip", "application/octet-stream", "application/x-zip-compressed"} }
            };
        static MimeTypeMap()
        {
            Mappings = new Lazy<IDictionary<string, List<string>>>(BuildMappings);
        }

        private static IDictionary<string, List<string>> BuildMappings()
        {
            var mapping = MimeMapping.Mappings;
            foreach (var pair in SpecialMappings)
            {
                mapping[pair.Key] = pair.Value;
            }
            return mapping;
        }

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

            return Mappings.Value.TryGetValue(extension, out List<string> mime) ? mime : new List<string>() { "application/octet-stream" };
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

            return Mappings.Value.Where(s => s.Value.Contains(mimeType, StringComparer.OrdinalIgnoreCase)).Select(s => s.Key);
        }


    }
}

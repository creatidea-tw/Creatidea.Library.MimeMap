namespace MimeTypeMap.List
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class MimeTypeMap
    {
        private static readonly Lazy<IDictionary<string, List<string>>> Mappings;

        static MimeTypeMap()
        {
            Mappings = new Lazy<IDictionary<string, List<string>>>(BuildMappings);
        }

        private static IDictionary<string, List<string>> BuildMappings()
        {
            // need ToList() to avoid modifying while still enumerating
            var cache = MappingList.Mappings.ToList();

            // adding reverse mappings, so the dictionary contains both mappings of extensions to mime types and mime types to extensions.
            foreach (var mapping in cache)
            {
                if (!MappingList.Mappings.ContainsKey(mapping.Value.FirstOrDefault()))
                {
                    MappingList.Mappings.Add(mapping.Value.FirstOrDefault(), new List<string>() { mapping.Key });
                }
            }

            return MappingList.Mappings;
        }

        /// <summary>
        /// Gets the MIME.
        /// </summary>
        /// <param name="extension">The file extension.</param>
        /// <returns>List&lt;System.String&gt;Mime List.</returns>
        public static List<string> GetMimeType(string extension)
        {
            if (string.IsNullOrWhiteSpace(extension))
            {
                throw new ArgumentNullException(nameof(extension), "extension argument is null or empty.");
            }

            if (!extension.StartsWith("."))
            {
                extension = "." + extension;
            }

            List<string> mime;

            return Mappings.Value.TryGetValue(extension, out mime) ? mime : new List<string>() { "application/octet-stream" };
        }

        /// <summary>
        /// Gets the extension.
        /// </summary>
        /// <param name="mimeType">Type of the MIME.</param>
        /// <returns>List&lt;System.String&gt;file extension.</returns>
        public static List<string> GetExtension(string mimeType)
        {
            if (string.IsNullOrWhiteSpace(mimeType))
            {
                throw new ArgumentNullException(nameof(mimeType));
            }

            if (mimeType.StartsWith("."))
            {
                throw new ArgumentException("Requested mime type is not valid: " + mimeType);
            }

            List<string> extension;

            if (Mappings.Value.TryGetValue(mimeType, out extension))
            {
                return extension;
            }

            throw new ArgumentException("Requested mime type is not registered: " + mimeType);
        }

        /// <summary>
        /// Gets the known extensions.
        /// </summary>
        /// <param name="mimeType">Type of the MIME.</param>
        /// <returns>IEnumerable&lt;System.String&gt; All known file extensions.</returns>
        public static IEnumerable<string> GetKnownExtensions(string mimeType)
        {
            if (string.IsNullOrWhiteSpace(mimeType))
            {
                throw new ArgumentNullException(nameof(mimeType));
            }

            if (mimeType.StartsWith("."))
            {
                throw new ArgumentException("Requested mime type is not valid: " + mimeType);
            }

            return Mappings.Value.Where(s => s.Value.Contains(mimeType.ToLower())).Select(s => s.Key);
        }
    }
}

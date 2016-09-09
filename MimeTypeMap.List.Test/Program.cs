namespace MimeTypeMap.List.Test
{
    using System;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("txt -> ");
            foreach (string mime in MimeTypeMap.GetMimeType("txt"))
            {
                Console.WriteLine(mime);
            }

            // demo one extension have multipule mime
            Console.WriteLine();
            Console.WriteLine("zip -> ");
            foreach (string mime in MimeTypeMap.GetMimeType("zip"))
            {
                Console.WriteLine(mime);
            }

            // demo get extension from mime type
            Console.WriteLine();
            Console.WriteLine("audio/wav -> ");
            foreach (string mime in MimeTypeMap.GetExtension("audio/wav"))
            {
                Console.WriteLine(mime);
            }

            // demo get extension from mime type
            Console.WriteLine();
            Console.WriteLine("application/octet-stream -> ");
            foreach (string mime in MimeTypeMap.GetExtension("application/octet-stream"))
            {
                Console.WriteLine(mime);
            }
        }
    }
}

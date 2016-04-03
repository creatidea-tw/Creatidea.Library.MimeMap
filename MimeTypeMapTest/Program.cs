namespace MimeTypeMap.List.Test
{
    using System;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("txt -> " + MimeTypeMap.GetMimeType("txt"));
            Console.WriteLine("audio/wav -> " + MimeTypeMap.GetExtension("audio/wav"));
        }
    }
}

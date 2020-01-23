using System;
using System.Linq;

namespace hello.ocr
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var fileName = args.FirstOrDefault() ?? "cicero_en.png";
            Console.WriteLine($"Initializing OCR engine...");
            using var parser = new TesseractParser();

            Console.WriteLine($"Parsing '{fileName}'...");
            using var page = parser.Parse(fileName);
            Console.WriteLine($"Parsing mean confidence: {page.GetMeanConfidence()}");
            Console.WriteLine("Parsed text:");
            Console.WriteLine(page.GetText());
        }
    }
}
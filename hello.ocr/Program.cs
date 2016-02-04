using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using WindowsPreview.Media.Ocr;

namespace hello.ocr
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var fileName = "cicero_en.png";

            var ocrResult = Recognize(fileName, OcrLanguage.English).Result;

            var text = string.Join(Environment.NewLine, ocrResult.Lines);
            Console.WriteLine(text);
        }

        private static async Task<OcrResult> Recognize(string fileName, OcrLanguage language)
        {
            var ocrEngine = new OcrEngine(language);
            using (var stream = File.OpenRead(fileName))
            {
                var winRtStream = stream.AsRandomAccessStream();
                var decoder = await BitmapDecoder.CreateAsync(winRtStream);
                var bitmap = await decoder.GetPixelDataAsync();
                return await ocrEngine.RecognizeAsync(decoder.PixelHeight, decoder.PixelWidth, bitmap.DetachPixelData());
            }
        }
    }
}
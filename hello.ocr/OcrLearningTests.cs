using System;
using System.Diagnostics;
using System.IO;
using Windows.Graphics.Imaging;
using WindowsPreview.Media.Ocr;
using NUnit.Framework;

namespace hello.ocr
{
    /// <summary>
    /// http://www.hanselman.com/blog/HowToCallWinRTAPIsInWindows8FromCDesktopApplicationsWinRTDiagram.aspx
    /// https://software.intel.com/en-us/articles/using-winrt-apis-from-desktop-applications
    /// </summary>
    [TestFixture]
    internal class OcrLearningTests
    {
        [Test]
        public async void TestOcr(string fileName)
        {
            var ocrEngine = new OcrEngine(OcrLanguage.English);

            using (var stream = File.OpenRead(fileName))
            {
                var winRtStream = stream.AsRandomAccessStream();
                var decoder = await BitmapDecoder.CreateAsync(winRtStream);
                var bitmap = await decoder.GetPixelDataAsync();
                var ocrResult = await ocrEngine.RecognizeAsync(decoder.PixelHeight, decoder.PixelWidth, bitmap.DetachPixelData());
                var text = string.Join(Environment.NewLine, ocrResult.Lines);
                Trace.WriteLine(text);
            }
        }
    }
}

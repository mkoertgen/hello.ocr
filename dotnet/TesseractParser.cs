using System;
using Tesseract;

namespace hello.ocr
{
    public class TesseractParser : IDisposable
    {
        private readonly TesseractEngine _engine;

        public TesseractParser(string language = "eng", 
            EngineMode engineMode = EngineMode.Default, string dataPath= "tessdata")
        {
            _engine = new TesseractEngine(dataPath, language, engineMode);
            
        }
        public void Dispose()
        {
            _engine?.Dispose();
        }

        public Page Parse(string fileName)
        {
            using var image = Pix.LoadFromFile(fileName);
            return _engine.Process(image);
        }
    }
}
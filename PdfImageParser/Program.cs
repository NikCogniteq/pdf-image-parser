using Tesseract;

namespace PdfImageParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var imageName = "Testbrev1.png"; // image from 'images' folder
            var language = "swe"; // swe - Swedish, eng - English

            var projectPath = Path.GetFullPath(@"..\..\..\");
            var dataPath = Path.Combine(projectPath, "tessdata");
            var imagePath = Path.Combine(projectPath, "images", imageName);

            // Create a TesseractEngine
            using var engine = new TesseractEngine(dataPath, language, EngineMode.Default);
            // Load the image
            using var img = Pix.LoadFromFile(imagePath);
            // Perform OCR on the image
            using var page = engine.Process(img);
            // Get the recognized text
            string text = page.GetText();
            Console.WriteLine("Recognized Text:");
            Console.WriteLine(text);
            Console.ReadLine();
        }
    }
}
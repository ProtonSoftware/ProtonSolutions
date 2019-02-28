using System;

namespace GoogleHashCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var converter = new PhotoConverter("SCIEZKA");
            converter.ReadImagesFromFile();
            converter.AttachImagesToSlides();
            converter.CreateSlideShow();
            converter.ExportSlideShow();
        }
    }
}

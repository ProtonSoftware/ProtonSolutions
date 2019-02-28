using System.Collections.Generic;
using System.IO;

namespace GoogleHashCode
{
    /// <summary>
    ///
    /// </summary>
    public class PhotoConverter
    {
        #region Public Properties

        private string mPath;
        private int mAmount;

        public List<Image> Images { get; set; }
        public List<Slide> Slides { get; set; }
        public Slideshow Slideshow { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        ///
        /// </summary>
        public PhotoConverter(string path)
        {
            mPath = path;
        }

        #endregion

        public void ReadImagesFromFile()
        {
            var fileLines = File.ReadAllLines(mPath);
            mAmount = int.Parse(fileLines[0]);
            for (int i = 1; i < fileLines.Length; i++)
            {
                var elements = fileLines[i].Split(" ");
                var tags = new List<string>();
                for (int j = 2; j < elements.Length; j++)
                {
                    tags.Add(elements[j]);
                }

                var image = new Image(i - 1, elements[0] == "V" ? Orientation.Vertical : Orientation.Horizontal, int.Parse(elements[1]), tags);

                Images.Add(image);
            }
            
        }

        public void AttachImagesToSlides()
        {

        }

        public void CreateSlideShow()
        {
            Slideshow = new Slideshow(Slides);
        }

        public void ExportSlideShow()
        {
            var path = "result.txt";
            var lines = new List<string>();

            lines.Add(Slideshow.Amount.ToString());
            foreach (var slide in Slideshow.Slides)
                lines.Add(slide.GetImageOutput());

            File.WriteAllLines(path, lines);
        }
    }
}

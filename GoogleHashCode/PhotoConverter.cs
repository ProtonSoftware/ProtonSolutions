using System.Collections.Generic;
using System.IO;
using System.Linq;

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
        private int mAmountOfVertical = 0;

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

                if (image.Orientation == Orientation.Vertical)
                    mAmountOfVertical++;

                Images.Add(image);
            }

            RemoveUnneededImages();
            
        }

        public void AttachImagesToSlides()
        {
            foreach (var image in Images)
            {
                if (image.Orientation == Orientation.Horizontal)
                {
                    var slide = new Slide(new List<Image> { image });
                    Slides.Add(slide);
                }
            }
        }

        public void CreateSlideShow()
        {
            Slideshow = new Slideshow(Slides);
        }

        public void ExportSlideShow()
        {
            var path = "result.txt";
            var lines = new List<string>
            {
                Slideshow.Amount.ToString()
            };
            foreach (var slide in Slideshow.Slides)
                lines.Add(slide.GetImageOutput());

            File.WriteAllLines(path, lines);
        }

        private void RemoveUnneededImages()
        {
            if (mAmountOfVertical % 2 != 0)
            {
                var singleTaggedImages = Images.Where(x => x.Orientation == Orientation.Vertical && x.AmountOfTags == 1).ToList();
                var imageToDelete = GetBestFittingImageForDeletion(singleTaggedImages);
                Images.Remove(imageToDelete);
            }
            foreach (var image in Images)
            {
                if (image.Orientation == Orientation.Horizontal && image.Tags.Count < 2 && mAmount > 1)
                {
                    Images.Remove(image);
                }
            }
        }

        private Image GetBestFittingImageForDeletion(List<Image> singleTaggedImages)
        {
            var mostFrequestTag = Helpers.FindMaximum(Helpers.GetFrequencyOfTags(singleTaggedImages));

            return singleTaggedImages.Where(x => x.Tags[0] == mostFrequestTag).FirstOrDefault();
        }
    }
}

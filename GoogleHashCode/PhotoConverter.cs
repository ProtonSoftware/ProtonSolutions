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
    }
}

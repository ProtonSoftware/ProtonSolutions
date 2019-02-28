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

        public void ReadTextFromFile()
        {
            var fileLines = File.ReadAllLines(mPath);
            mAmount = int.Parse(fileLines[0]);
            for (int i = 1; i < fileLines.Length; i++)
            {
                var image = new Image();
            }
            
        }
    }
}

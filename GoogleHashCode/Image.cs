using System.Collections.Generic;

namespace GoogleHashCode
{
    /// <summary>
    ///
    /// </summary>
    public class Image
    {
        #region Public Properties

        public int Id { get; set; }
        public Orientation Orientation { get; set; }
        public int AmountOfTags { get; set; }
        public List<string> Tags { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        ///
        /// </summary>
        public Image(int id, Orientation orientation, int amountTags, List<string> tags)
        {
            Id = id;
            Orientation = orientation;
            AmountOfTags = amountTags;
            Tags = tags;
        }

        #endregion
    }
}

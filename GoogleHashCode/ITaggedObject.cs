using System.Collections.Generic;

namespace GoogleHashCode
{
    /// <summary>
    ///
    /// </summary>
    public interface ITaggedObject
    {
        int AmountOfTags { get; set; }
        List<string> Tags { get; set; }
    }
}

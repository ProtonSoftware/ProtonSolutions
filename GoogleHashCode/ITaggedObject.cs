using System.Collections.Generic;

namespace GoogleHashCode
{
    /// <summary>
    ///
    /// </summary>
    public interface ITaggedObject
    {
        int AmountOfTags { get; }
        List<string> Tags { get; }
    }
}

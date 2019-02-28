using System.Collections.Generic;

namespace GoogleHashCode
{
    /// <summary>
    ///
    /// </summary>
    public static class Helpers
    {
        public static Dictionary<string, int> GetFrequencyOfTags(List<Image> images)
        {
            var dictionary = new Dictionary<string, int>();

            foreach (var image in images)
            {
                foreach (var tag in image.Tags)
                {
                    if (!dictionary.TryAdd(tag, 1))
                    {
                        dictionary[tag]++;
                    }
                }
            }

            return dictionary;
        }

        public static KeyValuePair<string, int> FindMaximum(this Dictionary<string, int> dict)
        {
            string max = null;
            int v = -1;
            foreach (var k in dict.Keys)
            {
                if (dict[k]>v)
                {
                    v = dict[k];
                    max = k;
                }
            }
            return new KeyValuePair<string, int>(max, v);
        }
    }
}

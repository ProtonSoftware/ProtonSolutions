using System.Collections.Generic;
using System.Linq;

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

        public static string FindMaximum(this Dictionary<string, int> dict)
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
            return max;
        }

        public static List<Slide> SortByTags(this List<Slide> list)
        {
            return list.OrderByDescending(x => x.AmountOfTags).ToList();
        }

        public static Slide matchVerticals(Image first, List<Image> list)
        {
            List<int> commonElements = new List<int>(list.Count - 1);
            for (int i = 0; i < list.Count-1; i++)
            {
                commonElements[i] = 0;
            }

            for (int i=1; i<list.Count; i++)
            {
                for (int j=0; j<first.AmountOfTags; j++)
                {
                    for (int k = 0; k < list[i].AmountOfTags; k++)
                    {
                        if (first.Tags[j] == list[i].Tags[k])
                        {
                            commonElements[i-1]++;
                        }
                    }
                }
            }

            int maxValue = 0;
            foreach (var value in commonElements)
            {
                if (value > maxValue)
                {
                    maxValue = value;
                }
            }

            var second = list[commonElements.IndexOf(maxValue) + 1];
            var images = new List<Image>
            {
                first,
                second
            };

            return new Slide(images);
        }
    }
}

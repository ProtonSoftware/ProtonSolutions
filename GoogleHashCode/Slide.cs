using System;
using System.Collections.Generic;

namespace GoogleHashCode
{
    public class Slide
    {
        public List<Image> elems {get; set;}
        public List<string> Tags {get {
            var tmp = new List<string>();
            foreach (var e in elems)
                foreach (var t in e.Tags)
                    if (!tmp.Contains(t))
                        tmp.Add(t);
            return tmp;
        }}
        public int AmountOfTags { get {return Tags.Count;} }

        public Slide(List<Image> imglist)
        {
            elems = imglist;
        }
    }
}
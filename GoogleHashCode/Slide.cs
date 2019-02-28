using System;
using System.Collections.Generic;

namespace GoogleHashCode
{
    public class Slide
    {
        private List<Image> mElems;
        public List<Image> Elems {get {return mElems;} set {
            mElems = value;
            var tmp = new List<string>();
            foreach (var e in mElems)
                foreach (var t in e.Tags)
                    if (!tmp.Contains(t))
                        tmp.Add(t);
            mTags = tmp;
        }}
        private List<string> mTags;
        public List<string> Tags {get {return mTags;}}
        public int AmountOfTags { get {return mTags.Count;} }

        public Slide(List<Image> imglist)
        {
            Elems = imglist;
        }
    }
}
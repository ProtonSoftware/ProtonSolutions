using System;
using System.Collections.Generic;

namespace GoogleHashCode
{
    public class Slideshow
    {
        private List<Slide> mSlides;
        public List<Slide> Slides {get {return mSlides;} set {
            mSlides = value;
            Amount = mSlides.Count;
        }}
        public int Amount {get; private set;}

        public Slideshow(List<Slide> slides)
        {
            Slides = slides;
        }

        private int interest(int pos)
        {
            Slide[] compare = new Slide[2];
            compare[0] = mSlides[pos];
            compare[1] = mSlides[pos+1];
            int first = 0, common = 0, second = 0;
            foreach (var t in compare[0].Tags)
            {
                if (compare[1].Tags.Contains(t))
                    common++;
                else
                    first++;
            }
            second = compare[1].AmountOfTags - common;
            return Math.Min(Math.Min(first, common),second);
        }
    }
}
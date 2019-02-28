using System;
using System.Collections.Generic;

namespace GoogleHashCode
{
    public class Slideshow
    {
        private List<Slide> mSlides;
        public List<Slide> Slides {get {return mSlides;} set {
            mSlides = value;
            Length = mSlides.Count;
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
            return 0;
        }
    }
}
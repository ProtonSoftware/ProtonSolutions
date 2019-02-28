using System;
using System.Collections.Generic;

namespace GoogleHashCode
{
    public class Slideshow
    {
        public List<Slide> Slides {get; set;}

        public Slideshow(List<Slide> slides)
        {
            Slides = slides;
        }
    }
}
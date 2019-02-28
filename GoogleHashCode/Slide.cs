using System;
using System.Collections.Generic;

namespace GoogleHashCode
{
    public class Slide
    {
        public List<Image> elems {get; set;}

        public Slide(List<Image> imglist)
        {
            elems = imglist;
        }
    }
}
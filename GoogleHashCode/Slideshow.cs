using System;
using System.Collections.Generic;

namespace GoogleHashCode
{
    public class Slideshow
    {
        public List<Slide> list {get; set;}

        public Slideshow(List<Image> imglist)
        {
            list = imglist;
        }

        public void Reorder()
        {
        }

        private void Interest(int pos)
        {
        }
    }
}
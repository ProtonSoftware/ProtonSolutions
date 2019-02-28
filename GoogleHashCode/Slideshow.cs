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

        public void Optimize()
        {
            var newOrder = new List<Slide>();
            var tmp = Slides.SortByTags();
            int all = tmp.Count;
            while (tmp.Count > 0)
            {
                newOrder.Add(tmp[tmp.Count-1]);
                newOrder.Add(tmp[0]);
            }
            Slides = newOrder;
        }

        public int Score()
        {
            int tmp = 0;
            for (int i = 0; i < Amount-1; i++)
                tmp += Interest(i);
            return tmp;
        }

        ///<summary>
        /// Compares slides from pos and pos+1
        ///</summary>
        private int Interest(int pos)
        {
            Slide[] compare = new Slide[2];
            compare[0] = Slides[pos];
            compare[1] = Slides[pos+1];
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
using System;
using System.Collections.Generic;

namespace BeerDB
{
    public class BarTag
    {
        public string Text { get; set; }
        public List<Bar> TaggedBars { get; set; }

        public BarTag(string text)
        {
            TaggedBars = new List<Bar>();
            Text = text;
        }

        public BarTag()
        {
        }
    }
}

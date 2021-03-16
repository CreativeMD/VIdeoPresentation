using System;
using System.Collections.Generic;
using System.Text;

namespace VideoPresentationLib
{
    class VideoEntry
    {
        public bool Loop { get; private set; }
        public string Filename { get; private set; }

        protected List<BreakPoint> points = new List<BreakPoint>();

    }
}

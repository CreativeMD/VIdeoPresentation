using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace VideoPresentationLib
{
    public class VideoEntry : VideoPresentationEvent
    {
        public bool Loop { get; set; }
        public string Filename { get; private set; }

        //protected List<BreakPoint> points = new List<BreakPoint>();

        public VideoEntry(string filename)
        {
            this.Filename = filename;
        }

        public VideoEntry(JObject json)
        {
            this.Filename = json.Value<string>("file");
            this.Loop = json.Value<bool>("loop");
        }

        public JObject toJson()
        {
            JObject json = new JObject();
            json.Add("file", Filename);
            json.Add("loop", Loop);
            return json;
        }

    }
}

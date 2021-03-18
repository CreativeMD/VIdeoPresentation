using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace VideoPresentationLib
{
    public class VideoPart : VideoPresentationPart
    {

        public bool StopAtEnd { get; set; }

        public bool Loop { get; set; }

        public string Filename { get; private set; }

        public VideoPart(string filename)
        {
            this.Filename = filename;
            this.StopAtEnd = true;
        }

        public VideoPart(JObject json)
        {
            this.Filename = json.Value<string>("file");
            this.Loop = json.Value<bool>("loop");
            this.StopAtEnd = json.Value<bool>("stop");
        }

        public JObject toJson()
        {
            JObject json = new JObject();
            json.Add("file", Filename);
            json.Add("loop", Loop);
            json.Add("stop", StopAtEnd);
            return json;
        }

    }
}

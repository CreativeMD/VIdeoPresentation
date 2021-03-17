using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VideoPresentationLib
{
    public class VideoPresentation
    {

        public string FileName { get; private set; }

        public bool HasFile { get; private set; }
        public bool Modified { get; private set; }

        public List<VideoPresentationEvent> Entries { get; private set; }

        public VideoPresentation()
        {
            this.HasFile = false;
            this.Entries = new List<VideoPresentationEvent>();
        }

        public VideoPresentation(string filename)
        {
            this.FileName = filename;
            this.HasFile = true;
            this.loadFile();
        }

        public void setFilename(string filename)
        {
            this.FileName = filename;
            this.HasFile = true;
        }

        protected void loadFile()
        {
            if (!HasFile)
                throw new Exception();
            Entries = new List<VideoPresentationEvent>();
            if (File.Exists(FileName))
            {
                using (StreamReader r = new StreamReader(FileName))
                {
                    JObject json = JObject.Parse(r.ReadToEnd());
                    JToken token = null;
                    if (json.TryGetValue("elements", out token))
                    {
                        if (token.Type == JTokenType.Array)
                        {
                            foreach (var item in (JArray)token)
                            {
                                if (item.Type == JTokenType.Object)
                                    Entries.Add(new VideoEntry((JObject)item));
                            }
                        }
                    }
                }
            }
        }



        public void setModified()
        {
            this.Modified = true;
        }

        public void save()
        {
            JObject json = new JObject();
            JArray array = new JArray();
            foreach (var item in Entries)
                array.Add(item.toJson());
            json.Add("elements", array);
            File.WriteAllText(FileName, json.ToString());
            this.Modified = false;
        }

    }

    public interface VideoPresentationEvent
    {

        public JObject toJson();

    }
}

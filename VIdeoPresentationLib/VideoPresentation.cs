using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace VideoPresentationLib
{
    public class VideoPresentation
    {
        public string FileName
        {
            get { return FileName; }
            set
            {
                this.FileName = value;
                this.HasFile = true;
                this.loadFile();
            }
        }

        public bool HasFile { get; private set; }
        public bool Modified { get; private set; }

        public List<VideoPresentationEvent> entries = new List<VideoPresentationEvent>();

        public VideoPresentation()
        {
            this.FileName = null;
            this.HasFile = false;
        }

        public VideoPresentation(string filename)
        {
            this.FileName = filename;
        }

        protected void loadFile()
        {
            if (!HasFile)
                throw new Exception();
            using (StreamReader r = new StreamReader(FileName))
            {
                string json = r.ReadToEnd();

            }
        }



        public void setModified()
        {
            this.Modified = true;
        }

        public void save()
        {

        }

    }

    public interface VideoPresentationEvent
    {

    }
}

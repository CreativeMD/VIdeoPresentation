using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoPresentationLib;

namespace VIdeoPresentator
{

    public partial class Main : Form
    {
        public VideoPresentation presentation;
        public MediaPlayer player;
        public LibVLC lib;
        public bool fullscreen = false;
        public Rectangle beforeBounds;

        public Main()
        {
            InitializeComponent();
        }

        public void openPresentation(string filename)
        {
            if (lib == null)
            {
                Core.Initialize(@"C:\Program Files\VideoLAN\VLC");
                lib = new LibVLC("--input-repeat=2");
                player = new MediaPlayer(lib);
                vlcView.MediaPlayer = player;
            }
            presentation = new VideoPresentation(filename);
            //loadEvent(presentation.start());
            open.Visible = false;
        }

        public void endPresentation()
        {
            presentation = null;
            player.Stop();
            open.Visible = true;
        }

        private void open_Click(object sender, EventArgs e)
        {
            if (openpresentation.ShowDialog() == DialogResult.OK)
                openPresentation(openpresentation.FileName);
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
                openPresentation(args[1]);
        }

        public void loadEvent(VideoPresentationEvent evt)
        {
            if (evt is VideoEntry)
            {
                VideoEntry entry = (VideoEntry)evt;
                Media media = new Media(lib, entry.Filename);
                player.Play(media);
            }
            else
                player.Stop();
        }

        private void Main_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (presentation != null && !e.Handled)
                if (e.KeyChar == Convert.ToChar(Keys.Right))
                {
                    loadEvent(presentation.next());
                    e.Handled = true;
                }
                else if (e.KeyChar == Convert.ToChar(Keys.Left))
                {
                    loadEvent(presentation.previous());
                    e.Handled = true;
                }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (presentation != null)
                if (keyData == Keys.Right)
                {
                    loadEvent(presentation.next());
                    return true;
                }
                else if (keyData == Keys.Left)
                {
                    loadEvent(presentation.previous());
                    return true;
                }
                else if (keyData == Keys.F)
                {
                    toggleFullscreen();
                    return true;
                }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        public void toggleFullscreen()
        {
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.Bounds = beforeBounds;
                this.fullscreen = false;
            }
            else
            {
                this.beforeBounds = this.Bounds;
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.Bounds = Screen.PrimaryScreen.Bounds;
                Activate();
                this.fullscreen = true;
            }
        }

        private void vlcView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            toggleFullscreen();
        }
    }
}

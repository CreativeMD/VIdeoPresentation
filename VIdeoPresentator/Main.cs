using LibVLCSharp.Shared;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoPresentationLib;

namespace VideoPresentator
{

    public partial class Main : Form
    {
        public VideoPresentation presentation;
        public MediaPlayer player;
        public LibVLC lib;
        public bool fullscreen = false;
        public Rectangle beforeBounds;
        public VideoPresentationPart part;
        public WorkerThread worker = new WorkerThread();

        public Main()
        {
            InitializeComponent();
        }

        public void openPresentation(string filename)
        {
            if (lib == null)
            {
                Core.Initialize(@"C:\Program Files\VideoLAN\VLC");
                lib = new LibVLC(""); // new LibVLC("--input-repeat=2");
                player = new MediaPlayer(lib);
                player.EndReached += Player_EndReached;
                vlcView.MediaPlayer = player;
            }
            presentation = new VideoPresentation(filename);
            //loadEvent(presentation.start());
            open.Visible = false;
        }

        private void Player_EndReached(object sender, EventArgs e)
        {
            if (part != null && presentation != null)
                if (part.Loop)
                    worker.Queue(delegate { loadEvent(part); });
                else if (!part.StopAtEnd)
                    worker.Queue(delegate { loadEvent(presentation.next()); });
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

        public void loadEvent(VideoPresentationPart evt)
        {

            if (evt is VideoPart)
            {
                part = evt;
                VideoPart entry = (VideoPart)evt;
                Media media = new Media(lib, entry.Filename);
                player.Play(media);
            }
            else
            {
                part = null;
                //player.Stop();
            }
            if (!InvokeRequired)
                Invoke((MethodInvoker)delegate ()
                {
                    labelPart.Text = presentation.getCurrent() + "";
                });


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

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            worker.stop();
            worker = null;
        }
    }

    public class WorkerThread
    {
        public bool active;
        private ConcurrentQueue<Action> queue = new ConcurrentQueue<Action>();
        private Thread thread;

        public WorkerThread()
        {
            this.active = true;
            thread = new Thread(new ThreadStart(delegate
            {
                while (active)
                {
                    if (queue.IsEmpty)
                        Thread.Sleep(1);
                    Action action;
                    if (queue.TryDequeue(out action))
                        action.Invoke();
                }
            }));
            this.thread.Start();
        }

        public void Queue(Action action)
        {
            queue.Enqueue(action);
        }

        public void stop()
        {
            active = false;
        }

    }
}

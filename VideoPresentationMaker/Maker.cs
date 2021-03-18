using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoPresentationLib;

namespace VideoPresentationMaker
{
    public partial class Maker : Form
    {

        public VideoPresentation tempPresentation;
        public MenuStrip Menu;

        public Maker()
        {
            InitializeComponent();
            Menu = new MenuStrip();
            Menu.Parent = this;
            ToolStripMenuItem fileItem = new ToolStripMenuItem("File");
            Menu.Items.Add(fileItem);
            ToolStripMenuItem newItem = new ToolStripMenuItem("New");
            newItem.Click += NewItem_Click;
            fileItem.DropDownItems.Add(newItem);
            ToolStripMenuItem openItem = new ToolStripMenuItem("Open");
            openItem.Click += OpenItem_Click;
            fileItem.DropDownItems.Add(openItem);
            fileItem.DropDownItems.Add(new ToolStripSeparator());
            ToolStripMenuItem saveItem = new ToolStripMenuItem("Save");
            saveItem.Click += SaveItem_Click;
            fileItem.DropDownItems.Add(saveItem);
            ToolStripMenuItem saveAsItem = new ToolStripMenuItem("Save as");
            saveAsItem.Click += SaveAsItem_Click;
            fileItem.DropDownItems.Add(saveAsItem);
            ToolStripMenuItem closeItem = new ToolStripMenuItem("Close");
            closeItem.Click += CloseItem_Click;
            fileItem.DropDownItems.Add(closeItem);

            ToolStripMenuItem presentationItem = new ToolStripMenuItem("Presentation");
            Menu.Items.Add(presentationItem);
            ToolStripMenuItem presentateItem = new ToolStripMenuItem("Presentate");
            presentateItem.Click += PresentateItem_Click;
            presentationItem.DropDownItems.Add(presentateItem);

            addvideo.Multiselect = true;
        }

        private void PresentateItem_Click(object sender, EventArgs e)
        {
            if (hasPresentation() && tempPresentation.HasFile)
            {
                savePresentation(false);
                Process process = Process.Start("VideoPresentator.exe", tempPresentation.FileName);
            }
        }

        private void CloseItem_Click(object sender, EventArgs e)
        {
            closePresentation();
        }

        private void SaveAsItem_Click(object sender, EventArgs e)
        {
            savePresentation(true);
        }

        private void SaveItem_Click(object sender, EventArgs e)
        {
            savePresentation(false);
        }

        private void OpenItem_Click(object sender, EventArgs e)
        {
            if (closePresentation() && openpresentation.ShowDialog() == DialogResult.OK)
            {
                loadPresentation(new VideoPresentation(openpresentation.FileName));
            }
        }

        private void NewItem_Click(object sender, EventArgs e)
        {
            if (closePresentation())
                loadPresentation(new VideoPresentation());
        }

        public bool hasPresentation()
        {
            return tempPresentation != null;
        }

        public bool closePresentation()
        {
            if (hasPresentation() && tempPresentation.Modified)
            {
                DialogResult result = MessageBox.Show("Do you want to save before closing?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Cancel)
                    return false;
                if (result == DialogResult.Yes)
                    savePresentation(false);
            }
            add_video.Enabled = false;
            videoentries.Controls.Clear();
            return true;
        }

        public void savePresentation(bool save_as)
        {
            if (hasPresentation())
            {
                if (save_as || !tempPresentation.HasFile)
                {
                    if (savepresentationdialog.ShowDialog() == DialogResult.OK)
                    {
                        tempPresentation.setFilename(savepresentationdialog.FileName);
                        updateTitle();
                        tempPresentation.save();
                    }
                }
                else
                {
                    updateTitle();
                    tempPresentation.save();
                }
            }
        }

        public void updateTitle()
        {
            if (hasPresentation())
                if (tempPresentation.HasFile)
                    path.Text = tempPresentation.FileName;
                else
                    path.Text = "unsaved";
            else
                path.Text = "";
        }

        public void loadPresentation(VideoPresentation presentation)
        {
            tempPresentation = presentation;

            foreach (var entry in presentation.Entries)
                addEvent((VideoPart)entry);
            updateTitle();
            add_video.Enabled = true;
        }

        public void markModified()
        {
            if (hasPresentation())
                tempPresentation.setModified();
        }

        public void addEvent(VideoPart entry)
        {
            Panel box = new Panel();
            box.BorderStyle = BorderStyle.FixedSingle;
            box.Height = 100;
            box.Width = videoentries.Width - 28;
            Label label = new Label();
            label.AutoSize = true;
            label.Text = entry.Filename;
            box.Controls.Add(label);
            CheckBox check = new CheckBox();
            check.AutoSize = true;
            check.Text = "Loop";
            check.Top = 30;
            check.Checked = entry.Loop;
            check.CheckedChanged += delegate
            {
                entry.Loop = check.Checked;
            };
            box.Controls.Add(check);

            CheckBox stop = new CheckBox();
            stop.AutoSize = true;
            stop.Text = "Stop at the end";
            stop.Top = 60;
            stop.Checked = entry.StopAtEnd;
            stop.CheckedChanged += delegate
            {
                entry.StopAtEnd = stop.Checked;
            };
            box.Controls.Add(stop);

            Button remove = new Button();
            remove.Width = 20;
            remove.AutoSize = true;
            remove.Text = "x";
            remove.Left = box.Width - 40;
            remove.Click += delegate
            {
                videoentries.Controls.Remove(box);
                tempPresentation.Entries.Remove(entry);
                markModified();
            };
            box.Controls.Add(remove);
            videoentries.Controls.Add(box);
        }

        private void add_video_Click(object sender, EventArgs e)
        {
            if (addvideo.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in addvideo.FileNames)
                {
                    VideoPart entry = new VideoPart(item);
                    tempPresentation.Entries.Add(entry);
                    addEvent(entry);
                    markModified();
                }
            }
        }

        private void savepresentationdialog_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}

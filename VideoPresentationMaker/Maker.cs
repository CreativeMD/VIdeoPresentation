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

namespace VideoPresentationMaker
{
    public partial class Maker : Form
    {

        public VideoPresentation tempPresentation;

        public Maker()
        {
            InitializeComponent();
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
                if (result == DialogResult.Yes)
                {
                    savePresentation(false);
                    return true;
                }
                if (result == DialogResult.No)
                    return true;
                return false;
            }
            add_video.Enabled = false;
            return true;
        }

        public void savePresentation(bool save_as)
        {
            if (hasPresentation())
            {
                if (save_as || !tempPresentation.HasFile)
                {
                    DialogResult result = savepresentation.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        tempPresentation.FileName = savepresentationdialog.FileName;
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

        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.ClickedItem.Text);
            if (e.ClickedItem.Name == "save")
            {
                savePresentation(false);
            }
            else if (e.ClickedItem.Name == "save_as")
            {
                savePresentation(true);
            }
            else if (e.ClickedItem.Name == "new_file")
            {
                closePresentation();
                loadPresentation(new VideoPresentation());
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

            updateTitle();
            add_video.Enabled = true;
        }

        private void add_video_Click(object sender, EventArgs e)
        {

        }
    }
}

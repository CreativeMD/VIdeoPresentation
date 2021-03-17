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

        public Main()
        {
            InitializeComponent();
        }

        public void openPresentation(string filename)
        {
            presentation = new VideoPresentation(filename);
        }

        private void open_Click(object sender, EventArgs e)
        {
            if (openpresentation.ShowDialog() == DialogResult.OK)
                openPresentation(openpresentation.FileName);
        }
    }
}

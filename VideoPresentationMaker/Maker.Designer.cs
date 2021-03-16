
namespace VideoPresentationMaker
{
    partial class Maker
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.file = new System.Windows.Forms.ToolStripMenuItem();
            this.new_file = new System.Windows.Forms.ToolStripMenuItem();
            this.open = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.save = new System.Windows.Forms.ToolStripMenuItem();
            this.save_as = new System.Windows.Forms.ToolStripMenuItem();
            this.close = new System.Windows.Forms.ToolStripMenuItem();
            this.presentation = new System.Windows.Forms.ToolStripMenuItem();
            this.presentate = new System.Windows.Forms.ToolStripMenuItem();
            this.help = new System.Windows.Forms.ToolStripMenuItem();
            this.about = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.add_video = new System.Windows.Forms.Button();
            this.addvideo = new System.Windows.Forms.OpenFileDialog();
            this.openpresentation = new System.Windows.Forms.OpenFileDialog();
            this.savepresentationdialog = new System.Windows.Forms.SaveFileDialog();
            this.path = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file,
            this.presentation,
            this.help});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(784, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            this.menu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menu_ItemClicked);
            // 
            // file
            // 
            this.file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.new_file,
            this.open,
            this.toolStripSeparator1,
            this.save,
            this.save_as,
            this.close});
            this.file.Name = "file";
            this.file.Size = new System.Drawing.Size(37, 20);
            this.file.Text = "File";
            // 
            // new_file
            // 
            this.new_file.Name = "new_file";
            this.new_file.Size = new System.Drawing.Size(112, 22);
            this.new_file.Text = "New";
            // 
            // open
            // 
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(112, 22);
            this.open.Text = "Open";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // save
            // 
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(112, 22);
            this.save.Text = "Save";
            // 
            // save_as
            // 
            this.save_as.Name = "save_as";
            this.save_as.Size = new System.Drawing.Size(112, 22);
            this.save_as.Text = "Save as";
            // 
            // close
            // 
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(112, 22);
            this.close.Text = "Close";
            // 
            // presentation
            // 
            this.presentation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.presentate});
            this.presentation.Name = "presentation";
            this.presentation.Size = new System.Drawing.Size(85, 20);
            this.presentation.Text = "Presentation";
            // 
            // presentate
            // 
            this.presentate.Name = "presentate";
            this.presentate.Size = new System.Drawing.Size(129, 22);
            this.presentate.Text = "Presentate";
            // 
            // help
            // 
            this.help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.about});
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(44, 20);
            this.help.Text = "Help";
            // 
            // about
            // 
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(107, 22);
            this.about.Text = "About";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 55);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(760, 371);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // add_video
            // 
            this.add_video.Location = new System.Drawing.Point(12, 432);
            this.add_video.Name = "add_video";
            this.add_video.Size = new System.Drawing.Size(124, 29);
            this.add_video.TabIndex = 2;
            this.add_video.Text = "Add Video";
            this.add_video.UseVisualStyleBackColor = true;
            this.add_video.Click += new System.EventHandler(this.add_video_Click);
            // 
            // addvideo
            // 
            this.addvideo.FileName = "openFileDialog1";
            // 
            // openpresentation
            // 
            this.openpresentation.FileName = "open_presentation";
            this.openpresentation.Filter = "Video Presentation|.vpf";
            this.openpresentation.RestoreDirectory = true;
            // 
            // savepresentationdialog
            // 
            this.savepresentationdialog.Filter = "Video Presentation|.vpf";
            this.savepresentationdialog.RestoreDirectory = true;
            // 
            // path
            // 
            this.path.AutoSize = true;
            this.path.Location = new System.Drawing.Point(12, 37);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(0, 15);
            this.path.TabIndex = 3;
            // 
            // Maker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 473);
            this.Controls.Add(this.path);
            this.Controls.Add(this.add_video);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "Maker";
            this.Text = "VideoPresentationMaker";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem file;
        private System.Windows.Forms.ToolStripMenuItem help;
        private System.Windows.Forms.ToolStripMenuItem new_file;
        private System.Windows.Forms.ToolStripMenuItem open;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem save;
        private System.Windows.Forms.ToolStripMenuItem save_as;
        private System.Windows.Forms.ToolStripMenuItem presentation;
        private System.Windows.Forms.ToolStripMenuItem presentate;
        private System.Windows.Forms.ToolStripMenuItem about;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button add_video;
        private System.Windows.Forms.OpenFileDialog addvideo;
        private System.Windows.Forms.OpenFileDialog openpresentation;
        private System.Windows.Forms.ToolStripMenuItem close;
        private System.Windows.Forms.SaveFileDialog savepresentation;
        private System.Windows.Forms.SaveFileDialog savepresentationdialog;
        private System.Windows.Forms.Label path;
    }
}



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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Maker));
            this.videoentries = new System.Windows.Forms.FlowLayoutPanel();
            this.add_video = new System.Windows.Forms.Button();
            this.addvideo = new System.Windows.Forms.OpenFileDialog();
            this.openpresentation = new System.Windows.Forms.OpenFileDialog();
            this.savepresentationdialog = new System.Windows.Forms.SaveFileDialog();
            this.path = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // videoentries
            // 
            this.videoentries.AutoScroll = true;
            this.videoentries.BackColor = System.Drawing.SystemColors.ControlLight;
            this.videoentries.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.videoentries.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.videoentries.Location = new System.Drawing.Point(12, 55);
            this.videoentries.Name = "videoentries";
            this.videoentries.Size = new System.Drawing.Size(760, 371);
            this.videoentries.TabIndex = 1;
            this.videoentries.WrapContents = false;
            // 
            // add_video
            // 
            this.add_video.Enabled = false;
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
            this.addvideo.Filter = resources.GetString("addvideo.Filter");
            // 
            // openpresentation
            // 
            this.openpresentation.FileName = "open_presentation";
            this.openpresentation.Filter = "Video Presentation|*.vpf";
            this.openpresentation.RestoreDirectory = true;
            // 
            // savepresentationdialog
            // 
            this.savepresentationdialog.Filter = "Video Presentation|*.vpf";
            this.savepresentationdialog.RestoreDirectory = true;
            this.savepresentationdialog.FileOk += new System.ComponentModel.CancelEventHandler(this.savepresentationdialog_FileOk);
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
            this.Controls.Add(this.videoentries);
            this.Name = "Maker";
            this.Text = "VideoPresentationMaker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel videoentries;
        private System.Windows.Forms.Button add_video;
        private System.Windows.Forms.OpenFileDialog addvideo;
        private System.Windows.Forms.OpenFileDialog openpresentation;
        private System.Windows.Forms.SaveFileDialog savepresentationdialog;
        private System.Windows.Forms.Label path;
    }
}


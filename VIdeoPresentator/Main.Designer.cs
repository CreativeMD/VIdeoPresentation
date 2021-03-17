
namespace VIdeoPresentator
{
    partial class Main
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
            this.vlcView = new LibVLCSharp.WinForms.VideoView();
            this.open = new System.Windows.Forms.Button();
            this.openpresentation = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.vlcView)).BeginInit();
            this.SuspendLayout();
            // 
            // vlcView
            // 
            this.vlcView.BackColor = System.Drawing.Color.Black;
            this.vlcView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vlcView.Location = new System.Drawing.Point(0, 0);
            this.vlcView.MediaPlayer = null;
            this.vlcView.Name = "vlcView";
            this.vlcView.Size = new System.Drawing.Size(841, 531);
            this.vlcView.TabIndex = 0;
            this.vlcView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Main_KeyPress);
            this.vlcView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.vlcView_MouseDoubleClick);
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(12, 12);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(152, 32);
            this.open.TabIndex = 1;
            this.open.Text = "Open Presentation";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            this.open.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Main_KeyPress);
            // 
            // openpresentation
            // 
            this.openpresentation.Filter = "Video Presentation|*.vpf";
            this.openpresentation.RestoreDirectory = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 531);
            this.Controls.Add(this.open);
            this.Controls.Add(this.vlcView);
            this.Name = "Main";
            this.Text = "Presentation";
            this.Shown += new System.EventHandler(this.Main_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.vlcView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LibVLCSharp.WinForms.VideoView vlcView;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.OpenFileDialog openpresentation;
    }
}


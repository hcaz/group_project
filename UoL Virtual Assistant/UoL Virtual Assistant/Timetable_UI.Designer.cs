namespace UoL_Virtual_Assistant
{
    partial class Timetable_UI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Timetable_Web = new System.Windows.Forms.WebBrowser();
            this.Border = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Border)).BeginInit();
            this.SuspendLayout();
            // 
            // Timetable_Web
            // 
            this.Timetable_Web.AllowWebBrowserDrop = false;
            this.Timetable_Web.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Timetable_Web.IsWebBrowserContextMenuEnabled = false;
            this.Timetable_Web.Location = new System.Drawing.Point(0, 0);
            this.Timetable_Web.MinimumSize = new System.Drawing.Size(20, 20);
            this.Timetable_Web.Name = "Timetable_Web";
            this.Timetable_Web.ScrollBarsEnabled = false;
            this.Timetable_Web.Size = new System.Drawing.Size(964, 716);
            this.Timetable_Web.TabIndex = 0;
            // 
            // Border
            // 
            this.Border.BackColor = System.Drawing.Color.White;
            this.Border.Location = new System.Drawing.Point(0, 0);
            this.Border.Name = "Border";
            this.Border.Size = new System.Drawing.Size(964, 11);
            this.Border.TabIndex = 1;
            this.Border.TabStop = false;
            // 
            // Timetable_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 716);
            this.Controls.Add(this.Border);
            this.Controls.Add(this.Timetable_Web);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(980, 755);
            this.MinimumSize = new System.Drawing.Size(980, 755);
            this.Name = "Timetable_UI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Timetable";
            ((System.ComponentModel.ISupportInitialize)(this.Border)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser Timetable_Web;
        private System.Windows.Forms.PictureBox Border;
    }
}
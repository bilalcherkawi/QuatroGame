namespace Take_3
{
    partial class How_play
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(How_play));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.go = new System.Windows.Forms.Button();
            this.b1 = new System.Windows.Forms.Button();
            this.back2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(87, 147);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(385, 246);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SaddleBrown;
            this.panel1.Controls.Add(this.back2);
            this.panel1.Controls.Add(this.go);
            this.panel1.Controls.Add(this.b1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 87);
            this.panel1.TabIndex = 1;
            // 
            // go
            // 
            this.go.BackColor = System.Drawing.Color.Brown;
            this.go.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.go.Location = new System.Drawing.Point(408, 17);
            this.go.Name = "go";
            this.go.Size = new System.Drawing.Size(60, 49);
            this.go.TabIndex = 1;
            this.go.Text = "GO";
            this.go.UseVisualStyleBackColor = false;
            this.go.Click += new System.EventHandler(this.go_Click);
            // 
            // b1
            // 
            this.b1.BackColor = System.Drawing.Color.Chocolate;
            this.b1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b1.Location = new System.Drawing.Point(120, 17);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(282, 49);
            this.b1.TabIndex = 0;
            this.b1.Text = "https://youtu.be/HNsdZswQveE";
            this.b1.UseVisualStyleBackColor = false;
            // 
            // back2
            // 
            this.back2.BackColor = System.Drawing.Color.OrangeRed;
            this.back2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back2.Location = new System.Drawing.Point(11, 17);
            this.back2.Name = "back2";
            this.back2.Size = new System.Drawing.Size(81, 49);
            this.back2.TabIndex = 2;
            this.back2.Text = "Back";
            this.back2.UseVisualStyleBackColor = false;
            this.back2.Click += new System.EventHandler(this.back2_Click);
            // 
            // How_play
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(741, 519);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.webBrowser1);
            this.Name = "How_play";
            this.Text = "How_play";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button go;
        private System.Windows.Forms.Button b1;
        private System.Windows.Forms.Button back2;
    }
}
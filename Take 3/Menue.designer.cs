namespace Take_3
{
    partial class Menue
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
            this.ModePanel = new System.Windows.Forms.Panel();
            this.back3 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.PvsCom = new System.Windows.Forms.Button();
            this.PvsP = new System.Windows.Forms.Button();
            this.GameSettings = new System.Windows.Forms.Panel();
            this.ModePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ModePanel
            // 
            this.ModePanel.BackColor = System.Drawing.Color.Maroon;
            this.ModePanel.Controls.Add(this.back3);
            this.ModePanel.Controls.Add(this.button3);
            this.ModePanel.Controls.Add(this.PvsCom);
            this.ModePanel.Controls.Add(this.PvsP);
            this.ModePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ModePanel.Location = new System.Drawing.Point(0, 0);
            this.ModePanel.Margin = new System.Windows.Forms.Padding(2);
            this.ModePanel.Name = "ModePanel";
            this.ModePanel.Size = new System.Drawing.Size(192, 439);
            this.ModePanel.TabIndex = 0;
            // 
            // back3
            // 
            this.back3.BackColor = System.Drawing.Color.OrangeRed;
            this.back3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back3.Location = new System.Drawing.Point(11, 315);
            this.back3.Margin = new System.Windows.Forms.Padding(2);
            this.back3.Name = "back3";
            this.back3.Size = new System.Drawing.Size(158, 45);
            this.back3.TabIndex = 3;
            this.back3.Text = "Back";
            this.back3.UseVisualStyleBackColor = false;
            this.back3.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Sienna;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(11, 210);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(158, 45);
            this.button3.TabIndex = 2;
            this.button3.Text = "Score panel";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // PvsCom
            // 
            this.PvsCom.BackColor = System.Drawing.Color.Chocolate;
            this.PvsCom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PvsCom.Location = new System.Drawing.Point(11, 128);
            this.PvsCom.Margin = new System.Windows.Forms.Padding(2);
            this.PvsCom.Name = "PvsCom";
            this.PvsCom.Size = new System.Drawing.Size(158, 45);
            this.PvsCom.TabIndex = 1;
            this.PvsCom.Text = "Player vs Computer";
            this.PvsCom.UseVisualStyleBackColor = false;
            this.PvsCom.Click += new System.EventHandler(this.PvsCom_Click);
            // 
            // PvsP
            // 
            this.PvsP.BackColor = System.Drawing.Color.Chocolate;
            this.PvsP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PvsP.Location = new System.Drawing.Point(11, 60);
            this.PvsP.Margin = new System.Windows.Forms.Padding(2);
            this.PvsP.Name = "PvsP";
            this.PvsP.Size = new System.Drawing.Size(158, 45);
            this.PvsP.TabIndex = 0;
            this.PvsP.Text = "Player vs Player";
            this.PvsP.UseVisualStyleBackColor = false;
            this.PvsP.Click += new System.EventHandler(this.PvsP_Click);
            // 
            // GameSettings
            // 
            this.GameSettings.BackgroundImage = global::Take_3.Properties.Resources.____;
            this.GameSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GameSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameSettings.Location = new System.Drawing.Point(192, 0);
            this.GameSettings.Margin = new System.Windows.Forms.Padding(2);
            this.GameSettings.Name = "GameSettings";
            this.GameSettings.Size = new System.Drawing.Size(492, 439);
            this.GameSettings.TabIndex = 1;
            // 
            // Menue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 439);
            this.ControlBox = false;
            this.Controls.Add(this.GameSettings);
            this.Controls.Add(this.ModePanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Menue";
            this.Text = "Menue";
            this.ModePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ModePanel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button PvsCom;
        private System.Windows.Forms.Button PvsP;
        private System.Windows.Forms.Panel GameSettings;
        private System.Windows.Forms.Button back3;
       

    }
}
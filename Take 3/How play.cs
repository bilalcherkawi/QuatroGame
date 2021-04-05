using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Take_3
{
    public partial class How_play : Form
    {
        public How_play()
        {
            InitializeComponent();
        }

        private void go_Click(object sender, EventArgs e)
        {
            if (b1.Text.Length > 0)
                webBrowser1.Url = new Uri(b1.Text);
        }

        private void back2_Click(object sender, EventArgs e)
        {
            
            Class1.MaineMenue.Show();
            Class1.StartMenue.axWindowsMediaPlayer1.URL = "menusound.wav";
            
            this.Hide();
            

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}

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
    public partial class option_page : Form
    {
        public option_page()
        {
            InitializeComponent();
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Class1.StartMenue.axWindowsMediaPlayer1.URL = "menusound.wav";
            sound.Image = Properties.Resources.sound_on1;
            Class1.StartMenue.axWindowsMediaPlayer1.settings.volume = trackBar1.Value;
            if (trackBar1.Value == 0)
            {
                sound.Image = Properties.Resources.sound_off;
            }

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

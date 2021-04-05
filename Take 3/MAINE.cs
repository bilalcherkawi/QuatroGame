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
    public partial class MAINE : Form
    {
        static bool SquareRule;
        public MAINE()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SquareRule = false;
            Class1.GameMenue = new Menue();
            Class1.GameMenue.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SquareRule = true;
            Class1.GameMenue = new Menue();
            Class1.GameMenue.Show();
            this.Hide();
        }

        public static bool GetRules
        {
            get { return SquareRule; }
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            Class1.StartMenue.axWindowsMediaPlayer1.URL = null;
            Class1.how = new How_play();
            Class1.how.Show();
            this.Hide();
           
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Class1.StartMenue.Show();
            this.Hide();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

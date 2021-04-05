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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.URL = ("menusound.wav");
           
            axWindowsMediaPlayer1.Hide();
           
            
        }
      
        private void start_MouseHover(object sender, EventArgs e)
        {
            start.Image = Properties.Resources.start_hover1;
            System.Media.SoundPlayer sound = new System.Media.SoundPlayer("background sound.wav");
            sound.Play();
            
        }

        private void option_MouseHover(object sender, EventArgs e)
        {
          option.Image= Properties.Resources.option_hover1;
            System.Media.SoundPlayer sound = new System.Media.SoundPlayer("background sound.wav");
            sound.Play();
        }

        private void exit_MouseHover(object sender, EventArgs e)
        {
            exit.Image = Properties.Resources.exit_hover1;
            System.Media.SoundPlayer sound = new System.Media.SoundPlayer("background sound.wav");
            sound.Play();
        }

        private void start_MouseLeave(object sender, EventArgs e)
        {
            start.Image = Properties.Resources.start_normal1;

        }

        private void option_MouseLeave(object sender, EventArgs e)
        {
            option.Image = Properties.Resources.option_normal1;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exit_MouseLeave(object sender, EventArgs e)
        {
            exit.Image = Properties.Resources.exit_normal1;
        }

        private void start_Click(object sender, EventArgs e)
        {
           
            MAINE f5 = new MAINE();
            f5.Show();
            Visible = false;





        }

        private void option_Click(object sender, EventArgs e)
        {
           option_page option = new option_page();
           option.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
       
    }
}

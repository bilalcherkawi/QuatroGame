using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace Take_3
{
    public partial class Menue : Form
    {
        static bool Rules;
        static bool TimeChallenge = false;
        static bool pVp;
        static bool p1Start;
        static string Difficulty;

        static DataSet ds;

        static string player1, player2;

        public Menue()
        {
            InitializeComponent();
            Rules = MAINE.GetRules;
            ds = new DataSet();

            if (!File.Exists(Application.StartupPath + "\\My Results.xml"))
            {
                ds = new DataSet();
                ds.DataSetName = "Games";

                DataTable dt = new DataTable();
                dt.TableName = "PVP";
                ds.Tables.Add(dt);

                DataColumn dc = new DataColumn("Game Name", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("Winner", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("Time (in sec)", typeof(int));
                dt.Columns.Add(dc);


                dt = new DataTable();
                dt.TableName = "PVCOM";
                ds.Tables.Add(dt);

                dc = new DataColumn("Game Name", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("Result", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("Time (in sec)", typeof(int));
                dt.Columns.Add(dc);

                dt = new DataTable();
                dt.TableName = "SqPVP";
                ds.Tables.Add(dt);

                dc = new DataColumn("Game Name", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("Winner", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("Time (in sec)", typeof(int));
                dt.Columns.Add(dc);


                dt = new DataTable();
                dt.TableName = "SqPVCOM";
                ds.Tables.Add(dt);

                dc = new DataColumn("Game Name", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("Result", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("Time (in sec)", typeof(int));
                dt.Columns.Add(dc);

            }
            else
            {
                ds.ReadXml(Application.StartupPath + "\\My Results.xml");
            }
        }

        private void PvsP_Click(object sender, EventArgs e)
        {
            ClearPanel();

            pVp = true;
            player1 = "";
            player2 = "";
            TextBox p1 = new TextBox(), p2 = new TextBox();
            GameSettings.Controls.Add(p2);
            GameSettings.Controls.Add(p1);
            p1.Top = GameSettings.Height / 4;
            p1.Left = GameSettings.Width / 4;
            p1.Width = 100;
            p1.Height = 30;
            p2.Top = GameSettings.Height / 4;
            p2.Left = p1.Left + p1.Width + 30;
            p2.Width = 100;
            p2.Height = 30;
            p1.TextChanged += P1_TextChanged;
            p2.TextChanged += P2_TextChanged;
            //
            //
            Label l1 = new Label();
            Label l2 = new Label();

            GameSettings.Controls.Add(l2);
            GameSettings.Controls.Add(l1);
            l1.Text = "Player 1 Name";
            l2.Text = "Player 2 Name";
            l1.Top = p1.Top + p1.Height - 45;
            l2.Top = p2.Top + p2.Height - 45;
            l1.Left = p1.Left;
            l2.Left = p2.Left;
            //
            //
            RadioButton r1 = new RadioButton();
            RadioButton r2 = new RadioButton();
            GameSettings.Controls.Add(r1);
            GameSettings.Controls.Add(r2);
            r1.Text = "Player 1 Give the first piece";
            r2.Text = "Player 2 Give the first piece";
            r1.Left = p1.Left + p1.Width;
            r2.Left = r1.Left;
            r1.Height = 20;
            r1.Width = 160;
            r2.Width = 160;
            r1.Top = p1.Top + p1.Height + l1.Height + 10;
            r2.Top = r1.Top + r1.Height + 20;

            r1.Click += R1_Click;
            r2.Click += R2_Click;
            //
            //
            Button b = new Button();
            GameSettings.Controls.Add(b);
            b.Top = 3 * (GameSettings.Height / 4);
            b.Left = GameSettings.Width / 2;
            b.Text = "Start Game";
            b.Click += Start_Game;

        }


        private void PvsCom_Click(object sender, EventArgs e)
        {
            ClearPanel();


            pVp = false;
            TextBox p1 = new TextBox();
            GameSettings.Controls.Add(p1);
            p1.Top = 2 * (GameSettings.Height / 7);
            p1.Left = GameSettings.Width / 4;
            p1.Width = 100;
            p1.Height = 30;
            p1.TextChanged += P1_TextChanged;

            Label l1 = new Label();
            GameSettings.Controls.Add(l1);
            l1.Text = "Player name";
            l1.Top = p1.Top + p1.Height -45;
            l1.Left = p1.Left;

            RadioButton r1 = new RadioButton();
            RadioButton r2 = new RadioButton();
            GameSettings.Controls.Add(r1);
            GameSettings.Controls.Add(r2);
            r1.Text = "you Give the first piece";
            r2.Text = "Computer Give the first piece";
            r1.Left = p1.Left;
            r2.Left = r1.Left;
            r1.Height = 20;
            r1.Width = 125;
            r2.Width = 175;
            r1.Top = p1.Top + p1.Height + l1.Height + 10;
            r2.Top = r1.Top + r1.Height + 20;
            r1.Click += R1_Click;
            r2.Click += R2_Click;
            //
            //
            Button H = new Button();
            GameSettings.Controls.Add(H);
            H.Top = 3 * (GameSettings.Height / 4);
            H.Left = 20;
            H.Text = "Hard";
            H.Click += Start_Game;

            Button I = new Button();
            GameSettings.Controls.Add(I);
            I.Top = H.Top - 10 - H.Height;
            I.Left = 20;
            I.Text = "Intermidiate";
            I.Click += Start_Game;

            Button E = new Button();
            GameSettings.Controls.Add(E);
            E.Top = I.Top - 10 - I.Height;
            E.Left = 20;
            E.Text = "Easy";
            E.Click += Start_Game;

            Button T = new Button();
            GameSettings.Controls.Add(T);
            T.Top = 3 * (GameSettings.Height / 4);
            T.Left = GameSettings.Width / 2;
            T.Text = "Time Challenge";
            T.Click += Start_Timed_Game;


            player1 = p1.Text;
            player2 = "Computer";
        }

        private void Start_Timed_Game(object sender, EventArgs e)
        {
            TimeChallenge = true;
            Difficulty = "HARD";
            this.Hide();
            Class1.StartMenue.axWindowsMediaPlayer1.URL = null;
            Form1 frm = new Form1();
            frm.use1.Text = player1;
            frm.use2.Visible = false;
            frm.Show();
        }

        //
        //

        private void button3_Click(object sender, EventArgs e)
        {
            ClearPanel();

            DataGridView ResultPanel1 = new DataGridView();
            GameSettings.Controls.Add(ResultPanel1);
            ResultPanel1.Top = 30;
            ResultPanel1.Left = 30;
            ResultPanel1.Height = 150;
            ResultPanel1.Width = 400;
            DisableManualEditting(ResultPanel1);


            DataGridView ResultPanel2 = new DataGridView();
            GameSettings.Controls.Add(ResultPanel2);
            ResultPanel2.Top = ResultPanel1.Top + ResultPanel1.Height + 50;
            ResultPanel2.Left = ResultPanel1.Left;
            ResultPanel2.Height = ResultPanel1.Height;
            ResultPanel2.Width = ResultPanel1.Width;
            DisableManualEditting(ResultPanel2);

            ResultPanel1.DataSource = ds;
            ResultPanel2.DataSource = ds;
            if (!Rules)
            {
                try
                {
                    ResultPanel1.DataMember = "PVP";
                }
                catch (ArgumentException)
                {
                    DataTable dt = new DataTable();
                    dt.TableName = "PVP";
                    ds.Tables.Add(dt);

                    DataColumn dc = new DataColumn("Game Name", typeof(string));
                    dt.Columns.Add(dc);
                    dc = new DataColumn("Winner", typeof(string));
                    dt.Columns.Add(dc);
                    dc = new DataColumn("Time (in sec)", typeof(int));
                    dt.Columns.Add(dc);

                    ResultPanel1.DataMember = "PVP";
                }
                try
                {
                    ResultPanel2.DataMember = "PVCOM";
                }
                catch (ArgumentException)
                {
                    DataTable dt = new DataTable();
                    dt.TableName = "PVCOM";
                    ds.Tables.Add(dt);

                    DataColumn dc = new DataColumn("Game Name", typeof(string));
                    dt.Columns.Add(dc);
                    dc = new DataColumn("Result", typeof(string));
                    dt.Columns.Add(dc);
                    dc = new DataColumn("Time (in sec)", typeof(int));
                    dt.Columns.Add(dc);
                    ResultPanel2.DataMember = "PVCOM";
                }
            }
            else
            {
                try
                {
                    ResultPanel1.DataMember = "SqPVP";
                }
                catch (ArgumentException)
                {
                    DataTable dt = new DataTable();
                    dt.TableName = "SqPVP";
                    ds.Tables.Add(dt);

                    DataColumn dc = new DataColumn("Game Name", typeof(string));
                    dt.Columns.Add(dc);
                    dc = new DataColumn("Winner", typeof(string));
                    dt.Columns.Add(dc);
                    dc = new DataColumn("Time (in sec)", typeof(int));
                    dt.Columns.Add(dc);
                    ResultPanel1.DataMember = "SqPVP";
                }
                try
                {
                    ResultPanel2.DataMember = "SqPVCOM";
                }
                catch (ArgumentException)
                {
                    DataTable dt = new DataTable();
                    dt.TableName = "SqPVCOM";
                    ds.Tables.Add(dt);

                    DataColumn dc = new DataColumn("Game Name", typeof(string));
                    dt.Columns.Add(dc);
                    dc = new DataColumn("Result", typeof(string));
                    dt.Columns.Add(dc);
                    dc = new DataColumn("Time (in sec)", typeof(int));
                    dt.Columns.Add(dc);
                    ResultPanel2.DataMember = "SqPVCOM";
                }
            }

        }
        //
        //
        private void DisableManualEditting(DataGridView ResultPanel1)
        {
            ResultPanel1.AllowUserToAddRows = false;
            ResultPanel1.AllowUserToDeleteRows = false;
            ResultPanel1.AllowDrop = false;
            ResultPanel1.AllowUserToOrderColumns = false;
            ResultPanel1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        //
        //
       
        private void Start_Game(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Difficulty = b.Text.ToUpper();
            TimeChallenge = false;
            Class1.StartMenue.axWindowsMediaPlayer1.URL = null;
           

           
            Form1 frm = new Form1();
           
            frm.use1.Text = player1;
            frm.use2.Text = player2;

           
            frm.Show();

            this.Hide();
        }
       
        //
        //
        //
        //
        //
        private void ClearPanel()
        {

            while (GameSettings.Controls.Count != 0)
                GameSettings.Controls[0].Dispose();
        }

        public static bool IsThereATimeLimit
        {
            get { return TimeChallenge; }
        }

        public static bool GameMode
        {
            get { return pVp; }
        }

        public static bool WhoStarts
        {
            get { return p1Start; }
        }



        public static string Player1Name
        {
            get { return player1; }
        }



        public static string Player2Name
        {
            get { return player2; }
        }

        public static string GetDiff
        {
            get { return Difficulty; }
        }

        public static bool GetRules
        {
            get { return Rules; }
        }
        public static void Save()
        {
            ds.WriteXml(Application.StartupPath + "\\My Results.xml");
        }

        public static void ADD_PVP_ROW(string matche, string winner, int time)
        {
            DataTable dt;
            DataRow dr;
            try
            {
                if (!Rules)
                    dt = ds.Tables["PVP"];
                else
                    dt = ds.Tables["SqPVP"];
                dr = dt.NewRow();
            }
            catch (NullReferenceException)
            {
                dt = new DataTable();
                if (!Rules)
                {
                    dt.TableName = "PVP";
                    ds.Tables.Add(dt);
                    DataColumn dc;
                    dc = new DataColumn("Game Name", typeof(string));
                    dt.Columns.Add(dc);
                    dc = new DataColumn("Winner", typeof(string));
                    dt.Columns.Add(dc);
                    dc = new DataColumn("Time (in sec)", typeof(int));
                    dt.Columns.Add(dc);
                }
                else
                {
                    dt.TableName = "SqPVP";
                    ds.Tables.Add(dt);
                    DataColumn dc;
                    dc = new DataColumn("Game Name", typeof(string));
                    dt.Columns.Add(dc);
                    dc = new DataColumn("Winner", typeof(string));
                    dt.Columns.Add(dc);
                    dc = new DataColumn("Time (in sec)", typeof(int));
                    dt.Columns.Add(dc);
                }
                dr = dt.NewRow();
            }
            dr["Game Name"] = matche;
            dr["Winner"] = winner;
            dr["Time (in sec)"] = time;
            dt.Rows.Add(dr);
        }


        public static void ADD_PVCOM_ROW(string matche, string state, int time)
        {
            DataTable dt;
            DataRow dr;
            try
            {
                if (!Rules)
                    dt = ds.Tables["PVCOM"];
                else
                    dt = ds.Tables["SqPVCOM"];

                dr = dt.NewRow();
            }
            catch (NullReferenceException)
            {
                dt = new DataTable();
                if (!Rules)
                {
                    dt.TableName = "PVCOM";
                    ds.Tables.Add(dt);
                    DataColumn dc;
                    dc = new DataColumn("Game Name", typeof(string));
                    dt.Columns.Add(dc);
                    dc = new DataColumn("Result", typeof(string));
                    dt.Columns.Add(dc);
                    dc = new DataColumn("Time (in sec)", typeof(int));
                    dt.Columns.Add(dc);
                }
                else
                {
                    dt.TableName = "SqPVCOM";
                    ds.Tables.Add(dt);
                    DataColumn dc;
                    dc = new DataColumn("Game Name", typeof(string));
                    dt.Columns.Add(dc);
                    dc = new DataColumn("Result", typeof(string));
                    dt.Columns.Add(dc);
                    dc = new DataColumn("Time (in sec)", typeof(int));
                    dt.Columns.Add(dc);
                }

                dr = dt.NewRow();
            }

            dr["Game Name"] = matche;
            dr["Result"] = state;
            dr["Time (in sec)"] = time;
            dt.Rows.Add(dr);
        }
        //
        //
        //
        private static void CreateDataTab(ref DataTable dt, string name, string result)
        {
            dt.TableName = name;
            ds.Tables.Add(dt);
            DataColumn dc;
            dc = new DataColumn("Game Name", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn(result, typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("Time (in sec)", typeof(int));
            dt.Columns.Add(dc);
        }

        private void R2_Click(object sender, EventArgs e)
        {
            p1Start = false;
        }

        private void R1_Click(object sender, EventArgs e)
        {
            p1Start = true;
        }

        private void P1_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            player1 = t.Text;

        }


        private void P2_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            player2 = t.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.MaineMenue.Show();
            this.Close();
        }



         
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void go_Click(object sender, EventArgs e)
        {

        }
    }
}


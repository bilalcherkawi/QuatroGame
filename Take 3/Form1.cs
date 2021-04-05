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

namespace Take_3
{
    public partial class Form1 : Form
    {
        bool DidGameEnd;
        bool TimeChallenge = Menue.IsThereATimeLimit;
        bool GameMode = Menue.GameMode;
       // int duration, timeleft;

        List<Piece> AvailablePieces = new List<Piece>();
        Stack<bool> changeing_turns = new Stack<bool>();
        Stack<Piece> Pieces_Played = new Stack<Piece>();
        Stack<Point> Points_Occup = new Stack<Point>();
        //
        //----------------
        //
        string Difficulty = Menue.GetDiff;
        string player1 = Menue.Player1Name;
        string player2 = Menue.Player2Name;
        int MouseClickNb;
        bool turn;
        bool WhoStarted = Menue.WhoStarts;
        //
        // Placing the used pieces.
        //
        Piece[,] cells = new Piece[4, 4];
        //
        //time of the start of our game.
        //
        DateTime BeginOfGame;
        //
        //Initializing the form (pieces & locations).
        //
        public Form1()
        {
            InitializeComponent();
            //
            //seting location of played pieces
            //
            b00.Tag = new Point(0, 0);
            b01.Tag = new Point(0, 1);
            b02.Tag = new Point(0, 2);
            b03.Tag = new Point(0, 3);
            
            b10.Tag = new Point(1, 0);
            b11.Tag = new Point(1, 1);
            b12.Tag = new Point(1, 2);
            b13.Tag = new Point(1, 3);
            
            b20.Tag = new Point(2, 0);
            b21.Tag = new Point(2, 1);
            b22.Tag = new Point(2, 2);
            b23.Tag = new Point(2, 3);
            
            b30.Tag = new Point(3, 0);
            b31.Tag = new Point(3, 1);
            b32.Tag = new Point(3, 2);
            b33.Tag = new Point(3, 3);

            restart();


        }
        //
        //Chosing a piece for the opponent.
        //
        private void Choose_Peice(object sender, EventArgs e)
        {
            System.Media.SoundPlayer sound = new System.Media.SoundPlayer("background sound.wav");
            sound.Play();


            PictureBox p = (PictureBox)sender;
            c.Image = p.Image;
            c.Tag = p.Tag;
            p.Image = null;
            p.Enabled = false;
            Pieces_Played.Push((Piece)p.Tag);
            AvailablePieces.Remove((Piece)p.Tag);
            panel1.Enabled = false;
            panel2.Enabled = true;
            changeing_turns.Push(turn);
            //
            // Changeing the turn
            //
            turn = !turn;
            if (!GameMode)
            {
                if(Difficulty=="HARD")
                    PlayHard(cells, c, panel1, panel2, Points_Occup, Pieces_Played, AvailablePieces);
                if (Difficulty == "EASY")
                    PlayEazy(cells, c, panel1, panel2, Points_Occup, Pieces_Played, AvailablePieces);
                if (Difficulty == "INTERMIDIATE")
                    PlayIntermidiate(cells, c, panel1, panel2, Points_Occup, Pieces_Played, AvailablePieces);
                GameEnd.CheckGame(cells, turn, player1, player2, panel1, ref DidGameEnd, ref winner);
                if (DidGameEnd)
                {
                    DateTime EndOfGame = DateTime.Now;
                    TimeSpan TimeToFinish = EndOfGame - BeginOfGame;
                    MessageBox.Show(TimeToFinish.Seconds.ToString());
                    FixeWinner();
                    if (!TimeChallenge)
                    {
                        Menue.ADD_PVCOM_ROW(player1 + " vs " + player2, winner, TimeToFinish.Seconds);
                        Menue.Save();
                    }
                }
                changeing_turns.Push(turn);
                turn = !turn;
            }
            MouseClickNb++;
        }
        //
        //Playing the Chosen piece.
        //
        
        string winner;
        private void b00_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer sound = new System.Media.SoundPlayer("background sound.wav");
            sound.Play();


            PictureBox b = (PictureBox)sender;
            Point p;
            p = (Point)b.Tag;
            Points_Occup.Push(p);
            b.Image = c.Image;
            c.Image = null;
            cells[p.X, p.Y] = (Piece)c.Tag;
            b.Enabled = false;
            MouseClickNb++;
            panel1.Enabled = true;
            panel2.Enabled = false;
            GameEnd.CheckGame(cells, turn, player1, player2, panel1, ref DidGameEnd, ref winner);
            if (DidGameEnd)
            {
                DateTime EndOfGame = DateTime.Now;
                TimeSpan TimeToFinish = EndOfGame - BeginOfGame;
                MessageBox.Show(TimeToFinish.Seconds.ToString());
                if (GameMode)
                {
                    Menue.ADD_PVP_ROW(player1 + " vs " + player2, winner, TimeToFinish.Seconds);
                    Menue.Save();
                }
                if (!GameMode)
                {
                    FixeWinner();
                    if (!TimeChallenge)
                    {
                        Menue.ADD_PVCOM_ROW(player1 + " vs " + player2, winner, TimeToFinish.Seconds);
                        Menue.Save();
                    }
                }
            }
        }
        //

        //Undoing the last move.

        //

        private void button1_Click(object sender, EventArgs e)
        {

            if (GameMode)

                UndoLastMove();

            else

                UndoLastTurn();

        }

        private void UndoLastMove()
        {

            if (MouseClickNb > 0)
            { //

                //undoing the piece choice.

                //

                if (MouseClickNb % 2 != 0)
                {

                    if (Pieces_Played.Count != 0 && changeing_turns.Count != 0)
                    {

                        foreach (PictureBox cont in panel1.Controls)

                            if (Pieces_Played.Count != 0 && cont.Tag == Pieces_Played.Peek())
                            {

                                cont.Image = c.Image;

                                cont.Enabled = true;

                            }

                        Pieces_Played.Pop();

                        turn = changeing_turns.Pop();

                        c.Image = null;

                        panel1.Enabled = true;

                        panel2.Enabled = false;

                    }

                }

                //

                // undoing the placing move.

                //

                else
                {

                    if (Points_Occup.Count != 0 && changeing_turns.Count != 0)
                    {

                        foreach (PictureBox cont in panel2.Controls)

                            if (Points_Occup.Count != 0 && (Point)cont.Tag == Points_Occup.Peek())
                            {

                                c.Image = cont.Image;

                                c.Tag = cells[Points_Occup.Peek().X, Points_Occup.Peek().Y];

                                cont.Image = null;

                                cont.Enabled = true;

                                cells[Points_Occup.Peek().X, Points_Occup.Peek().Y] = null;

                            }

                        Points_Occup.Pop();

                        panel1.Enabled = false;

                        panel2.Enabled = true;

                    }

                }

                MouseClickNb--;

            }

        }

        private void UndoLastTurn()
        {

            if (MouseClickNb > 0)
            {

                if (WhoStarted)
                {

                    if (MouseClickNb % 2 != 0)
                    {

                        if (Pieces_Played.Count != 0 && changeing_turns.Count != 0)
                        {

                            foreach (PictureBox cont in panel1.Controls)

                                if (Pieces_Played.Count != 0 && cont.Tag == Pieces_Played.Peek())
                                {

                                    cont.Image = c.Image;

                                    cont.Enabled = true;

                                }

                            Pieces_Played.Pop();

                            turn = changeing_turns.Pop();

                            c.Image = null;

                            c.Tag = null;

                            panel1.Enabled = true;

                            panel2.Enabled = false;

                        }

                        if (Points_Occup.Count != 0 && changeing_turns.Count != 0)
                        {

                            foreach (PictureBox conte in panel2.Controls)

                                if (Points_Occup.Count != 0 && (Point)conte.Tag == Points_Occup.Peek())
                                {

                                    c.Image = conte.Image;

                                    c.Tag = cells[Points_Occup.Peek().X, Points_Occup.Peek().Y];

                                    conte.Image = null;

                                    conte.Enabled = true;

                                    cells[Points_Occup.Peek().X, Points_Occup.Peek().Y] = null;

                                }

                            Points_Occup.Pop();

                            panel1.Enabled = false;

                            panel2.Enabled = true;

                        }

                        if (Pieces_Played.Count != 0 && changeing_turns.Count != 0)
                        {

                            foreach (PictureBox cont in panel1.Controls)

                                if (Pieces_Played.Count != 0 && cont.Tag == Pieces_Played.Peek())
                                {

                                    cont.Image = c.Image;

                                    cont.Enabled = true;

                                }

                            Pieces_Played.Pop();

                            turn = changeing_turns.Pop();

                            c.Image = null;

                            panel1.Enabled = true;

                            panel2.Enabled = false;

                        }

                    }

                    if (MouseClickNb % 2 == 0)
                    {

                        if (Points_Occup.Count != 0 && changeing_turns.Count != 0)
                        {

                            foreach (PictureBox cont in panel2.Controls)

                                if (Points_Occup.Count != 0 && (Point)cont.Tag == Points_Occup.Peek())
                                {

                                    c.Image = cont.Image;

                                    c.Tag = cells[Points_Occup.Peek().X, Points_Occup.Peek().Y];

                                    cont.Image = null;

                                    cont.Enabled = true;

                                    cells[Points_Occup.Peek().X, Points_Occup.Peek().Y] = null;

                                }

                            Points_Occup.Pop();

                            panel1.Enabled = false;

                            panel2.Enabled = true;

                        }

                    }

                }

                else
                {

                    if (MouseClickNb % 2 == 0)
                    {

                        if (Pieces_Played.Count != 0 && changeing_turns.Count != 0)
                        {

                            foreach (PictureBox cont in panel1.Controls)

                                if (Pieces_Played.Count != 0 && cont.Tag == Pieces_Played.Peek())
                                {

                                    cont.Image = c.Image;

                                    cont.Enabled = true;

                                }

                            Pieces_Played.Pop();

                            turn = changeing_turns.Pop();

                            c.Image = null;

                            c.Tag = null;

                            panel1.Enabled = true;

                            panel2.Enabled = false;

                        }

                        if (Points_Occup.Count != 0 && changeing_turns.Count != 0)
                        {

                            foreach (PictureBox conte in panel2.Controls)

                                if (Points_Occup.Count != 0 && (Point)conte.Tag == Points_Occup.Peek())
                                {

                                    c.Image = conte.Image;

                                    c.Tag = cells[Points_Occup.Peek().X, Points_Occup.Peek().Y];

                                    conte.Image = null;

                                    conte.Enabled = true;

                                    cells[Points_Occup.Peek().X, Points_Occup.Peek().Y] = null;

                                }

                            Points_Occup.Pop();

                            panel1.Enabled = false;

                            panel2.Enabled = true;

                        }

                        if (Pieces_Played.Count != 0 && changeing_turns.Count != 0)
                        {

                            foreach (PictureBox cont in panel1.Controls)

                                if (Pieces_Played.Count != 0 && cont.Tag == Pieces_Played.Peek())
                                {

                                    cont.Image = c.Image;

                                    cont.Enabled = true;

                                }

                            Pieces_Played.Pop();

                            turn = changeing_turns.Pop();

                            c.Image = null;

                            panel1.Enabled = true;

                            panel2.Enabled = false;

                        }

                    }

                    if (MouseClickNb % 2 != 0)
                    {

                        if (Points_Occup.Count != 0 && changeing_turns.Count != 0)
                        {

                            foreach (PictureBox cont in panel2.Controls)

                                if (Points_Occup.Count != 0 && (Point)cont.Tag == Points_Occup.Peek())
                                {

                                    c.Image = cont.Image;

                                    c.Tag = cells[Points_Occup.Peek().X, Points_Occup.Peek().Y];

                                    cont.Image = null;

                                    cont.Enabled = true;

                                    cells[Points_Occup.Peek().X, Points_Occup.Peek().Y] = null;

                                }

                            Points_Occup.Pop();

                            panel1.Enabled = false;

                            panel2.Enabled = true;

                        }

                    }

                }

                MouseClickNb--;

            }

        }
        //
        //Restarting game.
        //
        private void restart_button_Click(object sender, EventArgs e)
        {
            restart();
        }
        //
        // Exiting the form.
        //
        private void exiteButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Class1.GameMenue.Show();
            Class1.StartMenue.axWindowsMediaPlayer1.URL="menusound.wav";
        }

        public void restart()
        {
            Class1.StartMenue.axWindowsMediaPlayer1.URL = null;

            Pieces_Played.Clear();
            Points_Occup.Clear();
            changeing_turns.Clear();
            AvailablePieces.Clear();
             Piece p0000 = new Piece(0, 0, 0, 0);
             Piece p0001 = new Piece(0, 0, 0, 1);
             Piece p0100 = new Piece(0, 1, 0, 0);
             Piece p0101 = new Piece(0, 1, 0, 1);
             Piece p1000 = new Piece(1, 0, 0, 0);
             Piece p1001 = new Piece(1, 0, 0, 1);
             Piece p1100 = new Piece(1, 1, 0, 0);
             Piece p1101 = new Piece(1, 1, 0, 1);
             Piece p0010 = new Piece(0, 0, 1, 0);
             Piece p0011 = new Piece(0, 0, 1, 1);
             Piece p0110 = new Piece(0, 1, 1, 0);
             Piece p0111 = new Piece(0, 1, 1, 1);
             Piece p1010 = new Piece(1, 0, 1, 0);
             Piece p1011 = new Piece(1, 0, 1, 1);
             Piece p1110 = new Piece(1, 1, 1, 0);
             Piece p1111 = new Piece(1, 1, 1, 1);
            //
            //Saving the moves made.
            //
            AvailablePieces.Add(p0000);
            AvailablePieces.Add(p0001);
            AvailablePieces.Add(p0010);
            AvailablePieces.Add(p0011);
            AvailablePieces.Add(p0100);
            AvailablePieces.Add(p0101);
            AvailablePieces.Add(p0110);
            AvailablePieces.Add(p0111);
            AvailablePieces.Add(p1000);
            AvailablePieces.Add(p1001);
            AvailablePieces.Add(p1010);
            AvailablePieces.Add(p1011);
            AvailablePieces.Add(p1100);
            AvailablePieces.Add(p1101);
            AvailablePieces.Add(p1110);
            AvailablePieces.Add(p1111);

            a1.Tag = p0000;
            a1.Image = Properties.Resources._0000;
            a1.Enabled = true;
            //
            a2.Tag = p0001;
            a2.Image = Properties.Resources._0001;
            a2.Enabled = true;
            //
            a3.Tag = p0010;
            a3.Image = Properties.Resources._0010;
            a3.Enabled = true;
            //
            a4.Tag = p0011;
            a4.Image = Properties.Resources._0011;
            a4.Enabled = true;
            //
            a5.Tag = p0100;
            a5.Image = Properties.Resources._0100;
            a5.Enabled = true;
            //
            a6.Tag = p0101;
            a6.Image = Properties.Resources._0101;
            a6.Enabled = true;
            //
            a7.Tag = p0110;
            a7.Image = Properties.Resources._0110;
            a7.Enabled = true;
            //
            a8.Tag = p0111;
            a8.Image = Properties.Resources._0111;
            a8.Enabled = true;
            //
            a9.Tag = p1000;
            a9.Image = Properties.Resources._1000;
            a9.Enabled = true;
            //
            a10.Tag = p1001;
            a10.Image = Properties.Resources._1001;
            a10.Enabled = true;
            //
            a11.Tag = p1010;
            a11.Image = Properties.Resources._1010;
            a11.Enabled = true;
            //
            a12.Tag = p1011;
            a12.Image = Properties.Resources._1011;
            a12.Enabled = true;
            //
            a13.Tag = p1100;
            a13.Image = Properties.Resources._1100;
            a13.Enabled = true;
            //
            a14.Tag = p1101;
            a14.Image = Properties.Resources._1101;
            a14.Enabled = true;
            //
            a15.Tag = p1110;
            a15.Image = Properties.Resources._1110;
            a15.Enabled = true;
            //
            a16.Tag = p1111;
            a16.Image = Properties.Resources._1111;
            a16.Enabled = true;
            //
            panel1.Enabled = true;
            //
            panel2.Enabled = false;
            foreach(PictureBox p in panel2.Controls)
            {
                p.Image = null;
                p.Enabled = true;
            }
            //
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    cells[i, j] = null;
                }
            }
            //
            c.Image = null;
            c.Tag = null;
            //
            BeginOfGame = DateTime.Now;
            //
            MouseClickNb = 0;
            //
            turn = WhoStarted;
            //
            if (TimeChallenge)
            {
                mytime.Text = "30";
                timeleft = 30;
                timer1.Enabled = true;
                lb2.Text = "";
                timeleft--;

            }
            DidGameEnd = false;
            if (!GameMode && !turn)
            {
                PieceToGive = ChooseRandomPiece(AvailablePieces);
                GivePieceGFX( AvailablePieces, PieceToGive, c,panel1, Pieces_Played);
                panel2.Enabled = true;
                turn = !turn;
                changeing_turns.Push(turn);
            }
        }
        //timer
        //
        int timeleft = 30;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TimeChallenge)
            {
                if (timeleft > 0)
                {
                    timeleft = timeleft - 1;
                    mytime.Text = (timeleft / 60).ToString() + ":" + (timeleft % 60).ToString(); ;
                   

                }
                else
                {
                    
                    timer1.Enabled = false;
                    Class1.StartMenue.axWindowsMediaPlayer1.URL = ("loser.mp3");
                    wplayer.controls.play();

                    lb2.Text = "SOORY, You Run Out Of Time!!!";
                }

               
            }
        }
        public static WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();






        static bool MakeWin;
        static int x, y;
        static Piece PieceToGive;
        static Piece ToBePlayed;

        private void PlayHard( Piece[,] board, PictureBox c, Panel PiecePanel, Panel BoardPanel, Stack<Point> Points_Occup, Stack<Piece> used, List<Piece> Remaining)


        {
            ToBePlayed = (Piece)c.Tag;
            SeeLocIfPlayed((Piece)c.Tag, board);
            if (MakeWin)
            {
                board[x, y] = (Piece)c.Tag;
                PlayMyTurnGFX(x, y, BoardPanel, c, Points_Occup);
            }
            else
            {
                SimpleComputerThinker((Piece)c.Tag, board, Remaining);
                if (PieceToGive != null)
                {
                    board[x, y] = (Piece)c.Tag;
                    PlayMyTurnGFX(x, y, BoardPanel, c, Points_Occup);
                    GivePieceGFX(Remaining, PieceToGive, c, PiecePanel, used);
                }
                else
                {
                    PlayAtRandom((Piece)c.Tag, board);
                    PlayMyTurnGFX(x, y, BoardPanel, c, Points_Occup);
                    PieceToGive = ChooseRandomPiece(Remaining);
                    GivePieceGFX(Remaining, PieceToGive, c, PiecePanel, used);
                }
            }
        }
        //
        //
        //
        private void PlayIntermidiate(Piece[,] board, PictureBox c, Panel PiecePanel, Panel BoardPanel, Stack<Point> Points_Occup, Stack<Piece> used, List<Piece> Remaining)
        {
            ToBePlayed = (Piece)c.Tag;
            SeeLocIfPlayed((Piece)c.Tag, board);
            if (MakeWin)
            {
                board[x, y] = (Piece)c.Tag;
                PlayMyTurnGFX(x, y, BoardPanel, c, Points_Occup);
            }
            else
            {
                PlayAtRandom((Piece)c.Tag, board);
                PlayMyTurnGFX(x, y, BoardPanel, c, Points_Occup);
                PieceToGive = ChooseRandomPiece(Remaining);
                GivePieceGFX(Remaining, PieceToGive, c, PiecePanel, used);
            }
        }
        //
        //
        //
        private void PlayEazy(Piece[,] board, PictureBox c, Panel PiecePanel, Panel BoardPanel, Stack<Point> Points_Occup, Stack<Piece> used, List<Piece> Remaining)
        {
            PlayAtRandom((Piece)c.Tag, board);
            PlayMyTurnGFX(x, y, BoardPanel, c, Points_Occup);
            PieceToGive = ChooseRandomPiece(Remaining);
            GivePieceGFX(Remaining, PieceToGive, c, PiecePanel, used);
        }
        //
        //
        //
        private void SeeLocIfPlayed(Piece MyPiece, Piece[,] board)
        {

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board[i, j] == null)
                    {
                        board[i, j] = MyPiece;
                        MakeWin = GameEnd.CheckForComputer(board);

                        board[i, j] = null;
                        if (MakeWin)
                        {
                            x = i;
                            y = j;
                            break;
                        }
                    }
                }
                if (MakeWin) break;
            }
        }
        //
        //
        //
        private void SeeLoc(Piece MyPiece, Piece[,] board)
        {

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board[i, j] == null)
                    {
                        board[i, j] = MyPiece;
                        MakeWin = GameEnd.CheckForComputer(board);

                        board[i, j] = null;
                    }
                    if (!MakeWin)
                    {
                        break;
                    }
                }
                if (!MakeWin) break;
            }
        }
        //
        //
        //
        private Piece ChoosseAPiece(List<Piece> Remaining, Piece[,] board)
        {
            Piece myPiece;
            int i = 0;
            while (i < Remaining.Count && MakeWin)
            {
                myPiece = Remaining[i];
                SeeLoc(myPiece, board);
                if (!MakeWin)
                {
                    return myPiece;
                }
                i++;
            }
            return null;
        }
        //
        //
        //
        private Piece ChooseRandomPiece(List<Piece> Remaining)
        {
            Random rnd = new Random();
            int i = rnd.Next(Remaining.Count);
            Piece myPiece = Remaining[i];
            return myPiece;
        }
        //
        //
        //
        private void SimpleComputerThinker(Piece ToBePlayed, Piece[,] board, List<Piece> Remaining)
        {
            for (int m = 0; m < 4; m++)
            {
                for (int n = 0; n < 4; n++)
                {
                    if (board[m, n] == null)
                    {
                        board[m, n] = ToBePlayed;
                        PieceToGive = ChoosseAPiece(Remaining, board);
                        board[m, n] = null;
                        if (PieceToGive != null)
                        {
                            x = m;
                            y = n;
                            break;
                        }
                    }
                }
                if (PieceToGive != null)
                {
                    break;
                }
            }
        }
        //
        //
        //
        private void PlayAtRandom(Piece ToBePlayed, Piece[,] board)
        {
            List<Point> availabel_points = new List<Point>();
            Random rnd = new Random();
            for (int i=0;i<4;i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board[i, j] == null)
                    {
                        availabel_points.Add(new Point(i, j));
                    }
                }
            }
            int XRND = rnd.Next(availabel_points.Count);
            x = availabel_points[XRND].X;
            y = availabel_points[XRND].Y;

            board[x, y] = ToBePlayed;
        }
        //
        //
        //
        private void GivePieceGFX(List<Piece> Remaining, Piece PieceToGive, PictureBox c, Panel PiecePanel, Stack<Piece> used)
        {

            foreach (PictureBox piece in PiecePanel.Controls)
            {
                if (piece.Tag == PieceToGive)
                {
                    c.Image = piece.Image;
                    c.Tag = piece.Tag;
                    piece.Image = null;
                    piece.Enabled = false;
                    used.Push(PieceToGive);
                    Remaining.Remove(PieceToGive);
                    PiecePanel.Enabled = false;
                }
            }
        }
        //
        //
        //
        private void PlayMyTurnGFX(int x, int y, Panel BoardPanel, PictureBox c, Stack<Point> Points_Occup)
        {
            Point p = new Point(x, y);
            foreach (PictureBox b in BoardPanel.Controls)
            {
                if ((Point)b.Tag == p)
                {
                    Points_Occup.Push(p);
                    b.Image = c.Image;
                    c.Image = null;
                    b.Enabled = false;
                }
            }
        }
        //
        //
        //
        private void FixeWinner()
        {
            if (winner == player2)
            {
                winner = "LOST";
            }
            if (winner == "None")
            {
                winner = "TIE";
            }
            if (winner == player1)
            {
                winner = "WON";
            }
        }

        private void c_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

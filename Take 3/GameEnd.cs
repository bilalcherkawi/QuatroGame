using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Take_3
{
    class GameEnd
    {
        //
        //checking for a victory by a row.
        //
        private static bool CheckRow(Piece[,] slots)
        {
            for (int i = 0; i < 4; i++)
            {
                if (slots[i, 0] != null && slots[i, 1] != null && slots[i, 2] != null && slots[i, 3] != null)
                {
                    if ((slots[i, 0].Color == slots[i, 1].Color) && (slots[i, 0].Color == slots[i, 2].Color) && (slots[i, 0].Color == slots[i, 3].Color))
                        return true;
                    if ((slots[i, 0].Shape == slots[i, 1].Shape) && (slots[i, 0].Shape == slots[i, 2].Shape) && (slots[i, 0].Shape == slots[i, 3].Shape))
                        return true;
                    if ((slots[i, 0].Height == slots[i, 1].Height) && (slots[i, 0].Height == slots[i, 2].Height) && (slots[i, 0].Height == slots[i, 3].Height))
                        return true;
                    if ((slots[i, 0].Hole == slots[i, 1].Hole) && (slots[i, 0].Hole == slots[i, 2].Hole) && (slots[i, 0].Hole == slots[i, 3].Hole))
                        return true;
                }
            }
            return false;
        }
        //
        //checking for a victory by a column.
        //
        private static bool CheckColumn(Piece[,] slots)
        {
            for (int i = 0; i < 4; i++)
            {
                if (slots[0, i] != null && slots[1, i] != null && slots[2, i] != null && slots[3, i] != null)
                {
                    if ((slots[0, i].Color == slots[1, i].Color) && (slots[0, i].Color == slots[2, i].Color) && (slots[0, i].Color == slots[3, i].Color))
                        return true;
                    if ((slots[0, i].Shape == slots[1, i].Shape) && (slots[0, i].Shape == slots[2, i].Shape) && (slots[0, i].Shape == slots[3, i].Shape))
                        return true;
                    if ((slots[0, i].Height == slots[1, i].Height) && (slots[0, i].Height == slots[2, i].Height) && (slots[0, i].Height == slots[3, i].Height))
                        return true;
                    if ((slots[0, i].Hole == slots[1, i].Hole) && (slots[0, i].Hole == slots[2, i].Hole) && (slots[0, i].Hole == slots[3, i].Hole))
                        return true;
                }
            }
            return false;
        }
        //
        //checking for a victory by a diagonal.
        //
        private static bool CheckDiagonale(Piece[,] slots)
        {
            if (slots[0, 0] != null && slots[1, 1] != null && slots[2, 2] != null && slots[3, 3] != null)
            {
                if ((slots[0, 0].Color == slots[1, 1].Color) && (slots[0, 0].Color == slots[2, 2].Color) && (slots[0, 0].Color == slots[3, 3].Color))
                    return true;
                if ((slots[0, 0].Shape == slots[1, 1].Shape) && (slots[0, 0].Shape == slots[2, 2].Shape) && (slots[0, 0].Shape == slots[3, 3].Shape))
                    return true;
                if ((slots[0, 0].Height == slots[1, 1].Height) && (slots[0, 0].Height == slots[2, 2].Height) && (slots[0, 0].Height == slots[3, 3].Height))
                    return true;
                if ((slots[0, 0].Hole == slots[1, 1].Hole) && (slots[0, 0].Hole == slots[2, 2].Hole) && (slots[0, 0].Hole == slots[3, 3].Hole))
                    return true;
            }

            if (slots[0, 3] != null && slots[2, 1] != null && slots[1, 2] != null && slots[3, 0] != null)
            {
                if ((slots[0, 3].Color == slots[2, 1].Color) && (slots[0, 3].Color == slots[1, 2].Color) && (slots[0, 3].Color == slots[3, 0].Color))
                    return true;
                if ((slots[0, 3].Shape == slots[2, 1].Shape) && (slots[0, 3].Shape == slots[1, 2].Shape) && (slots[0, 3].Shape == slots[3, 0].Shape))
                    return true;
                if ((slots[0, 3].Height == slots[2, 1].Height) && (slots[0, 3].Height == slots[1, 2].Height) && (slots[0, 3].Height == slots[3, 0].Height))
                    return true;
                if ((slots[0, 3].Hole == slots[2, 1].Hole) && (slots[0, 3].Hole == slots[1, 2].Hole) && (slots[0, 3].Hole == slots[3, 0].Hole))
                    return true;
            }
            return false;
        }
        //
        //
        //
        private static bool CheckSquare(Piece[,] slots)
        {
            if (!Menue.GetRules)
                return false;
            else
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (slots[i, j] != null && slots[i, j+1] != null && slots[i+1, j] != null && slots[i+1, j+1] != null)
                    {
                        if ((slots[i, j].Color == slots[i, j+1].Color) && (slots[i, j].Color == slots[i+1, j].Color) && (slots[i, j].Color == slots[i+1, j+1].Color))
                            return true;
                        if ((slots[i, j].Shape == slots[i, j+1].Shape) && (slots[i, j].Shape == slots[i+1, j].Shape) && (slots[i, j].Shape == slots[i+1, j+1].Shape))
                            return true;
                        if ((slots[i, j].Height == slots[i, j+1].Height) && (slots[i, j].Height == slots[i+1, j].Height) && (slots[i, j].Height == slots[i+1, j+1].Height))
                            return true;
                        if ((slots[i, j].Hole == slots[i, j+1].Hole) && (slots[i, j].Hole == slots[i+1, j].Hole) && (slots[i, j].Hole == slots[i+1, j+1].Hole))
                            return true;
                    }
                }
            }
            return false;
        }
        //
        //See if we should end the game.
        //
         
        
       
        public static void CheckGame(Piece[,] s, bool turn, string p1, string p2, Panel panel1, ref bool end, ref string winner)
        {
            if (CheckRow(s) || CheckColumn(s) || CheckDiagonale(s) || CheckSquare(s))
            {
                {
                    if (turn)
                    {
                        Class1.StartMenue.axWindowsMediaPlayer1.URL = "drum roll.mp3";
                        MessageBox.Show(p1 + " win");
                     
                        winner = p1;
                    }
                    else
                    {
                        Class1.StartMenue.axWindowsMediaPlayer1.URL = "drum roll.mp3";
                        MessageBox.Show(p2 + " win");
                        
                        winner = p2;
                    }
                    panel1.Enabled = false;
                    end = true;
                }
              
               
                
              
              
            }
            else
            {
                //
                // Checking for a tie.
                //
                bool tie = true;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (s[i, j] == null) tie = false;
                    }
                }
                if (tie)
                {
                    winner = "None";
                    MessageBox.Show("there is a tie");
                    end = true;
                }
            }
        }
        public static bool CheckForComputer(Piece[,] s)
        {
            if (CheckRow(s) || CheckColumn(s) || CheckDiagonale(s) || CheckSquare(s))
                return true;
            return false;
        }
    }
}

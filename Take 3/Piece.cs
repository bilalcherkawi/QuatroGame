using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Take_3
{
    class Piece
    {
        public int Shape { get; set; }
        public int Color { get; set; }
        public int Height { get; set; }
        public int Hole { get; set; }

        public Piece(int a, int b, int c, int d)
        {
            Shape = a;
            Color = b;
            Height = c;
            Hole = d;

        }


        public bool CompairPieces(int a, int b)
        {
            if (a == b) return true;
            return false;
        }
    }
}

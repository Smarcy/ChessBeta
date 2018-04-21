using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Engine
{
    public class FreeTile : Piece
    {
        private const char _SYMBOL = 'X';

        public FreeTile(PieceColor pieceColor, Bitmap image) : base(_SYMBOL, pieceColor, image)
        {
            
        }

        public override bool ValidMove(Piece[,] board, (int Y, int X) startPosition, (int Y, int X) targetPosition, out (int Y, int X) killPosition)
        {
            killPosition.X = -1;
            killPosition.Y = -1;
            return false;
        }
    }
}

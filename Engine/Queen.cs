using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Engine
{
    public class Queen : Piece
    {
        private const char _SYMBOL = 'Q';

        public Queen(PieceColor pieceColor, Bitmap image) : base(_SYMBOL, pieceColor, image)
        {

        }
    }
}

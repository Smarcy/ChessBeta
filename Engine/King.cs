using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Engine
{
    public class King : Piece
    {
        private const char _SYMBOL = 'K';

        public King(PieceColor pieceColor, Bitmap image) : base(_SYMBOL, pieceColor, image)
        {

        }
    }
}

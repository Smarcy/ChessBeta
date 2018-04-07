using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class King : Piece
    {
        private const char _SYMBOL = 'K';

        public King(PieceColor pieceColor) : base(_SYMBOL, pieceColor)
        {

        }
    }
}

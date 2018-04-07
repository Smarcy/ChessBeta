using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class FreeTile : Piece
    {
        private const char _SYMBOL = 'X';

        public FreeTile(PieceColor pieceColor) : base(_SYMBOL, pieceColor)
        {
            
        }
    }
}

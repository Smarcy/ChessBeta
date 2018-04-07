using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Bishop : Piece
    {
        private const char _SYMBOL = 'B';

        public Bishop(PieceColor pieceColor) : base(_SYMBOL, pieceColor)
        {

        }
    }
}

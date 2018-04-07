using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Rook : Piece
    {
        private const char _SYMBOL = 'R';



        public Rook(PieceColor pieceColor) : base(_SYMBOL, pieceColor)
        {

        }
    }
}

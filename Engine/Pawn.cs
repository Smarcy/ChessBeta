using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Engine
{
    public class Pawn : Piece
    {
        public bool Virgin { get; set; }
        private const char _SYMBOL = 'P';

        public Pawn(PieceColor pieceColor, Bitmap image) : base(_SYMBOL, pieceColor, image)
        {
            
        }
    }
}

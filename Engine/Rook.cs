﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Engine
{
    public class Rook : Piece
    {
        private const char _SYMBOL = 'R';



        public Rook(PieceColor pieceColor, Bitmap image) : base(_SYMBOL, pieceColor, image)
        {

        }

        public override bool ValidMove(Piece[,] board, (int Y, int X) startPosition, (int Y, int X) targetPosition)
        {
            throw new NotImplementedException();
        }
    }
}

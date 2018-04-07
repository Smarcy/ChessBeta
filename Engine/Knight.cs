﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Engine
{
    public class Knight : Piece
    {
        private const char _SYMBOL = 'S';

        public Knight(PieceColor pieceColor, Bitmap image) : base(_SYMBOL, pieceColor, image)
        {

        }
    }
}

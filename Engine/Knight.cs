﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Knight : Piece
    {
        private const char _SYMBOL = 'S';

        public Knight(PieceColor pieceColor) : base(_SYMBOL, pieceColor)
        {

        }
    }
}

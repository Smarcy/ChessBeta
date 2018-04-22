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

        public override bool ValidMove(Piece[,] board, (int Y, int X) startPosition, (int Y, int X) targetPosition, out (int Y, int X) killPosition)
        {
            killPosition.X = -1;
            killPosition.Y = -1;

            int dirY = Math.Abs(startPosition.Y - targetPosition.Y);
            int dirX = Math.Abs(startPosition.X - targetPosition.X);

            #region Possible Knight Movements
            List<(int Y, int X)> validMoves =
                new List<(int Y, int X)>
                {
                    (2, 1),
                    (1, 2)
                };
            #endregion

            foreach (var element in validMoves)
            {
                if (element.Y == dirY && element.X == dirX)
                    return true;
            }

            return false;
        }
    }
}

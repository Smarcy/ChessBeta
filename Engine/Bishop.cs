using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Engine
{
    public class Bishop : Piece
    {
        private const char _SYMBOL = 'B';

        public Bishop(PieceColor pieceColor, Bitmap image) : base(_SYMBOL, pieceColor, image)
        {

        }

        public override bool ValidMove(Piece[,] board, (int Y, int X) startPosition, (int Y, int X) targetPosition, out (int Y, int X) killPosition)
        {
            killPosition.X = -1;
            killPosition.Y = -1;
            int xMove = Math.Abs(targetPosition.X - startPosition.X);   // X-Movement made
            int yMove = Math.Abs(targetPosition.Y - startPosition.Y);   // Y-Movement made

            if (xMove != yMove) // not a diagonal move
                return false;

            var dirX = startPosition.X > targetPosition.X ? -1 : 1;
            var dirY = startPosition.Y > targetPosition.Y ? -1 : 1;

            for (int x = (startPosition.X + dirX), y = (startPosition.Y + dirY);
                 x != targetPosition.X && y != targetPosition.Y;
                 x += dirX, y += dirY)
            {
                switch (board[y, x].pColor)
                {
                    // Adjust targetPosition if a Piece of the same color is in the way
                    case PieceColor.White when this.pColor == PieceColor.White:
                    case PieceColor.Black when this.pColor == PieceColor.Black:

                        if(startPosition.X == x - dirX)
                            return false;

                        killPosition.X = (x + dirX);
                        killPosition.Y = (y + dirY);
                            return false;

                    case PieceColor.White when this.pColor == PieceColor.Black:
                    case PieceColor.Black when this.pColor == PieceColor.White:

                        killPosition.X = x;
                        killPosition.Y = y;
                            return false;
                }
            }
            return true;
        }
    }
}

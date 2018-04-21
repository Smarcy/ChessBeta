using System;
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

        public override bool ValidMove(Piece[,] board, (int Y, int X) startPosition, (int Y, int X) targetPosition, out (int Y, int X) killPosition)
        {
            killPosition.X = -1;
            killPosition.Y = -1;
            int dirY;
            int dirX;

            if (targetPosition.Y != startPosition.Y && targetPosition.X != startPosition.X)
                return false;

            if (targetPosition.Y != startPosition.Y)
            {
                if (targetPosition.Y < startPosition.Y)
                {
                    dirY = -1;

                    for (int y = (startPosition.Y + dirY); y >= targetPosition.Y; y += dirY)
                    {
                        if (board[y, startPosition.X].pColor != PieceColor.None)
                            if (board[y, startPosition.X].pColor != board[startPosition.Y, startPosition.X].pColor)
                            {
                                killPosition.X = startPosition.X;
                                killPosition.Y = y;
                                return false;
                            }

                        if (board[y, startPosition.X].pColor == board[startPosition.Y, startPosition.X].pColor)
                            return false;
                    }

                    return true;
                }
                else
                {
                    dirY = 1;

                    for (int y = (startPosition.Y + dirY); y <= targetPosition.Y; y += dirY)
                    {
                        if (board[y, startPosition.X].pColor != PieceColor.None)
                            if (board[y, startPosition.X].pColor != board[startPosition.Y, startPosition.X].pColor)
                            {
                                killPosition.X = startPosition.X;
                                killPosition.Y = y;
                                return false;
                            }

                        if (board[y, startPosition.X].pColor == board[startPosition.Y, startPosition.X].pColor)
                            return false;
                    }

                    return true;
                }


            }

            if (targetPosition.X != startPosition.X)
            {
                if (targetPosition.X < startPosition.X)
                {
                    dirX = -1;

                    for (int x = (startPosition.X + dirX); x >= targetPosition.X; x += dirX)
                    {
                        if (board[startPosition.Y, x].pColor != PieceColor.None)
                            if (board[startPosition.Y, x].pColor != board[startPosition.Y, startPosition.X].pColor)
                            {
                                killPosition.X = x;
                                killPosition.Y = startPosition.Y;
                                return false;
                            }

                        if (board[startPosition.Y, x].pColor == board[startPosition.Y, startPosition.X].pColor)
                            return false;
                    }

                    return true;
                }
                else
                {
                    dirX = 1;

                    for (int x = (startPosition.X + dirX); x <= targetPosition.X; x += dirX)
                    {
                        if (board[startPosition.Y, x].pColor != PieceColor.None)
                            if (board[startPosition.Y, x].pColor != board[startPosition.Y, startPosition.X].pColor)
                            {
                                killPosition.X = x;
                                killPosition.Y = startPosition.Y;
                                return false;
                            }

                        if (board[startPosition.Y, x].pColor == board[startPosition.Y, startPosition.X].pColor)
                            return false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}

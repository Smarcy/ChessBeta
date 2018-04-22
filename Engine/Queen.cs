using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Engine
{
    public class Queen : Piece
    {
        private const char _SYMBOL = 'Q';

        public Queen(PieceColor pieceColor, Bitmap image) : base(_SYMBOL, pieceColor, image)
        {

        }

        public override bool ValidMove(Piece[,] board, (int Y, int X) startPosition, (int Y, int X) targetPosition, out (int Y, int X) killPosition)
        {
            killPosition.X = -1;
            killPosition.Y = -1;
            var tilesToMoveY = startPosition.Y - targetPosition.Y;
            var tilesToMoveX = startPosition.X - targetPosition.X;
            var startTile = board[startPosition.Y, startPosition.X];
            var targetTile = board[targetPosition.Y, targetPosition.X];
            int j = (startPosition.Y - 1);
            int j2 = (startPosition.Y + 1);
            int i = (startPosition.X - 1);
            int i2 = (startPosition.X + 1);
            int k = targetPosition.X;

            #region Movement Y+ Diagonal
            if (targetPosition.Y < startPosition.Y && targetPosition.X != startPosition.X)
            {
                if (targetPosition.X < startPosition.X)
                {
                    if (tilesToMoveX == tilesToMoveY)
                    {
                        while (i >= k)
                        {
                            if (board[j, i].pColor != PieceColor.None)
                            {
                                if (board[j, i].pColor != startTile.pColor)
                                {
                                    killPosition.X = i;
                                    killPosition.Y = j;
                                }
                                return false;
                            }
                            j--;
                            i--;
                        }
                        return true;
                    }
                }

                if (targetPosition.X > startPosition.X)
                {
                    if (Math.Abs(tilesToMoveX) == Math.Abs(tilesToMoveY))
                    {
                        while (i2 <= k)
                        {
                            if (board[j, i2].pColor != PieceColor.None)
                            {
                                if (board[j, i2].pColor != startTile.pColor)
                                {
                                    killPosition.X = i2;
                                    killPosition.Y = j;
                                }
                                return false;
                            }
                            j--;
                            i2++;
                        }
                        return true;
                    }
                }
            }
            #endregion 
            #region Movement Y- Diagonal
            if (targetPosition.Y > startPosition.Y && targetPosition.X != startPosition.X)
            {
                if (targetPosition.X < startPosition.X)
                {
                    if (Math.Abs(tilesToMoveX) == Math.Abs(tilesToMoveY))
                    {
                        while (i >= k)
                        {
                            if (board[j2, i].pColor != PieceColor.None)
                            {
                                if (board[j2, i].pColor != startTile.pColor)
                                {
                                    killPosition.X = i;
                                    killPosition.Y = j2;
                                }
                                return false;
                            }
                            j2++;
                            i--;
                        }
                        return true;
                    }
                }

                if (targetPosition.X > startPosition.X)
                {
                    if (Math.Abs(tilesToMoveX) == Math.Abs(tilesToMoveY))
                    {
                        while (i2 <= k)
                        {
                            if (board[j2, i2].pColor != PieceColor.None)
                            {
                                if (board[j2, i2].pColor != startTile.pColor)
                                {
                                    killPosition.X = i2;
                                    killPosition.Y = j2;
                                }
                                return false;
                            }
                            j2++;
                            i2++;
                        }
                        return true;
                    }
                }
            }
            #endregion

            #region Movement Rook-wise
            if (targetPosition.Y != startPosition.Y && targetPosition.X != startPosition.X)
                return false;

            if (targetPosition.Y != startPosition.Y)
            {
                int dirY;

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
                int dirX = -1;
                if (targetPosition.X < startPosition.X)
                {

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
#endregion

            return false;
        }
    }
}

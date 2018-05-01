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
            /*killPosition.X = -1;
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


              #region Movement Y+
              if (targetPosition.Y < startPosition.Y)
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
              #region Movement Y-
              if (targetPosition.Y > startPosition.Y)
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
              #endregion*/


            killPosition.X = -1;
            killPosition.Y = -1;
            int xMove = Math.Abs(targetPosition.X - startPosition.X);   // X-Movement made
            int yMove = Math.Abs(targetPosition.Y - startPosition.Y);   // Y-Movement made

            if (xMove != yMove) // not a diagonal move
                return false;

            var dirX = startPosition.X > targetPosition.X ? -1 : 1;
            var dirY = startPosition.Y > targetPosition.X ? -1 : 1;

            for (int x = startPosition.X, y = startPosition.Y;
                x < targetPosition.X && y < targetPosition.Y;
                x += dirX, y += dirY)
            {
                switch (board[y, x].pColor)
                {
                    // Adjust targetPosition if a Piece of the same color is in the way
                    case PieceColor.White when this.pColor == PieceColor.White:
                    case PieceColor.Black when this.pColor == PieceColor.Black:

                        if(startPosition.X == x - dirX)
                        return false;

                        killPosition.X = (x - dirX);
                        killPosition.Y = (y - dirY);
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

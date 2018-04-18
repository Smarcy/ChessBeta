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
        private bool FirstMove;
        private const char _SYMBOL = 'P';

        public Pawn(PieceColor pieceColor, Bitmap image) : base(_SYMBOL, pieceColor, image)
        {
            FirstMove = true;
        }

        public override bool ValidMove(Piece[,] board, (int Y, int X) startPosition, (int Y, int X) targetPosition)
        {
            var tilesToMoveY = startPosition.Y - targetPosition.Y;
            var tilesToMoveX = startPosition.X - targetPosition.X;
            var startTile = board[startPosition.Y, startPosition.X];
            var targetTile = board[targetPosition.Y, targetPosition.X];

            var tilesAllowedToMove = FirstMove == false ? 1 : 2;

            FirstMove = false;

            if (tilesToMoveY > tilesAllowedToMove) return false;

            if ((startTile.pColor == PieceColor.White) && (targetTile.pColor == PieceColor.Black))
            {
                if ((tilesToMoveX == 1 || tilesToMoveX == -1) && tilesToMoveY == 1)
                    return true;
                return false;
            }

            if ((tilesToMoveX > 0 || tilesToMoveX < 0) && targetTile.pColor != startTile.pColor && targetTile.pColor != PieceColor.None)
                return true;

            if (tilesToMoveX != 0) return false;

            return tilesToMoveY > 0;
        }

        //public override bool ValidMove(Piece[,] board, Tuple<int, int> startPos, Tuple<int, int> targetPos)
        //{
        //    if (board[startPos.Item1, startPos.Item2].pColor == PieceColor.Black &&
        //        (targetPos.Item1 - startPos.Item1) == 1)
        //    {
        //        if (startPos.Item2 != targetPos.Item2 && startPos.Item2 == targetPos.Item2 + 1 ||
        //            startPos.Item2 == targetPos.Item2 - 1)
        //        {
        //            if (board[targetPos.Item1, targetPos.Item2].pColor == PieceColor.White)
        //            {
        //                return true;
        //            }
        //            return false;

        //        }

        //        return true;
        //    }

        //    if (board[startPos.Item1, startPos.Item2].pColor == PieceColor.White && (startPos.Item1 - targetPos.Item1) == 1)
        //        if (startPos.Item2 == targetPos.Item2)
        //            return true;

        //    return false;
        //}
    }
}

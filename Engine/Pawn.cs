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

        public override bool ValidMove(Piece[,] board, (int Y, int X) startPosition, (int Y, int X) targetPosition, out (int Y, int X) killPosition)
        {
            killPosition.X = -1;
            killPosition.Y = -1;
            var tilesToMoveY = startPosition.Y - targetPosition.Y;
            var tilesToMoveX = startPosition.X - targetPosition.X;
            var startTile = board[startPosition.Y, startPosition.X];
            var targetTile = board[targetPosition.Y, targetPosition.X];
            var tilesAllowedToMove = 0;

            switch (startTile.pColor)
            {
                case PieceColor.White:
                    tilesAllowedToMove = FirstMove == false ? 1 : 2;
                    break;
                case PieceColor.Black:
                    tilesAllowedToMove = FirstMove == false ? -1 : -2;
                    break;
            }

            FirstMove = false;

            if (tilesToMoveY > tilesAllowedToMove && startTile.pColor == PieceColor.White) return false;
            if (tilesToMoveY < tilesAllowedToMove && startTile.pColor == PieceColor.Black) return false;

            switch (startTile.pColor)
            {
                case PieceColor.Black when (targetTile.pColor == PieceColor.White):
                    return (tilesToMoveX == 1 || tilesToMoveX == -1) && tilesToMoveY == -1;
                case PieceColor.White when (targetTile.pColor == PieceColor.Black):
                    return (tilesToMoveX == 1 || tilesToMoveX == -1) && tilesToMoveY == 1;
            }

            if ((tilesToMoveX > 0 || tilesToMoveX < 0) && targetTile.pColor != startTile.pColor && targetTile.pColor != PieceColor.None)
                return true;

            if (tilesToMoveX != 0) return false;

            if (tilesToMoveY > 0 && startTile.pColor == PieceColor.White)
                return true;
            return tilesToMoveY < 0 && startTile.pColor == PieceColor.Black;
        }
    }
}

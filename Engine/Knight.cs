using System;
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

            List<Tuple<int, int>> validMoves =
                new List<Tuple<int, int>>
                {
                    new Tuple<int, int>(2, 1),
                    new Tuple<int, int>(2, -1),
                    new Tuple<int, int>(1, 2),
                    new Tuple<int, int>(-1, 2),
                };

            foreach (var element in validMoves)
            {
                if (element.Item1 == dirY)
                {
                    if (element.Item2 == dirX)
                        return true;
                }
            }

            return false;
        }
    }
}

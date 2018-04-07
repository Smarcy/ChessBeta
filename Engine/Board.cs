using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Engine
{
    public class Board
    {
        private Pawn pawn;
        public Piece[,] Chessboard = new Piece[8,8];

        public Piece[,] PopulateBoard()
        {

            for (int i = 0; i < 8; i++)
            {
                Chessboard[1, i] = new Pawn(Piece.PieceColor.Black);
                Chessboard[6, i] = new Pawn(Piece.PieceColor.White);
            }
            //
            // Populate White Pieces
            //
            Chessboard[0, 0] = new Rook(Piece.PieceColor.White);
            Chessboard[0, 7] = new Rook(Piece.PieceColor.White);
            Chessboard[0, 1] = new Knight(Piece.PieceColor.White);
            Chessboard[0, 6] = new Knight(Piece.PieceColor.White);
            Chessboard[0, 2] = new Bishop(Piece.PieceColor.White);
            Chessboard[0, 5] = new Bishop(Piece.PieceColor.White);
            Chessboard[0, 3] = new Queen(Piece.PieceColor.White);
            Chessboard[0, 4] = new King(Piece.PieceColor.White);

            //
            // Populate Black Pieces
            //
            Chessboard[7, 0] = new Rook(Piece.PieceColor.Black);
            Chessboard[7, 7] = new Rook(Piece.PieceColor.Black);
            Chessboard[7, 1] = new Knight(Piece.PieceColor.Black);
            Chessboard[7, 6] = new Knight(Piece.PieceColor.Black);
            Chessboard[7, 2] = new Bishop(Piece.PieceColor.Black);
            Chessboard[7, 5] = new Bishop(Piece.PieceColor.Black);
            Chessboard[7, 3] = new Queen(Piece.PieceColor.Black);
            Chessboard[7, 4] = new King(Piece.PieceColor.Black);

            //
            // Populate Free Tiles
            //
            for (int i = 2; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Chessboard[i,j] = new FreeTile(Piece.PieceColor.None);
                }
                
            }

            return Chessboard;
        }

        public void DrawBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                Console.Write(Chessboard[0,i].Symbol);
                Console.Write(" ");
            }
            Console.WriteLine();
            for (int i = 0; i < 8; i++)
            {
                Console.Write(Chessboard[1, i].Symbol);
                Console.Write(" ");
            }
            Console.WriteLine();
            for (int i = 2; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(Chessboard[i,j].Symbol);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < 8; i++)
            {
                Console.Write(Chessboard[6, i].Symbol);
                Console.Write(" ");
            }
            Console.WriteLine();
            for (int i = 0; i < 8; i++)
            {
                Console.Write(Chessboard[7, i].Symbol);
                Console.Write(" ");
            }
        }
    }
}

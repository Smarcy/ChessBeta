using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Engine
{
    public class Piece
    {
        private char _symbol;
        private PieceColor _pieceColor;

        public PieceColor pColor
        {
            get { return _pieceColor;}
            set { _pieceColor = value; }

        }

        public char Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }

        public enum PieceColor
        {
            Black,
            White,
            None
        };

        public Piece(char symbol, PieceColor pieceColor)
        {
            Symbol = symbol;
            pColor = pieceColor;
        }
       
    }
}

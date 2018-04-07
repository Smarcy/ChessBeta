using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Drawing;

namespace Engine
{
    public abstract class Piece
    {
        private char _symbol;
        private PieceColor _pieceColor;
        private Bitmap _image;

        public Bitmap Image
        {
            get { return _image;}
            set { _image = value; }
        }

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

        protected Piece(char symbol, PieceColor pieceColor, Bitmap image)
        {
            Symbol = symbol;
            pColor = pieceColor;
            Image = image;
        }
       
    }
}

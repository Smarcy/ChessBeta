using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Engine;

namespace ChessBeta
{
    public partial class Form1 : Form
    {
        #region member
        private Engine.Board _board;
        private Engine.Piece[,] _piece;
        private Tuple<int, int> _firstClick;
        private Tuple<int, int> _secondClick;
        private bool _clickedFlag = false;
        private int xPosFrom;
        private int yPosFrom;
        private readonly System.Windows.Forms.Button[,] _btnAll = new Button[8, 8];
        #endregion

        public Form1()
        {
            InitializeComponent();
            _btnAll = AddButtons();
        }

        private Button[,] AddButtons()
        {

            _board = new Engine.Board();
            _piece = _board.PopulateBoard();
            int xPos = 0;
            int yPos = 0;
            // Declare and assign number of buttons = 26 
            System.Windows.Forms.Button[,] btnArray = new System.Windows.Forms.Button[8,8];
            // Create (26) Buttons: 
            for (int i = 0; i < 8; i++)
                for(int j = 0; j < 8; j++)
                // Initialize one variable 
                btnArray[i,j] = new System.Windows.Forms.Button();

           

            for(int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    btnArray[i,j].Tag = i + 1; // Tag of button 
                    btnArray[i, j].Width = 70; // Width of button 
                    btnArray[i, j].Height = 70; // Height of button 
                    btnArray[i, j].Tag = new Tuple<int, int>(i,j);

                    switch (i % 2)
                    {
                        case 0:
                            if ((j % 2) == 0)
                            {
                                btnArray[i, j].BackColor = Color.White;
                            } else btnArray[i, j].BackColor = Color.Black;

                            break;
                        case 1:
                            if ((j % 2) == 0)
                            {
                                btnArray[i, j].BackColor = Color.Black;
                            } else btnArray[i, j].BackColor = Color.White;

                            break;
                    }


                    if (j == 0) // Location of second line of buttons: 
                        xPos = 0;

                    if (i >= 1)
                        yPos = btnArray[i-1, j].Top + 70;

                    // Location of button: 
                    btnArray[i, j].Left = xPos;
                    btnArray[i, j].Top = yPos;
                    // Add buttons to a Panel: 
                    pnlButtons.Controls.Add(btnArray[i, j]); // Let panel hold the Buttons 
                    xPos = xPos + btnArray[i, j].Width; // Left of next button 

                    // the Event of click Button 
                    btnArray[i, j].Click += new System.EventHandler(ClickButton);
                }
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    btnArray[i, j].Image = _piece[i, j].Image;
                }
            }
            
            return btnArray;
        }

        public void ClickButton(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;

            if (!_clickedFlag)
            {
                _firstClick = (Tuple<int, int>)btn.Tag;
                xPosFrom = _firstClick.Item1;
                yPosFrom = _firstClick.Item2;

                _clickedFlag = true;
            }
            else
            {
                _secondClick = (Tuple<int, int>)btn.Tag;

                if (_piece[xPosFrom, _firstClick.Item2].Symbol == 'P')
                {
                    bool valid = _piece[xPosFrom, yPosFrom].ValidMove(_piece, (xPosFrom, yPosFrom), (_secondClick.Item1, _secondClick.Item2));

                    if (valid)
                    {
                        _board.Chessboard[_secondClick.Item1, _secondClick.Item2] = _board.Chessboard[xPosFrom, yPosFrom];
                        _btnAll[_secondClick.Item1, _secondClick.Item2].Image = _btnAll[xPosFrom, yPosFrom].Image;

                        _btnAll[xPosFrom, yPosFrom].Image = null;
                        _board.Chessboard[xPosFrom, yPosFrom] = new FreeTile(Piece.PieceColor.None, null);
                    }
                }

                _clickedFlag = false;

            }
        }
    }
}
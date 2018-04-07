using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ChessBeta
{
    public partial class Form1 : Form
    {
        private Engine.Board _board;
        private Engine.Piece[,] _piece;

        public Form1()
        {
            InitializeComponent();
            AddButtons();



        }

        private void AddButtons()
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
                    {
                        xPos = 0;
                       // yPos = btnArray[i,j].Top + 70;
                    }
                    if(i >= 1)
                        yPos = btnArray[i-1, j].Top + 70;

                    // Location of button: 
                    btnArray[i, j].Left = xPos;
                    btnArray[i, j].Top = yPos;
                    // Add buttons to a Panel: 
                    pnlButtons.Controls.Add(btnArray[i, j]); // Let panel hold the Buttons 
                    xPos = xPos + btnArray[i, j].Width; // Left of next button 
                    // Write English Character: 
                  //  btnArray[i,j].Text = ((char) (n)).ToString();

                    // the Event of click Button 
                    btnArray[i, j].Click += new System.EventHandler(ClickButton);
                    
                }
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    btnArray[i, j].Text = _piece[i, j].Symbol.ToString();
                }
            }
        }

        public void ClickButton(Object sender, System.EventArgs e)
        {
            Button btn = (Button) sender;
            MessageBox.Show("You clicked character [" + btn.Text + "]");
        }
    }
}
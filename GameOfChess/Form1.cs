using GameOfChess.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfChess
{
    public partial class Form1 : System.Windows.Forms.Form
    {


        static Board myBoard = new Board(8);  //Making reference to the class Board.Contains the values of the board


        public Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size]; //Array of buttons whose values are determined by MyBoard
        public Image chessGraphObject;



        public Button prevButton;
        bool isMoving = false;
        public int currPlayer;
        public Form1()
        {
            InitializeComponent();
            chessGraphObject = new Bitmap(Resources.chess);
            populateMap();
            currPlayer = 1;

        }


        private void populateMap()
        {
            //Creating buttons and placing them into panel
            int buttonSize = panel.Height / myBoard.Size;
            panel.Width = panel.Height;
            //Nested loops to create buttons and print image on them
            for (int j = 0; j < myBoard.Size; j++)
            {
                for (int i = 0; i < myBoard.Size; i++)
                {

                    btnGrid[j, i] = new Button();

                    btnGrid[j, i].Width = buttonSize;
                    btnGrid[j, i].Height = buttonSize;

                    if (i < 2)
                    {

                        Image part = new Bitmap(50, 50);
                        var g = Graphics.FromImage(part);
                        g.DrawImage(chessGraphObject, new Rectangle(0, 0, 50, 50), 0 + 150 * (Map.map[i, j] % 10 - 1), 0, 150, 150, GraphicsUnit.Pixel);//Initializing picture that depends on values of map
                        btnGrid[j, i].BackgroundImage = part;
                    }
                    else if (i > 5)
                    {
                        Image part1 = new Bitmap(50, 50);
                        var g1 = Graphics.FromImage(part1);
                        g1.DrawImage(chessGraphObject, new Rectangle(0, 0, 50, 50), 0 + 150 * (Map.map[i, j] % 10 - 1), 150, 150, 150, GraphicsUnit.Pixel);
                        btnGrid[j, i].BackgroundImage = part1;
                    }

                    panel.Controls.Add(btnGrid[j, i]);//Add button to the panel


                    btnGrid[j, i].Location = new Point(j * buttonSize, i * buttonSize);//Set location of new button

                    btnGrid[j, i].BackColor = Color.GhostWhite;

                    if ((i % 2 != 0 || j % 2 != 0) && !(i % 2 != 0 && j % 2 != 0))
                        btnGrid[j, i].BackColor = Color.DarkCyan;
                    
                    btnGrid[j, i].Click += new EventHandler(OnFigurePress);//Click event for each button

                    btnGrid[j, i].Tag = new Point(j, i);







                }
            }
        }

        public void OnFigurePress(object sender, EventArgs e)
        {



            if (prevButton != null)
                prevButton.BackColor = Color.GhostWhite;




            var pressedButton = sender as Button;

            //get the row and column number of button clicked
            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;
            int x = location.X;
            int y = location.Y;
            Cell currentCell = myBoard.theGrid[x, y];
           
            
            DeactivateAllButtons();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Map.map[j, i] / 10 == currPlayer)
                        btnGrid[i, j].Enabled = true;

                }
            }



            if (Map.map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50] != 0 && Map.map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50] / 10 == currPlayer)
            {

                isMoving = true;



                myBoard.MarkNextLegalMoves(currentCell, Map.map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50], 1);//Determines next legal move

                DeactivateAllButtons();


                for (int j = 0; j < myBoard.Size; j++)
                {
                    for (int i = 0; i < myBoard.Size; i++)
                    {


                        btnGrid[i, j].BackColor = Color.White;
                        if ((i % 2 != 0 || j % 2 != 0) && !(i % 2 != 0 && j % 2 != 0))
                            btnGrid[i, j].BackColor = Color.DarkCyan;

                        pressedButton.BackColor = Color.Brown;

                        if (myBoard.theGrid[i, j].LegalNexMove)//What the next legal move will be that is determined in Board
                        {

                            btnGrid[i, j].Enabled = true;
                            if (Map.map[j, i] / 10 != currPlayer)
                            {
                                btnGrid[i, j].BackColor = Color.Gray;

                            }


                        }

                        if (Map.map[j, i] / 10 == currPlayer)
                        {
                            btnGrid[i, j].Enabled = true;

                        }

                    }
                }


            }
            else
            {

                if (isMoving)
                {
                    
                        int temp = Map.map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50];


                        Map.map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50] = Map.map[prevButton.Location.Y / 50, prevButton.Location.X / 50];
                        Map.map[prevButton.Location.Y / 50, prevButton.Location.X / 50] = temp;

                        pressedButton.BackgroundImage = prevButton.BackgroundImage;
                        prevButton.BackgroundImage = null;
                        if (Map.map[prevButton.Location.Y / 50, prevButton.Location.X / 50] % 10 == 1)
                        {

                            Application.Restart();

                        }
                        if (Map.map[prevButton.Location.Y / 50, prevButton.Location.X / 50] / 10 != currPlayer)
                        {
                            Map.map[prevButton.Location.Y / 50, prevButton.Location.X / 50] = 0;
                        }
                        isMoving = false;
                   
                    
                    ActivateAllButtons();

                    SwitchPlayer();
                    DeactivateAllButtons();
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (Map.map[j, i] / 10 == currPlayer)
                                btnGrid[i, j].Enabled = true;

                        }
                    }
                    CloseSteps();
                    ColorSquare();

                }


            }

            prevButton = pressedButton;





        }


        public void CloseSteps()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    btnGrid[i, j].BackColor = Color.White;
                }
            }
        }
        public void ColorSquare()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i % 2 != 0 || j % 2 != 0) && !(i % 2 != 0 && j % 2 != 0))
                        btnGrid[i, j].BackColor = Color.DarkCyan;
                }
            }
        }
        public void SwitchPlayer()
        {
            if (currPlayer == 1)
                currPlayer = 2;
            else currPlayer = 1;
        }
        public void DeactivateAllButtons()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    btnGrid[i, j].Enabled = false;

                }
            }
        }


        public void ActivateAllButtons()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    btnGrid[i, j].Enabled = true;

                }
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace GameOfChess
{
    public class Board
    {




        public bool InsideBorder(int ti, int tj)
        {
            if (ti >= 8 || tj >= 8 || ti < 0 || tj < 0)
                return false;
            return true;
        }
        public int Size { get; set; }
        public Cell[,] theGrid { get; set; }


        public Board(int s)
        {

            Size = s;

            theGrid = new Cell[Size, Size];

            for (int j = 0; j < Size; j++)
            {
                for (int i = 0; i < Size; i++)
                {
                    theGrid[i, j] = new Cell(i, j);

                }
            }

        }
        public void MarkNextLegalMoves(Cell currentCell, int btnGri, int currCase)
        {


            for (int j = 0; j < Size; j++)
            {
                for (int i = 0; i < Size; i++)
                {


                    theGrid[i, j].LegalNexMove = false;


                    switch (currCase)
                    {

                        case 1:
                            switch (btnGri % 10)
                            {//Moves for a pawn
                                case 6:
                                    if (InsideBorder(currentCell.RowNumber + 0, currentCell.ColumnNumber + 1) && Map.map[currentCell.ColumnNumber + 1, currentCell.RowNumber + 0] / 10 != 2 && btnGri / 10 == 1)
                                    {


                                        if (InsideBorder(currentCell.RowNumber + 0, currentCell.ColumnNumber + 1))
                                        {
                                            if (currentCell.ColumnNumber == 1 && Map.map[currentCell.ColumnNumber + 1, currentCell.RowNumber] / 10 == 0)
                                            {

                                                theGrid[currentCell.RowNumber + 0, currentCell.ColumnNumber + 1].LegalNexMove = true;


                                                if (currentCell.ColumnNumber == 1 && Map.map[currentCell.ColumnNumber + 2, currentCell.RowNumber] / 10 == 0)
                                                {
                                                    theGrid[currentCell.RowNumber + 0, currentCell.ColumnNumber + 2].LegalNexMove = true;
                                                }
                                            }
                                            else


                                                theGrid[currentCell.RowNumber + 0, currentCell.ColumnNumber + 1].LegalNexMove = true;


                                        }

                                    }
                                    if (InsideBorder(currentCell.RowNumber + 0, currentCell.ColumnNumber - 1) && Map.map[currentCell.ColumnNumber - 1, currentCell.RowNumber + 0] / 10 != 1 && btnGri / 10 == 2)
                                    {


                                        if (InsideBorder(currentCell.RowNumber + 0, currentCell.ColumnNumber - 1))
                                        {
                                            if (currentCell.ColumnNumber == 6 && Map.map[currentCell.ColumnNumber - 1, currentCell.RowNumber] / 10 == 0)
                                            {
                                                theGrid[currentCell.RowNumber + 0, currentCell.ColumnNumber - 1].LegalNexMove = true;
                                                if (currentCell.ColumnNumber == 6 && Map.map[currentCell.ColumnNumber - 2, currentCell.RowNumber] / 10 == 0)
                                                {
                                                    theGrid[currentCell.RowNumber + 0, currentCell.ColumnNumber - 2].LegalNexMove = true;
                                                }
                                            }
                                            else

                                                theGrid[currentCell.RowNumber + 0, currentCell.ColumnNumber - 1].LegalNexMove = true;


                                        }

                                    }

                                  
                                    if (InsideBorder(currentCell.RowNumber + 1, currentCell.ColumnNumber + 1) && Map.map[currentCell.ColumnNumber + 1, currentCell.RowNumber + 1] / 10 == 2 && btnGri / 10 == 1)
                                    {
                                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].LegalNexMove = true;
                                    }
                                    if (InsideBorder(currentCell.RowNumber - 1, currentCell.ColumnNumber + 1) && Map.map[currentCell.ColumnNumber + 1, currentCell.RowNumber - 1] / 10 == 2 && btnGri / 10 == 1)
                                    {
                                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].LegalNexMove = true;
                                    }

                                    if (InsideBorder(currentCell.RowNumber - 1, currentCell.ColumnNumber - 1) && Map.map[currentCell.ColumnNumber - 1, currentCell.RowNumber - 1] / 10 == 1 && btnGri / 10 == 2)
                                    {
                                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].LegalNexMove = true;
                                    }
                                    if (InsideBorder(currentCell.RowNumber + 1, currentCell.ColumnNumber - 1) && Map.map[currentCell.ColumnNumber - 1, currentCell.RowNumber + 1] / 10 == 1 && btnGri / 10 == 2)
                                    {
                                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].LegalNexMove = true;
                                    }
                                    break;
                                //Moves for a king
                                case 1:

                                    if (currentCell.RowNumber == 3 && currentCell.ColumnNumber == 0 && Map.map[currentCell.ColumnNumber, currentCell.RowNumber] / 10 == 1)
                                    {
                                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 0].LegalNexMove = true;
                                    }
                                    if (InsideBorder(currentCell.RowNumber + 1, currentCell.ColumnNumber + 1))
                                    {
                                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].LegalNexMove = true;

                                    }

                                    if (InsideBorder(currentCell.RowNumber + 1, currentCell.ColumnNumber - 1))
                                    {
                                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].LegalNexMove = true;

                                    }
                                    if (InsideBorder(currentCell.RowNumber - 1, currentCell.ColumnNumber + 1))
                                    {

                                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].LegalNexMove = true;
                                    }

                                    if (InsideBorder(currentCell.RowNumber - 1, currentCell.ColumnNumber - 1))
                                    {
                                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].LegalNexMove = true;
                                    }

                                    if (InsideBorder(currentCell.RowNumber + 0, currentCell.ColumnNumber + 1))
                                    {
                                        theGrid[currentCell.RowNumber + 0, currentCell.ColumnNumber + 1].LegalNexMove = true;
                                    }

                                    if (InsideBorder(currentCell.RowNumber + 1, currentCell.ColumnNumber - 0))
                                    {
                                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 0].LegalNexMove = true;
                                    }

                                    if (InsideBorder(currentCell.RowNumber - 1, currentCell.ColumnNumber + 0))
                                    {
                                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 0].LegalNexMove = true;
                                    }

                                    if (InsideBorder(currentCell.RowNumber - 0, currentCell.ColumnNumber - 1))
                                    {
                                        theGrid[currentCell.RowNumber - 0, currentCell.ColumnNumber - 1].LegalNexMove = true;
                                    }
                                    break;
                                //Moves for a queen
                                case 2:
                                    int z = currentCell.RowNumber;
                                    int v = currentCell.ColumnNumber;

                                    while (z > -1 && v < 8)
                                    {
                                        if (InsideBorder(z, v))
                                        {
                                            theGrid[z, v].LegalNexMove = true;
                                            z--;
                                            v++;
                                        }
                                        if (InsideBorder(z, v) && Map.map[v, z] != 0)
                                        {
                                            theGrid[z, v].LegalNexMove = true;

                                            break;

                                        }

                                    }
                                    z = currentCell.RowNumber;
                                    v = currentCell.ColumnNumber;
                                    while (z < 8 && v < 8)
                                    {
                                        if (InsideBorder(z, v))
                                        {
                                            theGrid[z, v].LegalNexMove = true;
                                            z++;
                                            v++;
                                        }
                                        if (InsideBorder(z, v) && Map.map[v, z] != 0)
                                        {
                                            theGrid[z, v].LegalNexMove = true;

                                            break;

                                        }

                                    }
                                    z = currentCell.RowNumber;
                                    v = currentCell.ColumnNumber;
                                    while (z < 8 && v > -1)
                                    {
                                        if (InsideBorder(z, v))
                                        {
                                            theGrid[z, v].LegalNexMove = true;
                                            z++;
                                            v--;
                                        }
                                        if (InsideBorder(z, v) && Map.map[v, z] != 0)
                                        {
                                            theGrid[z, v].LegalNexMove = true;

                                            break;

                                        }

                                    }
                                    z = currentCell.RowNumber;
                                    v = currentCell.ColumnNumber;
                                    while (z > -1 && v > -1)
                                    {
                                        if (InsideBorder(z, v))
                                        {
                                            theGrid[z, v].LegalNexMove = true;
                                            z--;
                                            v--;
                                        }
                                        if (InsideBorder(z, v) && Map.map[v, z] != 0)
                                        {
                                            theGrid[z, v].LegalNexMove = true;

                                            break;

                                        }

                                    }
                                    for (int s = currentCell.ColumnNumber + 1; s < 8; s++)
                                    {
                                        if (InsideBorder(currentCell.RowNumber, s))
                                        {
                                            theGrid[currentCell.RowNumber, s].LegalNexMove = true;
                                        }
                                        if (InsideBorder(currentCell.RowNumber, s) && Map.map[s, currentCell.RowNumber] != 0)
                                        {
                                            break;
                                        }
                                    }
                                    for (int t = currentCell.ColumnNumber - 1; t > -8; t--)
                                    {
                                        if (InsideBorder(currentCell.RowNumber, t))
                                        {
                                            theGrid[currentCell.RowNumber, t].LegalNexMove = true;
                                        }
                                        if (InsideBorder(currentCell.RowNumber, t) && Map.map[t, currentCell.RowNumber] != 0)
                                        {
                                            break;
                                        }
                                    }
                                    for (int s = currentCell.RowNumber + 1; s < 8; s++)
                                    {
                                        if (InsideBorder(s, currentCell.ColumnNumber))
                                        {
                                            theGrid[s, currentCell.ColumnNumber].LegalNexMove = true;
                                        }
                                        if (InsideBorder(s, currentCell.ColumnNumber) && Map.map[currentCell.ColumnNumber, s] != 0)
                                        {
                                            break;
                                        }
                                    }
                                    for (int t = currentCell.RowNumber - 1; t > -8; t--)
                                    {

                                        if (InsideBorder(t, currentCell.ColumnNumber))
                                        {
                                            theGrid[t, currentCell.ColumnNumber].LegalNexMove = true;
                                        }
                                        if (InsideBorder(t, currentCell.ColumnNumber) && Map.map[currentCell.ColumnNumber, t] != 0)
                                        {
                                            break;
                                        }
                                    }
                                    break;
                                //Moves for bishop
                                case 3:
                                    int m = currentCell.RowNumber;
                                    int n = currentCell.ColumnNumber;

                                    while (m > -1 && n < 8)
                                    {
                                        if (InsideBorder(m, n))
                                        {
                                            theGrid[m, n].LegalNexMove = true;
                                            m--;
                                            n++;
                                        }
                                        if (InsideBorder(m, n) && Map.map[n, m] != 0)
                                        {
                                            theGrid[m, n].LegalNexMove = true;

                                            break;

                                        }

                                    }
                                    m = currentCell.RowNumber;
                                    n = currentCell.ColumnNumber;
                                    while (m < 8 && n < 8)
                                    {
                                        if (InsideBorder(m, n))
                                        {
                                            theGrid[m, n].LegalNexMove = true;
                                            m++;
                                            n++;
                                        }
                                        if (InsideBorder(m, n) && Map.map[n, m] != 0)
                                        {
                                            theGrid[m, n].LegalNexMove = true;

                                            break;

                                        }

                                    }
                                    m = currentCell.RowNumber;
                                    n = currentCell.ColumnNumber;
                                    while (m < 8 && n > -1)
                                    {
                                        if (InsideBorder(m, n))
                                        {
                                            theGrid[m, n].LegalNexMove = true;
                                            m++;
                                            n--;
                                        }
                                        if (InsideBorder(m, n) && Map.map[n, m] != 0)
                                        {
                                            theGrid[m, n].LegalNexMove = true;

                                            break;

                                        }

                                    }
                                    m = currentCell.RowNumber;
                                    n = currentCell.ColumnNumber;
                                    while (m > -1 && n > -1)
                                    {
                                        if (InsideBorder(m, n))
                                        {
                                            theGrid[m, n].LegalNexMove = true;
                                            m--;
                                            n--;
                                        }
                                        if (InsideBorder(m, n) && Map.map[n, m] != 0)
                                        {
                                            theGrid[m, n].LegalNexMove = true;

                                            break;

                                        }

                                    }


                                    break;
                                //Moves for a knight
                                case 4:



                                    if (InsideBorder(currentCell.RowNumber + 2, currentCell.ColumnNumber + 1))
                                    {
                                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].LegalNexMove = true;

                                    }

                                    if (InsideBorder(currentCell.RowNumber + 2, currentCell.ColumnNumber - 1))
                                    {
                                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].LegalNexMove = true;

                                    }
                                    if (InsideBorder(currentCell.RowNumber - 2, currentCell.ColumnNumber + 1))
                                    {

                                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].LegalNexMove = true;
                                    }

                                    if (InsideBorder(currentCell.RowNumber - 2, currentCell.ColumnNumber - 1))
                                    {
                                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].LegalNexMove = true;
                                    }

                                    if (InsideBorder(currentCell.RowNumber + 1, currentCell.ColumnNumber + 2))
                                    {
                                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].LegalNexMove = true;
                                    }

                                    if (InsideBorder(currentCell.RowNumber + 1, currentCell.ColumnNumber - 2))
                                    {
                                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].LegalNexMove = true;
                                    }

                                    if (InsideBorder(currentCell.RowNumber - 1, currentCell.ColumnNumber + 2))
                                    {
                                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].LegalNexMove = true;
                                    }

                                    if (InsideBorder(currentCell.RowNumber - 1, currentCell.ColumnNumber - 2))
                                    {
                                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].LegalNexMove = true;
                                    }
                                    break;
                                //Moves for a rook
                                case 5:
                                    for (int s = currentCell.ColumnNumber + 1; s < 8; s++)
                                    {
                                        if (InsideBorder(currentCell.RowNumber, s))
                                        {
                                            theGrid[currentCell.RowNumber, s].LegalNexMove = true;
                                        }
                                        if (InsideBorder(currentCell.RowNumber, s) && Map.map[s, currentCell.RowNumber] != 0)
                                        {
                                            break;
                                        }
                                    }
                                    for (int t = currentCell.ColumnNumber - 1; t > -8; t--)
                                    {
                                        if (InsideBorder(currentCell.RowNumber, t))
                                        {
                                            theGrid[currentCell.RowNumber, t].LegalNexMove = true;
                                        }
                                        if (InsideBorder(currentCell.RowNumber, t) && Map.map[t, currentCell.RowNumber] != 0)
                                        {
                                            break;
                                        }
                                    }
                                    for (int s = currentCell.RowNumber + 1; s < 8; s++)
                                    {
                                        if (InsideBorder(s, currentCell.ColumnNumber))
                                        {
                                            theGrid[s, currentCell.ColumnNumber].LegalNexMove = true;
                                        }
                                        if (InsideBorder(s, currentCell.ColumnNumber) && Map.map[currentCell.ColumnNumber, s] != 0)
                                        {
                                            break;
                                        }
                                    }
                                    for (int t = currentCell.RowNumber - 1; t > -8; t--)
                                    {

                                        if (InsideBorder(t, currentCell.ColumnNumber))
                                        {
                                            theGrid[t, currentCell.ColumnNumber].LegalNexMove = true;
                                        }
                                        if (InsideBorder(t, currentCell.ColumnNumber) && Map.map[currentCell.ColumnNumber, t] != 0)
                                        {
                                            break;
                                        }
                                    }
                                    break;
                            }

                            break;







                    }
                }


            }
        }




    }


}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfChess
{
    public class Cell
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public bool LegalNexMove { get; set; }
        
        
       

        public Cell(int x, int y)
        {
            RowNumber = x;
            ColumnNumber = y;
        }
        
    }
    
}    


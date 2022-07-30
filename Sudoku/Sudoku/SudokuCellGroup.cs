using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class SudokuCellGroup
    {
        public List<SudokuCell> cells;

        public List<SudokuCell> Cells
        {
            get { return this.cells; }
        }

        public SudokuCellGroup()
        {
            cells = new List<SudokuCell>(9);
            for (int i = 0; i < 9; i++)
            {
                cells.Add(null);
            }
        }

        public bool Validate()
        {
            List<int> ints = new List<int>();
            for (int i = 0; i < cells.Count; i++)
            {
                if (cells[i] !=null)
                {
                    if (ints.Contains(cells[i].value))
                        return false;
                    else
                        ints.Add(cells[i].value);
                }
            }
            return true;
        }
    }
}

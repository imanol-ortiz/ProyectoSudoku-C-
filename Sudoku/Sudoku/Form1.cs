using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            sudokuControl1.Game = new SudokuGame();
            sudokuControl1.Game.SetValue(2, 1, 6);
            sudokuControl1.Game.SetValue(4, 1, 1);
            sudokuControl1.Game.SetValue(6, 1, 4);
            sudokuControl1.Game.SetValue(8, 1, 5);

            sudokuControl1.Game.SetValue(3, 2, 8);
            sudokuControl1.Game.SetValue(4, 2, 3);
            sudokuControl1.Game.SetValue(6, 2, 5);
            sudokuControl1.Game.SetValue(7, 2, 6);

            sudokuControl1.Game.SetValue(1, 3, 2);
            sudokuControl1.Game.SetValue(9, 3, 1);
            
            sudokuControl1.Game.SetValue(1, 4, 8);
            sudokuControl1.Game.SetValue(4, 4, 4);
            sudokuControl1.Game.SetValue(6, 4, 7);
            sudokuControl1.Game.SetValue(9, 4, 6);

            sudokuControl1.Game.SetValue(3, 5, 6);
            sudokuControl1.Game.SetValue(7, 5, 3);

            sudokuControl1.Game.SetValue(1, 6, 7);
            sudokuControl1.Game.SetValue(4, 6, 9);
            sudokuControl1.Game.SetValue(6, 6, 1);
            sudokuControl1.Game.SetValue(9, 6, 4);

            sudokuControl1.Game.SetValue(1, 7, 5);
            sudokuControl1.Game.SetValue(9, 7, 2);
            
            sudokuControl1.Game.SetValue(3, 8, 7);
            sudokuControl1.Game.SetValue(4, 8, 2);
            sudokuControl1.Game.SetValue(6, 8, 6);
            sudokuControl1.Game.SetValue(7, 8, 9);

            sudokuControl1.Game.SetValue(2, 9, 4);
            sudokuControl1.Game.SetValue(4, 9, 5);
            sudokuControl1.Game.SetValue(6, 9, 8);
            sudokuControl1.Game.SetValue(8, 9, 7);

            sudokuControl1.Invalidate(true);
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.sudokuControl1.Game != null)
            {
                bool val = this.sudokuControl1.Game.Validate();
                bool fin = true;

                if (val== false)
                {
                    MessageBox.Show("Invalid");
                }
                else
                {
                    for (int i = 0; i < 81; i++)
                    {
                        if (this.sudokuControl1.Game.Cells[i] == null) fin = false;

                    }
                    if (fin==true)
                    {
                    MessageBox.Show("Terminado");
                    }


                }


            }
        }
    }
}

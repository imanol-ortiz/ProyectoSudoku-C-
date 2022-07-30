using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace Sudoku
{
    public partial class SudokuControl : UserControl
    {
        private SudokuGame game;
        public SudokuGame Game
        {
            get { return game; }
            set
            {
                game = value;
                this.Invalidate();
            }
        
        }
        public Color SelectedColor { get; set; }
        public Color ErrorColor { get; set; }
        public Color DefaultColor { get; set; }
        public Color LineColor { get; set; }
        public Color ThickLineColor { get; set; }
        public Point SelectBox { get; set; }




        public SudokuControl()
        {
            this.game = null;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            InitializeComponent();
             
            this.SelectedColor = Color.AliceBlue;
            this.ErrorColor = Color.Red;
            this.DefaultColor = Color.Black;
            this.LineColor = Color.LightGray;
            this.ThickLineColor = Color.Black;
            this.SelectBox = new Point();
        }

        private void SudokuControl_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(this.Size.Height, this.Size.Height);
        }

        private void SudokuControl_Paint(object sender, PaintEventArgs e)
        {
            Brush br1 = new SolidBrush(this.BackColor);
            e.Graphics.FillRectangle(br1, e.ClipRectangle);
            br1.Dispose();

            float step_w1 = (this.Width - 1) / 9f;
            float step_h1 = (this.Height - 1) / 9f;

            if (this.SelectBox.X != 0 && this.SelectBox.Y != 0)
            {
                Rectangle rec = new Rectangle((int)((SelectBox.X - 1) * step_w1), (int)((SelectBox.Y - 1) * step_h1), (int)step_w1 + 1, (int)step_h1 + 1);
                e.Graphics.FillRectangle(Brushes.LightBlue, rec);
            }

            for (int i = 0; i <= 9; i++)
            {
                Pen p = new Pen(this.LineColor);

                e.Graphics.DrawLine(p, 0, (int)i * step_h1, this.Width, (int)i * step_h1);
                p.Dispose();
            }

            for (int i = 0; i <= 9; i++)
            {
                Pen p = new Pen(this.LineColor);

                e.Graphics.DrawLine(p, (int)i * step_w1, 0, (int)i * step_w1, this.Width);
                p.Dispose();
            }

            float step_w = (this.Width - 3) / 3f;
            float step_h = (this.Height - 3) / 3f;

            for (int i = 0; i <= 3; i++)
            {
                Pen p = new Pen(this.ThickLineColor, 3);
                
                e.Graphics.DrawLine(p, 0, (int)3/2f + (int)i * step_h, (int)this.Width, (int)3/2f+(int)i * step_h);
                p.Dispose();
            }

            for (int i = 0; i <= 3; i++)
            {
                Pen p = new Pen(this.ThickLineColor, 3);

                e.Graphics.DrawLine(p, (int)3 / 2f + (int)i * step_w, 0 , (int)3 / 2f + (int)i * step_w, this.Width);
                p.Dispose();
            }

            float scale = 0.5f* this.Width / 9f;

            if(this.game !=null)
            {
                for (int i = 0; i < game.Cells.Count; i++)
                {
                    SudokuCell cell = game.Cells[i];
                    if (cell!=null)
                    {

                        if (i!=1 && i != 3 && i != 5 && i != 7 && i != 11 && i != 12 && i != 14 && i != 15 && i != 18 && i != 26 && i != 27 && i !=30 && i !=32 && i !=35 && i !=38 && i !=42 && i !=45 && i !=48 && i !=50 && i !=53 && i !=54 && i !=62 && i !=65 && i !=66 && i !=68 && i !=69 && i !=73 && i !=75 && i !=77 && i !=79)
                        {
                            //el if largo es para escluir las celdas que quiero que no se toquen y figuren en otro color
                            int vl = cell.value;


                            Font ff = new System.Drawing.Font(this.Font.FontFamily, scale, this.Font.Style);

                            SizeF sz = e.Graphics.MeasureString(vl.ToString(), ff);

                            int px = (int)((cell.Column - 1) * step_w1 + step_w1 / 2f - sz.Width / 2f);
                            int py = (int)((cell.Row - 1) * step_h1 + step_h1 / 2f - sz.Height / 2f);

                            Point ppp = new Point(px, py + 3);//+3 para que este mas centrado
                            Brush br7 = new SolidBrush(Color.Black);


                            e.Graphics.DrawString(vl.ToString(), ff, br7, ppp);
                            br7.Dispose();
                        }
                        else
                        {
                            int vl = cell.value;


                            Font ff = new System.Drawing.Font(this.Font.FontFamily, scale, this.Font.Style);

                            SizeF sz = e.Graphics.MeasureString(vl.ToString(), ff);

                            int px = (int)((cell.Column - 1) * step_w1 + step_w1 / 2f - sz.Width / 2f);
                            int py = (int)((cell.Row - 1) * step_h1 + step_h1 / 2f - sz.Height / 2f);

                            Point ppp = new Point(px, py + 3);//+3 para que este mas centrado
                            Brush br7 = new SolidBrush(Color.DarkBlue);


                            e.Graphics.DrawString(vl.ToString(), ff, br7, ppp);
                            br7.Dispose();
                        }
                    }



                }
            }


        }

        private void SudokuControl_MouseClick(object sender, MouseEventArgs e)
        {
            float step_w = this.Width / 9;
            float step_h = this.Height / 9;

            int row = (int)(e.Y / step_h) + 1;
            int col = (int)(e.X / step_w) + 1;
            this.SelectBox = new Point(col, row);
            int i = game.GetCellIndexFromPosition(col, row); //obtendo el numero de las celdas que no se pueden tocar
            if (i != 1 && i != 3 && i != 5 && i != 7 && i != 11 && i != 12 && i != 14 && i != 15 && i != 18 && i != 26 && i != 27 && i != 30 && i != 32 && i != 35 && i != 38 && i != 42 && i != 45 && i != 48 && i != 50 && i != 53 && i != 54 && i != 62 && i != 65 && i != 66 && i != 68 && i != 69 && i != 73 && i != 75 && i != 77 && i != 79)
            {
                //el if largo es para escluir las celdas que no se pueden tocar
                this.Invalidate();
                this.ParentForm.Text = "(" + col.ToString() + "," + row.ToString() + ")";
            }
            

        }

        private void SudokuControl_KeyDown(object sender, KeyEventArgs e)
        {
            int num = 0;
            if (this.SelectBox.X != 0 && this.SelectBox.Y != 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.D1:
                        num = 1;
                        break;
                    case Keys.D2:
                        num = 2;
                        break;
                    case Keys.D3:
                        num = 3;
                        break;
                    case Keys.D4:
                        num = 4;
                        break;
                    case Keys.D5:
                        num = 5;
                        break;
                    case Keys.D6:
                        num = 6;
                        break;
                    case Keys.D7:
                        num = 7;
                        break;
                    case Keys.D8:
                        num = 8;
                        break;
                    case Keys.D9:
                        num = 9;
                        break;
                    case Keys.D0:
                        num = 0;
                        break;
                }
                if (game!=null && num > 0 && SelectBox.X > 0 && SelectBox.Y >0)
                {
                    game.SetValue(SelectBox.X, SelectBox.Y, num);
                    this.Invalidate(true);

                }
            }
            //this.ParentForm.Text = num.ToString();
        }
    }
}
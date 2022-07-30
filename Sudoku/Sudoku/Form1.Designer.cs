namespace Sudoku
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sudokuControl1 = new Sudoku.SudokuControl();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sudokuControl1
            // 
            this.sudokuControl1.DefaultColor = System.Drawing.Color.LightGray;
            this.sudokuControl1.ErrorColor = System.Drawing.Color.Red;
            this.sudokuControl1.Game = null;
            this.sudokuControl1.LineColor = System.Drawing.Color.LightGray;
            this.sudokuControl1.Location = new System.Drawing.Point(12, 12);
            this.sudokuControl1.Name = "sudokuControl1";
            this.sudokuControl1.SelectBox = new System.Drawing.Point(0, 0);
            this.sudokuControl1.SelectedColor = System.Drawing.Color.AliceBlue;
            this.sudokuControl1.Size = new System.Drawing.Size(482, 482);
            this.sudokuControl1.TabIndex = 0;
            this.sudokuControl1.ThickLineColor = System.Drawing.Color.Black;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(181, 513);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 59);
            this.button1.TabIndex = 1;
            this.button1.Text = "Validate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 607);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sudokuControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SudokuControl sudokuControl1;
        private System.Windows.Forms.Button button1;
    }
}


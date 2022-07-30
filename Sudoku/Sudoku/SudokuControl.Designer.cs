namespace Sudoku
{
    partial class SudokuControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SudokuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "SudokuControl";
            this.Size = new System.Drawing.Size(548, 523);
            this.SizeChanged += new System.EventHandler(this.SudokuControl_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SudokuControl_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SudokuControl_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SudokuControl_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

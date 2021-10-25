
namespace MazeGenerator
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
            this.mazeRenderer21 = new MazeGenerator.MazeRenderer2();
            this.SuspendLayout();
            // 
            // mazeRenderer21
            // 
            this.mazeRenderer21.Location = new System.Drawing.Point(14, 6);
            this.mazeRenderer21.Name = "mazeRenderer21";
            this.mazeRenderer21.Size = new System.Drawing.Size(337, 282);
            this.mazeRenderer21.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 313);
            this.Controls.Add(this.mazeRenderer21);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private MazeRenderer2 mazeRenderer21;
    }
}


using OpenTK;

namespace RayTracingApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            glControl1 = new GLControl();
            SuspendLayout();
            // 
            // glControl1
            // 
            glControl1.BackColor = Color.Black;
            glControl1.Location = new Point(12, 12);
            glControl1.Margin = new Padding(4, 3, 4, 3);
            glControl1.Name = "glControl1";
            glControl1.Size = new Size(775, 426);
            glControl1.TabIndex = 1;
            glControl1.VSync = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(glControl1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private GLControl glControl1;
    }
}

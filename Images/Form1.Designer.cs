namespace Images
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
            Image1 = new PictureBox();
            UploadButton = new Button();
            SaveButton = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)Image1).BeginInit();
            SuspendLayout();
            // 
            // Image1
            // 
            Image1.Location = new Point(12, 134);
            Image1.Name = "Image1";
            Image1.Size = new Size(358, 257);
            Image1.SizeMode = PictureBoxSizeMode.Zoom;
            Image1.TabIndex = 0;
            Image1.TabStop = false;
            // 
            // UploadButton
            // 
            UploadButton.Location = new Point(404, 70);
            UploadButton.Name = "UploadButton";
            UploadButton.Size = new Size(358, 50);
            UploadButton.TabIndex = 1;
            UploadButton.Text = "Upload";
            UploadButton.UseVisualStyleBackColor = true;
            UploadButton.Click += UploadButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(437, 134);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(127, 48);
            SaveButton.TabIndex = 2;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(362, 394);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 82);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(350, 27);
            textBox1.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 611);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(SaveButton);
            Controls.Add(UploadButton);
            Controls.Add(Image1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)Image1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Image1;
        private Button UploadButton;
        private Button SaveButton;
        private Label label1;
        private TextBox textBox1;
    }
}
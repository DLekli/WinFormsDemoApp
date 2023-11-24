namespace BetterWinFormsDemo
{
    partial class MainForm
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
            firstNameLabel = new Label();
            firstNameText = new TextBox();
            sayHelloButton = new Button();
            lastNameText = new TextBox();
            lastNameLabel = new Label();
            SuspendLayout();
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new Point(153, 55);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(80, 20);
            firstNameLabel.TabIndex = 0;
            firstNameLabel.Text = "First Name";
            // 
            // firstNameText
            // 
            firstNameText.Location = new Point(268, 52);
            firstNameText.Name = "firstNameText";
            firstNameText.Size = new Size(211, 27);
            firstNameText.TabIndex = 1;
            // 
            // sayHelloButton
            // 
            sayHelloButton.Location = new Point(183, 258);
            sayHelloButton.Name = "sayHelloButton";
            sayHelloButton.Size = new Size(197, 65);
            sayHelloButton.TabIndex = 3;
            sayHelloButton.Text = "Say Hello";
            sayHelloButton.UseVisualStyleBackColor = true;
            sayHelloButton.Click += sayHelloButton_Click;
            // 
            // lastNameText
            // 
            lastNameText.Location = new Point(268, 112);
            lastNameText.Name = "lastNameText";
            lastNameText.Size = new Size(211, 27);
            lastNameText.TabIndex = 2;
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new Point(153, 115);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(79, 20);
            lastNameLabel.TabIndex = 3;
            lastNameLabel.Text = "Last Name";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(598, 396);
            Controls.Add(lastNameText);
            Controls.Add(lastNameLabel);
            Controls.Add(sayHelloButton);
            Controls.Add(firstNameText);
            Controls.Add(firstNameLabel);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label firstNameLabel;
        private TextBox firstNameText;
        private Button sayHelloButton;
        private TextBox lastNameText;
        private Label lastNameLabel;
    }
}
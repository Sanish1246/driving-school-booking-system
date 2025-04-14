namespace MainFormProject
{
    partial class BookCar
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
            submitButton = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            firstNames = new ListBox();
            backButton = new Button();
            exitButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // submitButton
            // 
            submitButton.Font = new Font("Segoe UI", 12F);
            submitButton.Location = new Point(507, 395);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(103, 35);
            submitButton.TabIndex = 56;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.Location = new Point(320, 396);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(181, 34);
            textBox1.TabIndex = 55;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(165, 398);
            label2.Name = "label2";
            label2.Size = new Size(149, 28);
            label2.TabIndex = 54;
            label2.Text = "Registration No";
            // 
            // firstNames
            // 
            firstNames.BackColor = SystemColors.ActiveCaption;
            firstNames.FormattingEnabled = true;
            firstNames.Location = new Point(11, 87);
            firstNames.Name = "firstNames";
            firstNames.Size = new Size(776, 284);
            firstNames.TabIndex = 53;
            // 
            // backButton
            // 
            backButton.Font = new Font("Segoe UI", 10F);
            backButton.Location = new Point(11, 24);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 52;
            backButton.Text = "< Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // exitButton
            // 
            exitButton.Font = new Font("Segoe UI", 10F);
            exitButton.ForeColor = Color.Red;
            exitButton.Location = new Point(693, 24);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(94, 29);
            exitButton.TabIndex = 51;
            exitButton.Text = " Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(311, 9);
            label1.Name = "label1";
            label1.Size = new Size(190, 46);
            label1.TabIndex = 50;
            label1.Text = "Select a car";
            // 
            // BookCar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(submitButton);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(firstNames);
            Controls.Add(backButton);
            Controls.Add(exitButton);
            Controls.Add(label1);
            Name = "BookCar";
            Text = "Book Car";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button submitButton;
        private TextBox textBox1;
        private Label label2;
        private ListBox firstNames;
        private Button backButton;
        private Button exitButton;
        private Label label1;
    }
}
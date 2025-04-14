namespace MainFormProject
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
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            exitButton = new Button();
            skipButton = new Button();
            comboBox1 = new ComboBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(52, 34);
            label1.Name = "label1";
            label1.Size = new Size(695, 46);
            label1.TabIndex = 0;
            label1.Text = "Welcome to driving lesson boking system!";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(185, 196);
            label2.Name = "label2";
            label2.Size = new Size(87, 28);
            label2.TabIndex = 1;
            label2.Text = "File path";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 15F);
            textBox1.Location = new Point(278, 188);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(234, 41);
            textBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F);
            button1.Location = new Point(264, 274);
            button1.Name = "button1";
            button1.Size = new Size(134, 54);
            button1.TabIndex = 3;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // exitButton
            // 
            exitButton.Font = new Font("Segoe UI", 10F);
            exitButton.ForeColor = Color.Red;
            exitButton.Location = new Point(694, 12);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(94, 29);
            exitButton.TabIndex = 32;
            exitButton.Text = " Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // skipButton
            // 
            skipButton.Font = new Font("Segoe UI", 12F);
            skipButton.Location = new Point(404, 274);
            skipButton.Name = "skipButton";
            skipButton.Size = new Size(134, 54);
            skipButton.TabIndex = 33;
            skipButton.Text = "Skip";
            skipButton.UseVisualStyleBackColor = true;
            skipButton.Click += skipButton_Click;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 12F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Lesson", "Student", "Instructor", "Car" });
            comboBox1.Location = new Point(320, 114);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 36);
            comboBox1.TabIndex = 34;
            comboBox1.Text = "Lesson";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(162, 117);
            label3.Name = "label3";
            label3.Size = new Size(152, 28);
            label3.TabIndex = 35;
            label3.Text = "Table to update:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(skipButton);
            Controls.Add(exitButton);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Driving lesson booking system";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Button button1;
        private Button exitButton;
        private Button skipButton;
        private ComboBox comboBox1;
        private Label label3;
    }
}

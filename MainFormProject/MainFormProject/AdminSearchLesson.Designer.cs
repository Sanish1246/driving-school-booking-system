namespace MainFormProject
{
    partial class AdminSearchLesson
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
            firstNames = new ListBox();
            backButton = new Button();
            exitButton = new Button();
            label1 = new Label();
            submitButton = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // firstNames
            // 
            firstNames.BackColor = SystemColors.ActiveCaption;
            firstNames.FormattingEnabled = true;
            firstNames.Location = new Point(12, 154);
            firstNames.Name = "firstNames";
            firstNames.Size = new Size(776, 284);
            firstNames.TabIndex = 46;
            // 
            // backButton
            // 
            backButton.Font = new Font("Segoe UI", 10F);
            backButton.Location = new Point(13, 24);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 45;
            backButton.Text = "< Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // exitButton
            // 
            exitButton.Font = new Font("Segoe UI", 10F);
            exitButton.ForeColor = Color.Red;
            exitButton.Location = new Point(695, 24);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(94, 29);
            exitButton.TabIndex = 44;
            exitButton.Text = " Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(206, 9);
            label1.Name = "label1";
            label1.Size = new Size(383, 46);
            label1.TabIndex = 43;
            label1.Text = "Input the Date to search";
            // 
            // submitButton
            // 
            submitButton.Font = new Font("Segoe UI", 12F);
            submitButton.Location = new Point(486, 85);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(103, 35);
            submitButton.TabIndex = 52;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.Location = new Point(299, 86);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(181, 34);
            textBox1.TabIndex = 51;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(177, 89);
            label2.Name = "label2";
            label2.Size = new Size(116, 28);
            label2.TabIndex = 50;
            label2.Text = "Lesson Date";
            // 
            // AdminSearchLesson
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
            Name = "AdminSearchLesson";
            Text = "Search Lesson";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox firstNames;
        private Button backButton;
        private Button exitButton;
        private Label label1;
        private Button submitButton;
        private TextBox textBox1;
        private Label label2;
    }
}
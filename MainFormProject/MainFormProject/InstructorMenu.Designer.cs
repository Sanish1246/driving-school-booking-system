namespace MainFormProject
{
    partial class InstructorMenu
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
            exitButton = new Button();
            studentLessonsButton = new Button();
            label1 = new Label();
            backButton = new Button();
            SuspendLayout();
            // 
            // exitButton
            // 
            exitButton.Font = new Font("Segoe UI", 10F);
            exitButton.ForeColor = Color.Red;
            exitButton.Location = new Point(704, 13);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(94, 29);
            exitButton.TabIndex = 24;
            exitButton.Text = " Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // studentLessonsButton
            // 
            studentLessonsButton.Font = new Font("Segoe UI", 13F);
            studentLessonsButton.Location = new Point(302, 182);
            studentLessonsButton.Name = "studentLessonsButton";
            studentLessonsButton.Size = new Size(207, 74);
            studentLessonsButton.TabIndex = 22;
            studentLessonsButton.Text = "View your lessons";
            studentLessonsButton.UseVisualStyleBackColor = true;
            studentLessonsButton.Click += studentLessonsButton_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(144, 38);
            label1.Name = "label1";
            label1.Size = new Size(524, 48);
            label1.TabIndex = 21;
            label1.Text = "Choose an option";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // backButton
            // 
            backButton.Font = new Font("Segoe UI", 10F);
            backButton.Location = new Point(12, 13);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 32;
            backButton.Text = "< Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // InstructorMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(backButton);
            Controls.Add(exitButton);
            Controls.Add(studentLessonsButton);
            Controls.Add(label1);
            Name = "InstructorMenu";
            Text = "Instructor Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button exitButton;
        private Button studentLessonsButton;
        private Label label1;
        private Button backButton;
    }
}
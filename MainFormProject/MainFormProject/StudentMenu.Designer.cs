namespace MainFormProject
{
    partial class StudentMenu
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
            bookLessonButton = new Button();
            studentLessonsButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // exitButton
            // 
            exitButton.Font = new Font("Segoe UI", 10F);
            exitButton.ForeColor = Color.Red;
            exitButton.Location = new Point(696, 8);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(94, 29);
            exitButton.TabIndex = 20;
            exitButton.Text = " Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // bookLessonButton
            // 
            bookLessonButton.Font = new Font("Segoe UI", 13F);
            bookLessonButton.Location = new Point(289, 219);
            bookLessonButton.Name = "bookLessonButton";
            bookLessonButton.Size = new Size(207, 74);
            bookLessonButton.TabIndex = 18;
            bookLessonButton.Text = "Book a lesson";
            bookLessonButton.UseVisualStyleBackColor = true;
            bookLessonButton.Click += bookLessonButton_Click;
            // 
            // studentLessonsButton
            // 
            studentLessonsButton.Font = new Font("Segoe UI", 13F);
            studentLessonsButton.Location = new Point(289, 139);
            studentLessonsButton.Name = "studentLessonsButton";
            studentLessonsButton.Size = new Size(207, 74);
            studentLessonsButton.TabIndex = 17;
            studentLessonsButton.Text = "View your lessons";
            studentLessonsButton.UseVisualStyleBackColor = true;
            studentLessonsButton.Click += studentLessonsButton_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(136, 33);
            label1.Name = "label1";
            label1.Size = new Size(524, 48);
            label1.TabIndex = 16;
            label1.Text = "Choose an option";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StudentMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(exitButton);
            Controls.Add(bookLessonButton);
            Controls.Add(studentLessonsButton);
            Controls.Add(label1);
            Name = "StudentMenu";
            Text = "Student Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button exitButton;
        private Button bookLessonButton;
        private Button studentLessonsButton;
        private Label label1;
    }
}
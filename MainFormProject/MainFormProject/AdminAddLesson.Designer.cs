namespace MainFormProject
{
    partial class AdminAddLesson
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
            backButton = new Button();
            exitButton = new Button();
            RegNo = new TextBox();
            label5 = new Label();
            label4 = new Label();
            InstructorEmail = new TextBox();
            label3 = new Label();
            StudentEmail = new TextBox();
            label2 = new Label();
            label1 = new Label();
            invalidStudent = new Label();
            invalidInstructor = new Label();
            LessonDate = new DateTimePicker();
            invalidRegNo = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // submitButton
            // 
            submitButton.Font = new Font("Segoe UI", 12F);
            submitButton.Location = new Point(336, 320);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(102, 39);
            submitButton.TabIndex = 41;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // backButton
            // 
            backButton.Font = new Font("Segoe UI", 10F);
            backButton.Location = new Point(12, 9);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 40;
            backButton.Text = "< Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // exitButton
            // 
            exitButton.Font = new Font("Segoe UI", 10F);
            exitButton.ForeColor = Color.Red;
            exitButton.Location = new Point(694, 9);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(94, 29);
            exitButton.TabIndex = 39;
            exitButton.Text = " Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // RegNo
            // 
            RegNo.Font = new Font("Segoe UI", 12F);
            RegNo.Location = new Point(563, 220);
            RegNo.Name = "RegNo";
            RegNo.Size = new Size(169, 34);
            RegNo.TabIndex = 32;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(404, 223);
            label5.Name = "label5";
            label5.Size = new Size(153, 28);
            label5.TabIndex = 31;
            label5.Text = "Registration No.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(71, 226);
            label4.Name = "label4";
            label4.Size = new Size(53, 28);
            label4.TabIndex = 29;
            label4.Text = "Date";
            // 
            // InstructorEmail
            // 
            InstructorEmail.Font = new Font("Segoe UI", 12F);
            InstructorEmail.Location = new Point(563, 150);
            InstructorEmail.Name = "InstructorEmail";
            InstructorEmail.Size = new Size(169, 34);
            InstructorEmail.TabIndex = 28;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(409, 153);
            label3.Name = "label3";
            label3.Size = new Size(148, 28);
            label3.TabIndex = 27;
            label3.Text = "Instructor email";
            // 
            // StudentEmail
            // 
            StudentEmail.Font = new Font("Segoe UI", 12F);
            StudentEmail.Location = new Point(192, 153);
            StudentEmail.Name = "StudentEmail";
            StudentEmail.Size = new Size(169, 34);
            StudentEmail.TabIndex = 26;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(54, 153);
            label2.Name = "label2";
            label2.Size = new Size(132, 28);
            label2.TabIndex = 25;
            label2.Text = "Student email";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(206, 9);
            label1.Name = "label1";
            label1.Size = new Size(380, 46);
            label1.TabIndex = 24;
            label1.Text = "Input the following data";
            // 
            // invalidStudent
            // 
            invalidStudent.AutoSize = true;
            invalidStudent.ForeColor = Color.Red;
            invalidStudent.Location = new Point(163, 190);
            invalidStudent.Name = "invalidStudent";
            invalidStudent.Size = new Size(217, 20);
            invalidStudent.TabIndex = 43;
            invalidStudent.Text = "Student email cannot be empty";
            invalidStudent.Visible = false;
            // 
            // invalidInstructor
            // 
            invalidInstructor.AutoSize = true;
            invalidInstructor.ForeColor = Color.Red;
            invalidInstructor.Location = new Point(534, 187);
            invalidInstructor.Name = "invalidInstructor";
            invalidInstructor.Size = new Size(228, 20);
            invalidInstructor.TabIndex = 44;
            invalidInstructor.Text = "Instructor email cannot be empty";
            invalidInstructor.Visible = false;
            // 
            // LessonDate
            // 
            LessonDate.Location = new Point(130, 228);
            LessonDate.Name = "LessonDate";
            LessonDate.Size = new Size(250, 27);
            LessonDate.TabIndex = 55;
            // 
            // invalidRegNo
            // 
            invalidRegNo.AutoSize = true;
            invalidRegNo.ForeColor = Color.Red;
            invalidRegNo.Location = new Point(517, 257);
            invalidRegNo.Name = "invalidRegNo";
            invalidRegNo.Size = new Size(260, 20);
            invalidRegNo.TabIndex = 56;
            invalidRegNo.Text = "Registration number cannot be empty";
            invalidRegNo.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(130, 379);
            label6.Name = "label6";
            label6.Size = new Size(528, 28);
            label6.TabIndex = 57;
            label6.Text = "Car registration number should be in the format (AB99CDE)";
            // 
            // AdminAddLesson
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(invalidRegNo);
            Controls.Add(LessonDate);
            Controls.Add(invalidInstructor);
            Controls.Add(invalidStudent);
            Controls.Add(submitButton);
            Controls.Add(backButton);
            Controls.Add(exitButton);
            Controls.Add(RegNo);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(InstructorEmail);
            Controls.Add(label3);
            Controls.Add(StudentEmail);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AdminAddLesson";
            Text = "Add Lesson";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button submitButton;
        private Button backButton;
        private Button exitButton;
        private TextBox RegNo;
        private Label label5;
        private Label label4;
        private TextBox InstructorEmail;
        private Label label3;
        private TextBox StudentEmail;
        private Label label2;
        private Label label1;
        private Label invalidStudent;
        private Label invalidInstructor;
        private DateTimePicker LessonDate;
        private Label invalidRegNo;
        private Label label6;
    }
}
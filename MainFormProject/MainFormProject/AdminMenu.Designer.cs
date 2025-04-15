namespace MainFormProject
{
    partial class AdminMenu
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
            label1 = new Label();
            handleStudentsButton = new Button();
            handleInstructorsButton = new Button();
            handleCarsButton = new Button();
            button4 = new Button();
            handleLessonButton = new Button();
            backButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(134, 37);
            label1.Name = "label1";
            label1.Size = new Size(524, 48);
            label1.TabIndex = 10;
            label1.Text = "Choose an option";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // handleStudentsButton
            // 
            handleStudentsButton.Font = new Font("Segoe UI", 13F);
            handleStudentsButton.Location = new Point(286, 100);
            handleStudentsButton.Name = "handleStudentsButton";
            handleStudentsButton.Size = new Size(207, 74);
            handleStudentsButton.TabIndex = 11;
            handleStudentsButton.Text = "Handle students";
            handleStudentsButton.UseVisualStyleBackColor = true;
            handleStudentsButton.Click += handleStudentsButton_Click;
            // 
            // handleInstructorsButton
            // 
            handleInstructorsButton.Font = new Font("Segoe UI", 13F);
            handleInstructorsButton.Location = new Point(286, 180);
            handleInstructorsButton.Name = "handleInstructorsButton";
            handleInstructorsButton.Size = new Size(207, 74);
            handleInstructorsButton.TabIndex = 12;
            handleInstructorsButton.Text = "Handle instructors";
            handleInstructorsButton.UseVisualStyleBackColor = true;
            handleInstructorsButton.Click += handleInstructorsButton_Click;
            // 
            // handleCarsButton
            // 
            handleCarsButton.Font = new Font("Segoe UI", 13F);
            handleCarsButton.Location = new Point(286, 260);
            handleCarsButton.Name = "handleCarsButton";
            handleCarsButton.Size = new Size(207, 74);
            handleCarsButton.TabIndex = 13;
            handleCarsButton.Text = "Handle cars";
            handleCarsButton.UseVisualStyleBackColor = true;
            handleCarsButton.Click += handleCarsButton_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 10F);
            button4.ForeColor = Color.Red;
            button4.Location = new Point(694, 12);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 14;
            button4.Text = " Exit";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // handleLessonButton
            // 
            handleLessonButton.Font = new Font("Segoe UI", 13F);
            handleLessonButton.Location = new Point(286, 340);
            handleLessonButton.Name = "handleLessonButton";
            handleLessonButton.Size = new Size(207, 74);
            handleLessonButton.TabIndex = 15;
            handleLessonButton.Text = "Handle Lessons";
            handleLessonButton.UseVisualStyleBackColor = true;
            handleLessonButton.Click += handleLessonButton_Click;
            // 
            // backButton
            // 
            backButton.Font = new Font("Segoe UI", 10F);
            backButton.Location = new Point(12, 12);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 31;
            backButton.Text = "< Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // AdminMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(backButton);
            Controls.Add(handleLessonButton);
            Controls.Add(button4);
            Controls.Add(handleCarsButton);
            Controls.Add(handleInstructorsButton);
            Controls.Add(handleStudentsButton);
            Controls.Add(label1);
            Name = "AdminMenu";
            Text = "Admin Menu";
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button handleStudentsButton;
        private Button handleInstructorsButton;
        private Button handleCarsButton;
        private Button button4;
        private Button handleLessonButton;
        private Button backButton;
    }
}
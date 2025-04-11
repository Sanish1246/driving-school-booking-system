namespace MainFormProject
{
    partial class InstructorHandler
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
            backButton = new Button();
            exitButton = new Button();
            listStudentButton = new Button();
            searchStudentButton = new Button();
            updateStudentButton = new Button();
            deleteStudentButton = new Button();
            addStudentButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // backButton
            // 
            backButton.Font = new Font("Segoe UI", 10F);
            backButton.Location = new Point(12, 12);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 29;
            backButton.Text = "< Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // exitButton
            // 
            exitButton.Font = new Font("Segoe UI", 10F);
            exitButton.ForeColor = Color.Red;
            exitButton.Location = new Point(694, 12);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(94, 29);
            exitButton.TabIndex = 28;
            exitButton.Text = " Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // listStudentButton
            // 
            listStudentButton.Font = new Font("Segoe UI", 13F);
            listStudentButton.Location = new Point(272, 348);
            listStudentButton.Name = "listStudentButton";
            listStudentButton.Size = new Size(260, 56);
            listStudentButton.TabIndex = 27;
            listStudentButton.Text = "List all instructors";
            listStudentButton.UseVisualStyleBackColor = true;
            // 
            // searchStudentButton
            // 
            searchStudentButton.Font = new Font("Segoe UI", 13F);
            searchStudentButton.Location = new Point(272, 286);
            searchStudentButton.Name = "searchStudentButton";
            searchStudentButton.Size = new Size(260, 56);
            searchStudentButton.TabIndex = 26;
            searchStudentButton.Text = "Search for an instructor";
            searchStudentButton.UseVisualStyleBackColor = true;
            // 
            // updateStudentButton
            // 
            updateStudentButton.Font = new Font("Segoe UI", 13F);
            updateStudentButton.Location = new Point(272, 216);
            updateStudentButton.Name = "updateStudentButton";
            updateStudentButton.Size = new Size(260, 64);
            updateStudentButton.TabIndex = 25;
            updateStudentButton.Text = "Update instructor details";
            updateStudentButton.UseVisualStyleBackColor = true;
            // 
            // deleteStudentButton
            // 
            deleteStudentButton.Font = new Font("Segoe UI", 13F);
            deleteStudentButton.Location = new Point(272, 144);
            deleteStudentButton.Name = "deleteStudentButton";
            deleteStudentButton.Size = new Size(260, 64);
            deleteStudentButton.TabIndex = 24;
            deleteStudentButton.Text = "Delete instructor";
            deleteStudentButton.UseVisualStyleBackColor = true;
            // 
            // addStudentButton
            // 
            addStudentButton.Font = new Font("Segoe UI", 13F);
            addStudentButton.Location = new Point(272, 79);
            addStudentButton.Name = "addStudentButton";
            addStudentButton.Size = new Size(260, 59);
            addStudentButton.TabIndex = 23;
            addStudentButton.Text = "Add instructor";
            addStudentButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(140, 9);
            label1.Name = "label1";
            label1.Size = new Size(524, 48);
            label1.TabIndex = 22;
            label1.Text = "Choose an option";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // InstructorHandler
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(backButton);
            Controls.Add(exitButton);
            Controls.Add(listStudentButton);
            Controls.Add(searchStudentButton);
            Controls.Add(updateStudentButton);
            Controls.Add(deleteStudentButton);
            Controls.Add(addStudentButton);
            Controls.Add(label1);
            Name = "InstructorHandler";
            Text = "Instructor Handler";
            ResumeLayout(false);
        }

        #endregion

        private Button backButton;
        private Button exitButton;
        private Button listStudentButton;
        private Button searchStudentButton;
        private Button updateStudentButton;
        private Button deleteStudentButton;
        private Button addStudentButton;
        private Label label1;
    }
}
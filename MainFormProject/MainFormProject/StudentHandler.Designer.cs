namespace MainFormProject
{
    partial class StudentHandler
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
            updateStudentButton = new Button();
            deleteStudentButton = new Button();
            addStudentButton = new Button();
            label1 = new Label();
            searchStudentButton = new Button();
            listStudentButton = new Button();
            exitButton = new Button();
            backButton = new Button();
            SuspendLayout();
            // 
            // updateStudentButton
            // 
            updateStudentButton.Font = new Font("Segoe UI", 13F);
            updateStudentButton.Location = new Point(290, 214);
            updateStudentButton.Name = "updateStudentButton";
            updateStudentButton.Size = new Size(248, 56);
            updateStudentButton.TabIndex = 17;
            updateStudentButton.Text = "Update student details";
            updateStudentButton.UseVisualStyleBackColor = true;
            updateStudentButton.Click += updateStudentButton_Click;
            // 
            // deleteStudentButton
            // 
            deleteStudentButton.Font = new Font("Segoe UI", 13F);
            deleteStudentButton.Location = new Point(290, 144);
            deleteStudentButton.Name = "deleteStudentButton";
            deleteStudentButton.Size = new Size(248, 64);
            deleteStudentButton.TabIndex = 16;
            deleteStudentButton.Text = "Delete student";
            deleteStudentButton.UseVisualStyleBackColor = true;
            deleteStudentButton.Click += deleteStudentButton_Click;
            // 
            // addStudentButton
            // 
            addStudentButton.Font = new Font("Segoe UI", 13F);
            addStudentButton.Location = new Point(290, 79);
            addStudentButton.Name = "addStudentButton";
            addStudentButton.Size = new Size(248, 59);
            addStudentButton.TabIndex = 15;
            addStudentButton.Text = "Add student";
            addStudentButton.UseVisualStyleBackColor = true;
            addStudentButton.Click += addStudentButton_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(153, 9);
            label1.Name = "label1";
            label1.Size = new Size(524, 48);
            label1.TabIndex = 14;
            label1.Text = "Choose an option";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // searchStudentButton
            // 
            searchStudentButton.Font = new Font("Segoe UI", 13F);
            searchStudentButton.Location = new Point(290, 276);
            searchStudentButton.Name = "searchStudentButton";
            searchStudentButton.Size = new Size(248, 56);
            searchStudentButton.TabIndex = 18;
            searchStudentButton.Text = "Search for a student";
            searchStudentButton.UseVisualStyleBackColor = true;
            searchStudentButton.Click += searchStudentButton_Click;
            // 
            // listStudentButton
            // 
            listStudentButton.Font = new Font("Segoe UI", 13F);
            listStudentButton.Location = new Point(290, 338);
            listStudentButton.Name = "listStudentButton";
            listStudentButton.Size = new Size(248, 56);
            listStudentButton.TabIndex = 19;
            listStudentButton.Text = "List all students";
            listStudentButton.UseVisualStyleBackColor = true;
            listStudentButton.Click += listStudentButton_Click;
            // 
            // exitButton
            // 
            exitButton.Font = new Font("Segoe UI", 10F);
            exitButton.ForeColor = Color.Red;
            exitButton.Location = new Point(694, 12);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(94, 29);
            exitButton.TabIndex = 20;
            exitButton.Text = " Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // backButton
            // 
            backButton.Font = new Font("Segoe UI", 10F);
            backButton.Location = new Point(12, 12);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 21;
            backButton.Text = "< Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // StudentHandler
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
            Name = "StudentHandler";
            Text = "Student Handler";
            ResumeLayout(false);
        }

        #endregion

        private Button updateStudentButton;
        private Button deleteStudentButton;
        private Button addStudentButton;
        private Label label1;
        private Button searchStudentButton;
        private Button listStudentButton;
        private Button exitButton;
        private Button backButton;
    }
}
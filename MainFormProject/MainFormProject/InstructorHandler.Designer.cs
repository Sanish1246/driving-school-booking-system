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
            listInstructorButton = new Button();
            searchInstructorButton = new Button();
            updateInstructorButton = new Button();
            deleteInstructorButton = new Button();
            addInstructorButton = new Button();
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
            // listInstructorButton
            // 
            listInstructorButton.Font = new Font("Segoe UI", 13F);
            listInstructorButton.Location = new Point(272, 348);
            listInstructorButton.Name = "listInstructorButton";
            listInstructorButton.Size = new Size(260, 56);
            listInstructorButton.TabIndex = 27;
            listInstructorButton.Text = "List all instructors";
            listInstructorButton.UseVisualStyleBackColor = true;
            // 
            // searchInstructorButton
            // 
            searchInstructorButton.Font = new Font("Segoe UI", 13F);
            searchInstructorButton.Location = new Point(272, 286);
            searchInstructorButton.Name = "searchInstructorButton";
            searchInstructorButton.Size = new Size(260, 56);
            searchInstructorButton.TabIndex = 26;
            searchInstructorButton.Text = "Search for an instructor";
            searchInstructorButton.UseVisualStyleBackColor = true;
            // 
            // updateInstructorButton
            // 
            updateInstructorButton.Font = new Font("Segoe UI", 13F);
            updateInstructorButton.Location = new Point(272, 216);
            updateInstructorButton.Name = "updateInstructorButton";
            updateInstructorButton.Size = new Size(260, 64);
            updateInstructorButton.TabIndex = 25;
            updateInstructorButton.Text = "Update instructor details";
            updateInstructorButton.UseVisualStyleBackColor = true;
            // 
            // deleteInstructorButton
            // 
            deleteInstructorButton.Font = new Font("Segoe UI", 13F);
            deleteInstructorButton.Location = new Point(272, 144);
            deleteInstructorButton.Name = "deleteInstructorButton";
            deleteInstructorButton.Size = new Size(260, 64);
            deleteInstructorButton.TabIndex = 24;
            deleteInstructorButton.Text = "Delete instructor";
            deleteInstructorButton.UseVisualStyleBackColor = true;
            // 
            // addInstructorButton
            // 
            addInstructorButton.Font = new Font("Segoe UI", 13F);
            addInstructorButton.Location = new Point(272, 79);
            addInstructorButton.Name = "addInstructorButton";
            addInstructorButton.Size = new Size(260, 59);
            addInstructorButton.TabIndex = 23;
            addInstructorButton.Text = "Add instructor";
            addInstructorButton.UseVisualStyleBackColor = true;
            addInstructorButton.Click += addInstructorButton_Click;
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
            Controls.Add(listInstructorButton);
            Controls.Add(searchInstructorButton);
            Controls.Add(updateInstructorButton);
            Controls.Add(deleteInstructorButton);
            Controls.Add(addInstructorButton);
            Controls.Add(label1);
            Name = "InstructorHandler";
            Text = "Instructor Handler";
            ResumeLayout(false);
        }

        #endregion

        private Button backButton;
        private Button exitButton;
        private Button listInstructorButton;
        private Button searchInstructorButton;
        private Button updateInstructorButton;
        private Button deleteInstructorButton;
        private Button addInstructorButton;
        private Label label1;
    }
}
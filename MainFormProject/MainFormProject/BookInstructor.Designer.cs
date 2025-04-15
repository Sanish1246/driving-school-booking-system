namespace MainFormProject
{
    partial class BookInstructor
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
            InstructorEmail = new TextBox();
            label2 = new Label();
            backButton = new Button();
            exitButton = new Button();
            label1 = new Label();
            listView1 = new ListView();
            emailError = new Label();
            SuspendLayout();
            // 
            // submitButton
            // 
            submitButton.Font = new Font("Segoe UI", 12F);
            submitButton.Location = new Point(508, 377);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(103, 35);
            submitButton.TabIndex = 49;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // InstructorEmail
            // 
            InstructorEmail.Font = new Font("Segoe UI", 12F);
            InstructorEmail.Location = new Point(321, 378);
            InstructorEmail.Name = "InstructorEmail";
            InstructorEmail.Size = new Size(181, 34);
            InstructorEmail.TabIndex = 48;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(256, 381);
            label2.Name = "label2";
            label2.Size = new Size(59, 28);
            label2.TabIndex = 47;
            label2.Text = "Email";
            // 
            // backButton
            // 
            backButton.Font = new Font("Segoe UI", 10F);
            backButton.Location = new Point(12, 24);
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
            exitButton.Location = new Point(694, 24);
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
            label1.Location = new Point(256, 9);
            label1.Name = "label1";
            label1.Size = new Size(308, 46);
            label1.TabIndex = 43;
            label1.Text = "Select an instructor";
            // 
            // listView1
            // 
            listView1.Location = new Point(3, 59);
            listView1.Name = "listView1";
            listView1.Size = new Size(794, 313);
            listView1.TabIndex = 50;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // emailError
            // 
            emailError.AutoSize = true;
            emailError.Font = new Font("Segoe UI", 10F);
            emailError.ForeColor = Color.Red;
            emailError.Location = new Point(307, 415);
            emailError.Name = "emailError";
            emailError.Size = new Size(55, 23);
            emailError.TabIndex = 51;
            emailError.Text = "label3";
            // 
            // BookInstructor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(emailError);
            Controls.Add(listView1);
            Controls.Add(submitButton);
            Controls.Add(InstructorEmail);
            Controls.Add(label2);
            Controls.Add(backButton);
            Controls.Add(exitButton);
            Controls.Add(label1);
            Name = "BookInstructor";
            Text = "Book Instructor";
            Load += BookInstructor_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button submitButton;
        private TextBox InstructorEmail;
        private Label label2;
        private Button backButton;
        private Button exitButton;
        private Label label1;
        private ListView listView1;
        private Label emailError;
    }
}
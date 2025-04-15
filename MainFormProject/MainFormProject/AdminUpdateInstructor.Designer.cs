namespace MainFormProject
{
    partial class AdminUpdateInstructor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminUpdateInstructor));
            submitButton = new Button();
            Email = new TextBox();
            label4 = new Label();
            backButton = new Button();
            exitButton = new Button();
            label1 = new Label();
            emailError = new Label();
            SuspendLayout();
            // 
            // submitButton
            // 
            submitButton.Font = new Font("Segoe UI", 12F);
            submitButton.Location = new Point(340, 275);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(102, 39);
            submitButton.TabIndex = 46;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // Email
            // 
            Email.Font = new Font("Segoe UI", 12F);
            Email.Location = new Point(367, 181);
            Email.Name = "Email";
            Email.Size = new Size(169, 34);
            Email.TabIndex = 45;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(302, 184);
            label4.Name = "label4";
            label4.Size = new Size(59, 28);
            label4.TabIndex = 44;
            label4.Text = "Email";
            // 
            // backButton
            // 
            backButton.Font = new Font("Segoe UI", 10F);
            backButton.Location = new Point(15, 21);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 43;
            backButton.Text = "< Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // exitButton
            // 
            exitButton.Font = new Font("Segoe UI", 10F);
            exitButton.ForeColor = Color.Red;
            exitButton.Location = new Point(697, 21);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(94, 29);
            exitButton.TabIndex = 42;
            exitButton.Text = " Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(211, 9);
            label1.Name = "label1";
            label1.Size = new Size(392, 46);
            label1.TabIndex = 41;
            label1.Text = "Input the email to search";
            // 
            // emailError
            // 
            emailError.AutoSize = true;
            emailError.Font = new Font("Segoe UI", 10F);
            emailError.ForeColor = Color.Red;
            emailError.Location = new Point(340, 218);
            emailError.Name = "emailError";
            emailError.Size = new Size(47, 23);
            emailError.TabIndex = 47;
            emailError.Text = "Error";
            emailError.Visible = false;
            // 
            // AdminUpdateInstructor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(emailError);
            Controls.Add(submitButton);
            Controls.Add(Email);
            Controls.Add(label4);
            Controls.Add(backButton);
            Controls.Add(exitButton);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminUpdateInstructor";
            Text = "Update Instructor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button submitButton;
        private TextBox Email;
        private Label label4;
        private Button backButton;
        private Button exitButton;
        private Label label1;
        private Label emailError;
    }
}
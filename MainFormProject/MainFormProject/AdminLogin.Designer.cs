namespace MainFormProject
{
    partial class AdminLogin
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
            passwordError = new Label();
            emailError = new Label();
            button1 = new Button();
            label3 = new Label();
            Password = new TextBox();
            Email = new TextBox();
            label2 = new Label();
            label1 = new Label();
            backButton = new Button();
            exitButton = new Button();
            SuspendLayout();
            // 
            // passwordError
            // 
            passwordError.AutoSize = true;
            passwordError.ForeColor = Color.Red;
            passwordError.Location = new Point(292, 286);
            passwordError.Name = "passwordError";
            passwordError.Size = new Size(138, 20);
            passwordError.TabIndex = 16;
            passwordError.Text = "Incorrect password!";
            passwordError.Visible = false;
            // 
            // emailError
            // 
            emailError.AutoSize = true;
            emailError.ForeColor = Color.Red;
            emailError.Location = new Point(292, 219);
            emailError.Name = "emailError";
            emailError.Size = new Size(167, 20);
            emailError.TabIndex = 15;
            emailError.Text = "Incorrect email address!";
            emailError.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(344, 335);
            button1.Name = "button1";
            button1.Size = new Size(117, 58);
            button1.TabIndex = 14;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(193, 255);
            label3.Name = "label3";
            label3.Size = new Size(93, 28);
            label3.TabIndex = 13;
            label3.Text = "Password";
            // 
            // Password
            // 
            Password.Location = new Point(292, 256);
            Password.Name = "Password";
            Password.Size = new Size(334, 27);
            Password.TabIndex = 12;
            // 
            // Email
            // 
            Email.Location = new Point(292, 189);
            Email.Name = "Email";
            Email.Size = new Size(334, 27);
            Email.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(132, 189);
            label2.Name = "label2";
            label2.Size = new Size(154, 28);
            label2.TabIndex = 10;
            label2.Text = "Username/Email";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(138, 57);
            label1.Name = "label1";
            label1.Size = new Size(524, 48);
            label1.TabIndex = 9;
            label1.Text = "Enter your login details below";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // backButton
            // 
            backButton.Font = new Font("Segoe UI", 10F);
            backButton.Location = new Point(12, 12);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 30;
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
            exitButton.TabIndex = 31;
            exitButton.Text = " Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // AdminLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(exitButton);
            Controls.Add(backButton);
            Controls.Add(passwordError);
            Controls.Add(emailError);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(Password);
            Controls.Add(Email);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AdminLogin";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label passwordError;
        private Label emailError;
        private Button button1;
        private Label label3;
        private TextBox Password;
        private TextBox Email;
        private Label label2;
        private Label label1;
        private Button backButton;
        private Button exitButton;
    }
}
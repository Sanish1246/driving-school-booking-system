namespace MainFormProject
{
    partial class AdminDeleteStudent
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
            label1 = new Label();
            Email = new TextBox();
            label4 = new Label();
            submitButton = new Button();
            emailError = new Label();
            SuspendLayout();
            // 
            // backButton
            // 
            backButton.Font = new Font("Segoe UI", 10F);
            backButton.Location = new Point(12, 12);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 25;
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
            exitButton.TabIndex = 24;
            exitButton.Text = " Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(208, 12);
            label1.Name = "label1";
            label1.Size = new Size(380, 46);
            label1.TabIndex = 23;
            label1.Text = "Input the following data";
            // 
            // Email
            // 
            Email.Font = new Font("Segoe UI", 12F);
            Email.Location = new Point(364, 172);
            Email.Name = "Email";
            Email.Size = new Size(169, 34);
            Email.TabIndex = 27;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(256, 175);
            label4.Name = "label4";
            label4.Size = new Size(59, 28);
            label4.TabIndex = 26;
            label4.Text = "Email";
            // 
            // submitButton
            // 
            submitButton.Font = new Font("Segoe UI", 12F);
            submitButton.Location = new Point(337, 266);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(102, 39);
            submitButton.TabIndex = 28;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // emailError
            // 
            emailError.AutoSize = true;
            emailError.Font = new Font("Segoe UI", 10F);
            emailError.ForeColor = Color.Red;
            emailError.Location = new Point(337, 209);
            emailError.Name = "emailError";
            emailError.Size = new Size(47, 23);
            emailError.TabIndex = 29;
            emailError.Text = "Error";
            emailError.Visible = false;
            // 
            // AdminDeleteStudent
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
            Name = "AdminDeleteStudent";
            Text = "Delete Student";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button backButton;
        private Button exitButton;
        private Label label1;
        private TextBox Email;
        private Label label4;
        private Button submitButton;
        private Label emailError;
    }
}
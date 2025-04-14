namespace MainFormProject
{
    partial class AdminSearchStudent
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
            email = new TextBox();
            label4 = new Label();
            backButton = new Button();
            exitButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // submitButton
            // 
            submitButton.Font = new Font("Segoe UI", 12F);
            submitButton.Location = new Point(337, 275);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(102, 39);
            submitButton.TabIndex = 34;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // email
            // 
            email.Font = new Font("Segoe UI", 12F);
            email.Location = new Point(364, 181);
            email.Name = "email";
            email.Size = new Size(169, 34);
            email.TabIndex = 33;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(256, 184);
            label4.Name = "label4";
            label4.Size = new Size(59, 28);
            label4.TabIndex = 32;
            label4.Text = "Email";
            // 
            // backButton
            // 
            backButton.Font = new Font("Segoe UI", 10F);
            backButton.Location = new Point(12, 21);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 31;
            backButton.Text = "< Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // exitButton
            // 
            exitButton.Font = new Font("Segoe UI", 10F);
            exitButton.ForeColor = Color.Red;
            exitButton.Location = new Point(694, 21);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(94, 29);
            exitButton.TabIndex = 30;
            exitButton.Text = " Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(208, 9);
            label1.Name = "label1";
            label1.Size = new Size(392, 46);
            label1.TabIndex = 29;
            label1.Text = "Input the email to search";
            // 
            // AdminSearchStudent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(submitButton);
            Controls.Add(email);
            Controls.Add(label4);
            Controls.Add(backButton);
            Controls.Add(exitButton);
            Controls.Add(label1);
            Name = "AdminSearchStudent";
            Text = "Search Student";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button submitButton;
        private TextBox email;
        private Label label4;
        private Button backButton;
        private Button exitButton;
        private Label label1;
    }
}
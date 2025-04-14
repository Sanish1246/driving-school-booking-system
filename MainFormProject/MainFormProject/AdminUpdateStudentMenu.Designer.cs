namespace MainFormProject
{
    partial class AdminUpdateStudentMenu
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
            comboBox1 = new ComboBox();
            inputUpdate = new TextBox();
            submitButton = new Button();
            errorLabel = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // backButton
            // 
            backButton.Font = new Font("Segoe UI", 10F);
            backButton.Location = new Point(10, 21);
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
            exitButton.Location = new Point(692, 21);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(94, 29);
            exitButton.TabIndex = 39;
            exitButton.Text = " Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(206, 9);
            label1.Name = "label1";
            label1.Size = new Size(398, 46);
            label1.TabIndex = 38;
            label1.Text = "Select the field to update";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "First name", "Last name", "Email", "Password", "Date of birth", "Address", "Phone number" });
            comboBox1.Location = new Point(320, 97);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 41;
            comboBox1.Text = "First name";
            // 
            // inputUpdate
            // 
            inputUpdate.Font = new Font("Segoe UI", 13F);
            inputUpdate.Location = new Point(298, 204);
            inputUpdate.Name = "inputUpdate";
            inputUpdate.Size = new Size(195, 36);
            inputUpdate.TabIndex = 42;
            // 
            // submitButton
            // 
            submitButton.Font = new Font("Segoe UI", 12F);
            submitButton.Location = new Point(320, 298);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(165, 68);
            submitButton.TabIndex = 43;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.Font = new Font("Segoe UI", 10F);
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(294, 253);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(47, 23);
            errorLabel.TabIndex = 44;
            errorLabel.Text = "error";
            errorLabel.Visible = false;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(10, 385);
            label6.Name = "label6";
            label6.Size = new Size(785, 56);
            label6.TabIndex = 45;
            label6.Text = "Password should contain at least one uppercase letter, one lowercase letter, one digit, one special character and should be at least 12 charaters long";
            // 
            // AdminUpdateStudentMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(errorLabel);
            Controls.Add(submitButton);
            Controls.Add(inputUpdate);
            Controls.Add(comboBox1);
            Controls.Add(backButton);
            Controls.Add(exitButton);
            Controls.Add(label1);
            Name = "AdminUpdateStudentMenu";
            Text = "Update Student Menu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button backButton;
        private Button exitButton;
        private Label label1;
        private ComboBox comboBox1;
        private TextBox inputUpdate;
        private Button submitButton;
        private Label errorLabel;
        private Label label6;
    }
}
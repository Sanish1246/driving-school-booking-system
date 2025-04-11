namespace MainFormProject
{
    partial class AdminAddStudent
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
            label2 = new Label();
            firstName = new TextBox();
            lastName = new TextBox();
            label3 = new Label();
            email = new TextBox();
            label4 = new Label();
            password = new TextBox();
            label5 = new Label();
            DOB = new TextBox();
            label6 = new Label();
            phoneNum = new TextBox();
            label7 = new Label();
            address = new TextBox();
            label8 = new Label();
            exitButton = new Button();
            backButton = new Button();
            submitButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(206, 9);
            label1.Name = "label1";
            label1.Size = new Size(380, 46);
            label1.TabIndex = 0;
            label1.Text = "Input the following data";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(67, 106);
            label2.Name = "label2";
            label2.Size = new Size(102, 28);
            label2.TabIndex = 1;
            label2.Text = "First name";
            // 
            // firstName
            // 
            firstName.Font = new Font("Segoe UI", 12F);
            firstName.Location = new Point(175, 103);
            firstName.Name = "firstName";
            firstName.Size = new Size(169, 34);
            firstName.TabIndex = 2;
            // 
            // lastName
            // 
            lastName.Font = new Font("Segoe UI", 12F);
            lastName.Location = new Point(546, 103);
            lastName.Name = "lastName";
            lastName.Size = new Size(169, 34);
            lastName.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(438, 106);
            label3.Name = "label3";
            label3.Size = new Size(99, 28);
            label3.TabIndex = 3;
            label3.Text = "Last name";
            // 
            // email
            // 
            email.Font = new Font("Segoe UI", 12F);
            email.Location = new Point(175, 176);
            email.Name = "email";
            email.Size = new Size(169, 34);
            email.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(67, 179);
            label4.Name = "label4";
            label4.Size = new Size(59, 28);
            label4.TabIndex = 5;
            label4.Text = "Email";
            // 
            // password
            // 
            password.Font = new Font("Segoe UI", 12F);
            password.Location = new Point(546, 173);
            password.Name = "password";
            password.Size = new Size(169, 34);
            password.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(438, 176);
            label5.Name = "label5";
            label5.Size = new Size(93, 28);
            label5.TabIndex = 7;
            label5.Text = "Password";
            // 
            // DOB
            // 
            DOB.Font = new Font("Segoe UI", 12F);
            DOB.Location = new Point(175, 239);
            DOB.Name = "DOB";
            DOB.Size = new Size(169, 34);
            DOB.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(67, 242);
            label6.Name = "label6";
            label6.Size = new Size(52, 28);
            label6.TabIndex = 9;
            label6.Text = "DOB";
            // 
            // phoneNum
            // 
            phoneNum.Font = new Font("Segoe UI", 12F);
            phoneNum.Location = new Point(546, 242);
            phoneNum.Name = "phoneNum";
            phoneNum.Size = new Size(169, 34);
            phoneNum.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(400, 245);
            label7.Name = "label7";
            label7.Size = new Size(140, 28);
            label7.TabIndex = 11;
            label7.Text = "Phone number";
            // 
            // address
            // 
            address.Font = new Font("Segoe UI", 12F);
            address.Location = new Point(334, 311);
            address.Name = "address";
            address.Size = new Size(169, 34);
            address.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(226, 314);
            label8.Name = "label8";
            label8.Size = new Size(82, 28);
            label8.TabIndex = 13;
            label8.Text = "Address";
            // 
            // exitButton
            // 
            exitButton.Font = new Font("Segoe UI", 10F);
            exitButton.ForeColor = Color.Red;
            exitButton.Location = new Point(694, 9);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(94, 29);
            exitButton.TabIndex = 21;
            exitButton.Text = " Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // backButton
            // 
            backButton.Font = new Font("Segoe UI", 10F);
            backButton.Location = new Point(12, 9);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 22;
            backButton.Text = "< Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // submitButton
            // 
            submitButton.Font = new Font("Segoe UI", 12F);
            submitButton.Location = new Point(334, 373);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(102, 39);
            submitButton.TabIndex = 23;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // AdminAddStudent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(submitButton);
            Controls.Add(backButton);
            Controls.Add(exitButton);
            Controls.Add(address);
            Controls.Add(label8);
            Controls.Add(phoneNum);
            Controls.Add(label7);
            Controls.Add(DOB);
            Controls.Add(label6);
            Controls.Add(password);
            Controls.Add(label5);
            Controls.Add(email);
            Controls.Add(label4);
            Controls.Add(lastName);
            Controls.Add(label3);
            Controls.Add(firstName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AdminAddStudent";
            Text = "Add Student";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox firstName;
        private TextBox lastName;
        private Label label3;
        private TextBox email;
        private Label label4;
        private TextBox password;
        private Label label5;
        private TextBox DOB;
        private Label label6;
        private TextBox phoneNum;
        private Label label7;
        private TextBox address;
        private Label label8;
        private Button exitButton;
        private Button backButton;
        private Button submitButton;
    }
}
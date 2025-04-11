namespace MainFormProject
{
    partial class AdminAddInstructor
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
            backButton = new Button();
            exitButton = new Button();
            address = new TextBox();
            label8 = new Label();
            phoneNum = new TextBox();
            label7 = new Label();
            DOB = new TextBox();
            label6 = new Label();
            password = new TextBox();
            label5 = new Label();
            email = new TextBox();
            label4 = new Label();
            lastName = new TextBox();
            label3 = new Label();
            firstName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // submitButton
            // 
            submitButton.Font = new Font("Segoe UI", 12F);
            submitButton.Location = new Point(334, 373);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(102, 39);
            submitButton.TabIndex = 41;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // backButton
            // 
            backButton.Font = new Font("Segoe UI", 10F);
            backButton.Location = new Point(12, 9);
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
            exitButton.Location = new Point(694, 9);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(94, 29);
            exitButton.TabIndex = 39;
            exitButton.Text = " Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // address
            // 
            address.Font = new Font("Segoe UI", 12F);
            address.Location = new Point(334, 311);
            address.Name = "address";
            address.Size = new Size(169, 34);
            address.TabIndex = 38;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(226, 314);
            label8.Name = "label8";
            label8.Size = new Size(82, 28);
            label8.TabIndex = 37;
            label8.Text = "Address";
            // 
            // phoneNum
            // 
            phoneNum.Font = new Font("Segoe UI", 12F);
            phoneNum.Location = new Point(546, 242);
            phoneNum.Name = "phoneNum";
            phoneNum.Size = new Size(169, 34);
            phoneNum.TabIndex = 36;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(400, 245);
            label7.Name = "label7";
            label7.Size = new Size(140, 28);
            label7.TabIndex = 35;
            label7.Text = "Phone number";
            // 
            // DOB
            // 
            DOB.Font = new Font("Segoe UI", 12F);
            DOB.Location = new Point(175, 239);
            DOB.Name = "DOB";
            DOB.Size = new Size(169, 34);
            DOB.TabIndex = 34;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(67, 242);
            label6.Name = "label6";
            label6.Size = new Size(52, 28);
            label6.TabIndex = 33;
            label6.Text = "DOB";
            // 
            // password
            // 
            password.Font = new Font("Segoe UI", 12F);
            password.Location = new Point(546, 173);
            password.Name = "password";
            password.Size = new Size(169, 34);
            password.TabIndex = 32;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(438, 176);
            label5.Name = "label5";
            label5.Size = new Size(93, 28);
            label5.TabIndex = 31;
            label5.Text = "Password";
            // 
            // email
            // 
            email.Font = new Font("Segoe UI", 12F);
            email.Location = new Point(175, 176);
            email.Name = "email";
            email.Size = new Size(169, 34);
            email.TabIndex = 30;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(67, 179);
            label4.Name = "label4";
            label4.Size = new Size(59, 28);
            label4.TabIndex = 29;
            label4.Text = "Email";
            // 
            // lastName
            // 
            lastName.Font = new Font("Segoe UI", 12F);
            lastName.Location = new Point(546, 103);
            lastName.Name = "lastName";
            lastName.Size = new Size(169, 34);
            lastName.TabIndex = 28;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(438, 106);
            label3.Name = "label3";
            label3.Size = new Size(99, 28);
            label3.TabIndex = 27;
            label3.Text = "Last name";
            // 
            // firstName
            // 
            firstName.Font = new Font("Segoe UI", 12F);
            firstName.Location = new Point(175, 103);
            firstName.Name = "firstName";
            firstName.Size = new Size(169, 34);
            firstName.TabIndex = 26;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(67, 106);
            label2.Name = "label2";
            label2.Size = new Size(102, 28);
            label2.TabIndex = 25;
            label2.Text = "First name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(206, 9);
            label1.Name = "label1";
            label1.Size = new Size(380, 46);
            label1.TabIndex = 24;
            label1.Text = "Input the following data";
            // 
            // AdminAddInstructor
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
            Name = "AdminAddInstructor";
            Text = "Add Instructor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button submitButton;
        private Button backButton;
        private Button exitButton;
        private TextBox address;
        private Label label8;
        private TextBox phoneNum;
        private Label label7;
        private TextBox DOB;
        private Label label6;
        private TextBox password;
        private Label label5;
        private TextBox email;
        private Label label4;
        private TextBox lastName;
        private Label label3;
        private TextBox firstName;
        private Label label2;
        private Label label1;
    }
}
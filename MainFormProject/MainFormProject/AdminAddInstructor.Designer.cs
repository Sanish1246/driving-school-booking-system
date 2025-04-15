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
            backButton = new Button();
            exitButton = new Button();
            label1 = new Label();
            invalidAddress = new Label();
            invalidLast = new Label();
            invalidEmail = new Label();
            invalidPassword = new Label();
            invalidPhone = new Label();
            invalidFirst = new Label();
            label6 = new Label();
            labelDate = new Label();
            DOB = new DateTimePicker();
            submitButton = new Button();
            Address = new TextBox();
            label8 = new Label();
            PhoneNum = new TextBox();
            label7 = new Label();
            Password = new TextBox();
            label5 = new Label();
            Email = new TextBox();
            label4 = new Label();
            LastName = new TextBox();
            label3 = new Label();
            FirstName = new TextBox();
            label2 = new Label();
            SuspendLayout();
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
            // invalidAddress
            // 
            invalidAddress.AutoSize = true;
            invalidAddress.ForeColor = Color.Red;
            invalidAddress.Location = new Point(371, 319);
            invalidAddress.Name = "invalidAddress";
            invalidAddress.Size = new Size(108, 20);
            invalidAddress.TabIndex = 62;
            invalidAddress.Text = "Invaild address";
            invalidAddress.Visible = false;
            // 
            // invalidLast
            // 
            invalidLast.AutoSize = true;
            invalidLast.ForeColor = Color.Red;
            invalidLast.Location = new Point(570, 111);
            invalidLast.Name = "invalidLast";
            invalidLast.Size = new Size(121, 20);
            invalidLast.TabIndex = 61;
            invalidLast.Text = "Invaild last name";
            invalidLast.Visible = false;
            // 
            // invalidEmail
            // 
            invalidEmail.AutoSize = true;
            invalidEmail.ForeColor = Color.Red;
            invalidEmail.Location = new Point(174, 184);
            invalidEmail.Name = "invalidEmail";
            invalidEmail.Size = new Size(94, 20);
            invalidEmail.TabIndex = 60;
            invalidEmail.Text = "Invaild email";
            invalidEmail.Visible = false;
            // 
            // invalidPassword
            // 
            invalidPassword.AutoSize = true;
            invalidPassword.ForeColor = Color.Red;
            invalidPassword.Location = new Point(568, 181);
            invalidPassword.Name = "invalidPassword";
            invalidPassword.Size = new Size(120, 20);
            invalidPassword.TabIndex = 59;
            invalidPassword.Text = "Invaild password";
            invalidPassword.Visible = false;
            // 
            // invalidPhone
            // 
            invalidPhone.AutoSize = true;
            invalidPhone.ForeColor = Color.Red;
            invalidPhone.Location = new Point(545, 250);
            invalidPhone.Name = "invalidPhone";
            invalidPhone.Size = new Size(154, 20);
            invalidPhone.TabIndex = 58;
            invalidPhone.Text = "Invaild phone number";
            invalidPhone.Visible = false;
            // 
            // invalidFirst
            // 
            invalidFirst.AutoSize = true;
            invalidFirst.ForeColor = Color.Red;
            invalidFirst.Location = new Point(201, 111);
            invalidFirst.Name = "invalidFirst";
            invalidFirst.Size = new Size(123, 20);
            invalidFirst.TabIndex = 57;
            invalidFirst.Text = "Invaild first name";
            invalidFirst.Visible = false;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(7, 386);
            label6.Name = "label6";
            label6.Size = new Size(785, 56);
            label6.TabIndex = 56;
            label6.Text = "Password should contain at least one uppercase letter, one lowercase letter, one digit, one special character and should be at least 12 charaters long";
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Font = new Font("Segoe UI", 12F);
            labelDate.Location = new Point(66, 219);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(52, 28);
            labelDate.TabIndex = 55;
            labelDate.Text = "DOB";
            // 
            // DOB
            // 
            DOB.Location = new Point(123, 220);
            DOB.Name = "DOB";
            DOB.Size = new Size(250, 27);
            DOB.TabIndex = 54;
            // 
            // submitButton
            // 
            submitButton.Font = new Font("Segoe UI", 12F);
            submitButton.Location = new Point(333, 344);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(102, 39);
            submitButton.TabIndex = 53;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // Address
            // 
            Address.Font = new Font("Segoe UI", 12F);
            Address.Location = new Point(333, 282);
            Address.Name = "Address";
            Address.Size = new Size(169, 34);
            Address.TabIndex = 52;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(225, 285);
            label8.Name = "label8";
            label8.Size = new Size(82, 28);
            label8.TabIndex = 51;
            label8.Text = "Address";
            // 
            // PhoneNum
            // 
            PhoneNum.Font = new Font("Segoe UI", 12F);
            PhoneNum.Location = new Point(545, 213);
            PhoneNum.Name = "PhoneNum";
            PhoneNum.Size = new Size(169, 34);
            PhoneNum.TabIndex = 50;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(399, 216);
            label7.Name = "label7";
            label7.Size = new Size(140, 28);
            label7.TabIndex = 49;
            label7.Text = "Phone number";
            // 
            // Password
            // 
            Password.Font = new Font("Segoe UI", 12F);
            Password.Location = new Point(545, 144);
            Password.Name = "Password";
            Password.Size = new Size(169, 34);
            Password.TabIndex = 48;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(437, 147);
            label5.Name = "label5";
            label5.Size = new Size(93, 28);
            label5.TabIndex = 47;
            label5.Text = "Password";
            // 
            // Email
            // 
            Email.Font = new Font("Segoe UI", 12F);
            Email.Location = new Point(174, 147);
            Email.Name = "Email";
            Email.Size = new Size(169, 34);
            Email.TabIndex = 46;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(66, 150);
            label4.Name = "label4";
            label4.Size = new Size(59, 28);
            label4.TabIndex = 45;
            label4.Text = "Email";
            // 
            // LastName
            // 
            LastName.Font = new Font("Segoe UI", 12F);
            LastName.Location = new Point(545, 74);
            LastName.Name = "LastName";
            LastName.Size = new Size(169, 34);
            LastName.TabIndex = 44;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(437, 77);
            label3.Name = "label3";
            label3.Size = new Size(99, 28);
            label3.TabIndex = 43;
            label3.Text = "Last name";
            // 
            // FirstName
            // 
            FirstName.Font = new Font("Segoe UI", 12F);
            FirstName.Location = new Point(174, 74);
            FirstName.Name = "FirstName";
            FirstName.Size = new Size(169, 34);
            FirstName.TabIndex = 42;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(66, 77);
            label2.Name = "label2";
            label2.Size = new Size(102, 28);
            label2.TabIndex = 41;
            label2.Text = "First name";
            // 
            // AdminAddInstructor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(invalidAddress);
            Controls.Add(invalidLast);
            Controls.Add(invalidEmail);
            Controls.Add(invalidPassword);
            Controls.Add(invalidPhone);
            Controls.Add(invalidFirst);
            Controls.Add(label6);
            Controls.Add(labelDate);
            Controls.Add(DOB);
            Controls.Add(submitButton);
            Controls.Add(Address);
            Controls.Add(label8);
            Controls.Add(PhoneNum);
            Controls.Add(label7);
            Controls.Add(Password);
            Controls.Add(label5);
            Controls.Add(Email);
            Controls.Add(label4);
            Controls.Add(LastName);
            Controls.Add(label3);
            Controls.Add(FirstName);
            Controls.Add(label2);
            Controls.Add(backButton);
            Controls.Add(exitButton);
            Controls.Add(label1);
            Name = "AdminAddInstructor";
            Text = "Add Instructor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button backButton;
        private Button exitButton;
        private Label label1;
        private Label invalidAddress;
        private Label invalidLast;
        private Label invalidEmail;
        private Label invalidPassword;
        private Label invalidPhone;
        private Label invalidFirst;
        private Label label6;
        private Label labelDate;
        private DateTimePicker DOB;
        private Button submitButton;
        private TextBox Address;
        private Label label8;
        private TextBox PhoneNum;
        private Label label7;
        private TextBox Password;
        private Label label5;
        private TextBox Email;
        private Label label4;
        private TextBox LastName;
        private Label label3;
        private TextBox FirstName;
        private Label label2;
    }
}
namespace MainFormProject
{
    partial class AdminAddCar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminAddCar));
            submitButton = new Button();
            backButton = new Button();
            exitButton = new Button();
            RegistrationNo = new TextBox();
            label8 = new Label();
            Transmission = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            Make = new TextBox();
            invalidMake = new Label();
            invalidTransmission = new Label();
            invalidRegNo = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // submitButton
            // 
            submitButton.Font = new Font("Segoe UI", 12F);
            submitButton.Location = new Point(336, 341);
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
            backButton.Location = new Point(14, 9);
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
            exitButton.Location = new Point(696, 9);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(94, 29);
            exitButton.TabIndex = 39;
            exitButton.Text = " Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // RegistrationNo
            // 
            RegistrationNo.Font = new Font("Segoe UI", 12F);
            RegistrationNo.Location = new Point(336, 241);
            RegistrationNo.Name = "RegistrationNo";
            RegistrationNo.Size = new Size(169, 34);
            RegistrationNo.TabIndex = 38;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(140, 244);
            label8.Name = "label8";
            label8.Size = new Size(190, 28);
            label8.TabIndex = 37;
            label8.Text = "Registration number";
            // 
            // Transmission
            // 
            Transmission.Font = new Font("Segoe UI", 12F);
            Transmission.Location = new Point(548, 136);
            Transmission.Name = "Transmission";
            Transmission.Size = new Size(169, 34);
            Transmission.TabIndex = 28;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(420, 139);
            label3.Name = "label3";
            label3.Size = new Size(122, 28);
            label3.TabIndex = 27;
            label3.Text = "Transmission";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(102, 139);
            label2.Name = "label2";
            label2.Size = new Size(60, 28);
            label2.TabIndex = 25;
            label2.Text = "Make";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(208, 9);
            label1.Name = "label1";
            label1.Size = new Size(380, 46);
            label1.TabIndex = 24;
            label1.Text = "Input the following data";
            // 
            // Make
            // 
            Make.Font = new Font("Segoe UI", 12F);
            Make.Location = new Point(177, 139);
            Make.Name = "Make";
            Make.Size = new Size(169, 34);
            Make.TabIndex = 26;
            // 
            // invalidMake
            // 
            invalidMake.AutoSize = true;
            invalidMake.ForeColor = Color.Red;
            invalidMake.Location = new Point(183, 176);
            invalidMake.Name = "invalidMake";
            invalidMake.Size = new Size(147, 20);
            invalidMake.TabIndex = 42;
            invalidMake.Text = "Make can't be empty";
            invalidMake.Visible = false;
            // 
            // invalidTransmission
            // 
            invalidTransmission.AutoSize = true;
            invalidTransmission.ForeColor = Color.Red;
            invalidTransmission.Location = new Point(465, 173);
            invalidTransmission.Name = "invalidTransmission";
            invalidTransmission.Size = new Size(325, 20);
            invalidTransmission.TabIndex = 43;
            invalidTransmission.Text = "Transmission can either be automatic or manual";
            invalidTransmission.Visible = false;
            // 
            // invalidRegNo
            // 
            invalidRegNo.AutoSize = true;
            invalidRegNo.ForeColor = Color.Red;
            invalidRegNo.Location = new Point(336, 278);
            invalidRegNo.Name = "invalidRegNo";
            invalidRegNo.Size = new Size(188, 20);
            invalidRegNo.TabIndex = 44;
            invalidRegNo.Text = "Invaild registration number";
            invalidRegNo.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(121, 399);
            label4.Name = "label4";
            label4.Size = new Size(528, 28);
            label4.TabIndex = 45;
            label4.Text = "Car registration number should be in the format (AB99CDE)";
            // 
            // AdminAddCar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(invalidRegNo);
            Controls.Add(invalidTransmission);
            Controls.Add(invalidMake);
            Controls.Add(submitButton);
            Controls.Add(backButton);
            Controls.Add(exitButton);
            Controls.Add(RegistrationNo);
            Controls.Add(label8);
            Controls.Add(Transmission);
            Controls.Add(label3);
            Controls.Add(Make);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminAddCar";
            Text = "Add Car";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button submitButton;
        private Button backButton;
        private Button exitButton;
        private TextBox RegistrationNo;
        private Label label8;
        private TextBox Transmission;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox Make;
        private Label invalidMake;
        private Label invalidTransmission;
        private Label invalidRegNo;
        private Label label4;
    }
}
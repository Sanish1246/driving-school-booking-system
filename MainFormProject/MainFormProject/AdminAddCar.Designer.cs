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
            submitButton = new Button();
            backButton = new Button();
            exitButton = new Button();
            registrationNo = new TextBox();
            label8 = new Label();
            transmission = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            make = new TextBox();
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
            // registrationNo
            // 
            registrationNo.Font = new Font("Segoe UI", 12F);
            registrationNo.Location = new Point(336, 241);
            registrationNo.Name = "registrationNo";
            registrationNo.Size = new Size(169, 34);
            registrationNo.TabIndex = 38;
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
            // transmission
            // 
            transmission.Font = new Font("Segoe UI", 12F);
            transmission.Location = new Point(548, 136);
            transmission.Name = "transmission";
            transmission.Size = new Size(169, 34);
            transmission.TabIndex = 28;
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
            // make
            // 
            make.Font = new Font("Segoe UI", 12F);
            make.Location = new Point(177, 139);
            make.Name = "make";
            make.Size = new Size(169, 34);
            make.TabIndex = 26;
            // 
            // AdminAddCar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(submitButton);
            Controls.Add(backButton);
            Controls.Add(exitButton);
            Controls.Add(registrationNo);
            Controls.Add(label8);
            Controls.Add(transmission);
            Controls.Add(label3);
            Controls.Add(make);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AdminAddCar";
            Text = "Add Car";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button submitButton;
        private Button backButton;
        private Button exitButton;
        private TextBox registrationNo;
        private Label label8;
        private TextBox transmission;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox make;
    }
}
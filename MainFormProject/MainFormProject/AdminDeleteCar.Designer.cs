﻿namespace MainFormProject
{
    partial class AdminDeleteCar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDeleteCar));
            submitButton = new Button();
            registrationNo = new TextBox();
            label4 = new Label();
            backButton = new Button();
            exitButton = new Button();
            label1 = new Label();
            invalidRegNo = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // submitButton
            // 
            submitButton.Font = new Font("Segoe UI", 12F);
            submitButton.Location = new Point(338, 263);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(102, 39);
            submitButton.TabIndex = 34;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // registrationNo
            // 
            registrationNo.Font = new Font("Segoe UI", 12F);
            registrationNo.Location = new Point(365, 169);
            registrationNo.Name = "registrationNo";
            registrationNo.Size = new Size(169, 34);
            registrationNo.TabIndex = 33;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(169, 172);
            label4.Name = "label4";
            label4.Size = new Size(190, 28);
            label4.TabIndex = 32;
            label4.Text = "Registration number";
            // 
            // backButton
            // 
            backButton.Font = new Font("Segoe UI", 10F);
            backButton.Location = new Point(13, 9);
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
            exitButton.Location = new Point(695, 9);
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
            label1.Location = new Point(209, 9);
            label1.Name = "label1";
            label1.Size = new Size(380, 46);
            label1.TabIndex = 29;
            label1.Text = "Input the following data";
            // 
            // invalidRegNo
            // 
            invalidRegNo.AutoSize = true;
            invalidRegNo.ForeColor = Color.Red;
            invalidRegNo.Location = new Point(306, 215);
            invalidRegNo.Name = "invalidRegNo";
            invalidRegNo.Size = new Size(188, 20);
            invalidRegNo.TabIndex = 45;
            invalidRegNo.Text = "Invaild registration number";
            invalidRegNo.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(132, 354);
            label2.Name = "label2";
            label2.Size = new Size(528, 28);
            label2.TabIndex = 46;
            label2.Text = "Car registration number should be in the format (AB99CDE)";
            // 
            // AdminDeleteCar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(invalidRegNo);
            Controls.Add(submitButton);
            Controls.Add(registrationNo);
            Controls.Add(label4);
            Controls.Add(backButton);
            Controls.Add(exitButton);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminDeleteCar";
            Text = "Delete Car";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button submitButton;
        private TextBox registrationNo;
        private Label label4;
        private Button backButton;
        private Button exitButton;
        private Label label1;
        private Label invalidRegNo;
        private Label label2;
    }
}
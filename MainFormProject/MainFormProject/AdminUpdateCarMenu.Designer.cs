namespace MainFormProject
{
    partial class AdminUpdateCarMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminUpdateCarMenu));
            submitButton = new Button();
            inputUpdate = new TextBox();
            comboBox1 = new ComboBox();
            backButton = new Button();
            exitButton = new Button();
            label1 = new Label();
            errorLabel = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // submitButton
            // 
            submitButton.Font = new Font("Segoe UI", 12F);
            submitButton.Location = new Point(322, 298);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(165, 68);
            submitButton.TabIndex = 55;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // inputUpdate
            // 
            inputUpdate.Font = new Font("Segoe UI", 13F);
            inputUpdate.Location = new Point(300, 204);
            inputUpdate.Name = "inputUpdate";
            inputUpdate.Size = new Size(195, 36);
            inputUpdate.TabIndex = 54;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Make", "Transmission", "Registration Number" });
            comboBox1.Location = new Point(322, 97);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 53;
            comboBox1.Text = "Make";
            // 
            // backButton
            // 
            backButton.Font = new Font("Segoe UI", 10F);
            backButton.Location = new Point(12, 21);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 52;
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
            exitButton.TabIndex = 51;
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
            label1.Size = new Size(398, 46);
            label1.TabIndex = 50;
            label1.Text = "Select the field to update";
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.Font = new Font("Segoe UI", 10F);
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(300, 243);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(47, 23);
            errorLabel.TabIndex = 56;
            errorLabel.Text = "error";
            errorLabel.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(135, 386);
            label4.Name = "label4";
            label4.Size = new Size(528, 28);
            label4.TabIndex = 57;
            label4.Text = "Car registration number should be in the format (AB99CDE)";
            // 
            // AdminUpdateCarMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(errorLabel);
            Controls.Add(submitButton);
            Controls.Add(inputUpdate);
            Controls.Add(comboBox1);
            Controls.Add(backButton);
            Controls.Add(exitButton);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminUpdateCarMenu";
            Text = "Update Car";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button submitButton;
        private TextBox inputUpdate;
        private ComboBox comboBox1;
        private Button backButton;
        private Button exitButton;
        private Label label1;
        private Label errorLabel;
        private Label label4;
    }
}
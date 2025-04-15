namespace MainFormProject
{
    partial class AdminUpdateLesson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminUpdateLesson));
            errorLabel = new Label();
            submitButton = new Button();
            inputUpdate = new TextBox();
            comboBox1 = new ComboBox();
            backButton = new Button();
            exitButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.Font = new Font("Segoe UI", 10F);
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(301, 253);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(47, 23);
            errorLabel.TabIndex = 51;
            errorLabel.Text = "error";
            errorLabel.Visible = false;
            // 
            // submitButton
            // 
            submitButton.Font = new Font("Segoe UI", 12F);
            submitButton.Location = new Point(327, 298);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(165, 68);
            submitButton.TabIndex = 50;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // inputUpdate
            // 
            inputUpdate.Font = new Font("Segoe UI", 13F);
            inputUpdate.Location = new Point(305, 204);
            inputUpdate.Name = "inputUpdate";
            inputUpdate.Size = new Size(195, 36);
            inputUpdate.TabIndex = 49;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Student first name", "Student last name", "Student email", "Instructor first name", "Instructor last name", "Instructor email", "Car transmission", "Lesson date" });
            comboBox1.Location = new Point(327, 97);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 48;
            comboBox1.Text = "Student first name";
            // 
            // backButton
            // 
            backButton.Font = new Font("Segoe UI", 10F);
            backButton.Location = new Point(17, 21);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 47;
            backButton.Text = "< Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // exitButton
            // 
            exitButton.Font = new Font("Segoe UI", 10F);
            exitButton.ForeColor = Color.Red;
            exitButton.Location = new Point(699, 21);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(94, 29);
            exitButton.TabIndex = 46;
            exitButton.Text = " Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(213, 9);
            label1.Name = "label1";
            label1.Size = new Size(398, 46);
            label1.TabIndex = 45;
            label1.Text = "Select the field to update";
            // 
            // AdminUpdateLesson
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(errorLabel);
            Controls.Add(submitButton);
            Controls.Add(inputUpdate);
            Controls.Add(comboBox1);
            Controls.Add(backButton);
            Controls.Add(exitButton);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminUpdateLesson";
            Text = "Update Lesson";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label errorLabel;
        private Button submitButton;
        private TextBox inputUpdate;
        private ComboBox comboBox1;
        private Button backButton;
        private Button exitButton;
        private Label label1;
    }
}
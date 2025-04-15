namespace MainFormProject
{
    partial class BookCar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookCar));
            submitButton = new Button();
            registrationNo = new TextBox();
            label2 = new Label();
            backButton = new Button();
            exitButton = new Button();
            label1 = new Label();
            listView1 = new ListView();
            invalidRegNo = new Label();
            SuspendLayout();
            // 
            // submitButton
            // 
            submitButton.Font = new Font("Segoe UI", 12F);
            submitButton.Location = new Point(507, 374);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(103, 35);
            submitButton.TabIndex = 56;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // registrationNo
            // 
            registrationNo.Font = new Font("Segoe UI", 12F);
            registrationNo.Location = new Point(320, 375);
            registrationNo.Name = "registrationNo";
            registrationNo.Size = new Size(181, 34);
            registrationNo.TabIndex = 55;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(165, 377);
            label2.Name = "label2";
            label2.Size = new Size(149, 28);
            label2.TabIndex = 54;
            label2.Text = "Registration No";
            // 
            // backButton
            // 
            backButton.Font = new Font("Segoe UI", 10F);
            backButton.Location = new Point(11, 24);
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
            exitButton.Location = new Point(693, 24);
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
            label1.Location = new Point(311, 9);
            label1.Name = "label1";
            label1.Size = new Size(190, 46);
            label1.TabIndex = 50;
            label1.Text = "Select a car";
            // 
            // listView1
            // 
            listView1.Location = new Point(0, 59);
            listView1.Name = "listView1";
            listView1.Size = new Size(799, 310);
            listView1.TabIndex = 57;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // invalidRegNo
            // 
            invalidRegNo.AutoSize = true;
            invalidRegNo.Font = new Font("Segoe UI", 10F);
            invalidRegNo.ForeColor = Color.Red;
            invalidRegNo.Location = new Point(295, 412);
            invalidRegNo.Name = "invalidRegNo";
            invalidRegNo.Size = new Size(55, 23);
            invalidRegNo.TabIndex = 58;
            invalidRegNo.Text = "label3";
            invalidRegNo.Visible = false;
            // 
            // BookCar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(invalidRegNo);
            Controls.Add(listView1);
            Controls.Add(submitButton);
            Controls.Add(registrationNo);
            Controls.Add(label2);
            Controls.Add(backButton);
            Controls.Add(exitButton);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "BookCar";
            Text = "Book Car";
            Load += BookCar_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button submitButton;
        private TextBox registrationNo;
        private Label label2;
        private Button backButton;
        private Button exitButton;
        private Label label1;
        private ListView listView1;
        private Label invalidRegNo;
    }
}
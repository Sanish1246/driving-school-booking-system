namespace MainFormProject
{
    partial class AdminSearchLesson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminSearchLesson));
            backButton = new Button();
            exitButton = new Button();
            label1 = new Label();
            submitButton = new Button();
            label2 = new Label();
            LessonDate = new DateTimePicker();
            listView1 = new ListView();
            SuspendLayout();
            // 
            // backButton
            // 
            backButton.Font = new Font("Segoe UI", 10F);
            backButton.Location = new Point(13, 24);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 45;
            backButton.Text = "< Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // exitButton
            // 
            exitButton.Font = new Font("Segoe UI", 10F);
            exitButton.ForeColor = Color.Red;
            exitButton.Location = new Point(695, 24);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(94, 29);
            exitButton.TabIndex = 44;
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
            label1.Size = new Size(383, 46);
            label1.TabIndex = 43;
            label1.Text = "Input the Date to search";
            // 
            // submitButton
            // 
            submitButton.Font = new Font("Segoe UI", 12F);
            submitButton.Location = new Point(532, 70);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(103, 35);
            submitButton.TabIndex = 52;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(154, 73);
            label2.Name = "label2";
            label2.Size = new Size(116, 28);
            label2.TabIndex = 50;
            label2.Text = "Lesson Date";
            // 
            // LessonDate
            // 
            LessonDate.Location = new Point(276, 75);
            LessonDate.Name = "LessonDate";
            LessonDate.Size = new Size(250, 27);
            LessonDate.TabIndex = 56;
            // 
            // listView1
            // 
            listView1.Location = new Point(2, 111);
            listView1.Name = "listView1";
            listView1.Size = new Size(796, 338);
            listView1.TabIndex = 57;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // AdminSearchLesson
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(listView1);
            Controls.Add(LessonDate);
            Controls.Add(submitButton);
            Controls.Add(label2);
            Controls.Add(backButton);
            Controls.Add(exitButton);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminSearchLesson";
            Text = "Search Lesson";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button backButton;
        private Button exitButton;
        private Label label1;
        private Button submitButton;
        private Label label2;
        private DateTimePicker LessonDate;
        private ListView listView1;
    }
}
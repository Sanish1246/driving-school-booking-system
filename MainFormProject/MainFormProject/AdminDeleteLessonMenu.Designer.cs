namespace MainFormProject
{
    partial class AdminDeleteLessonMenu
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
            label2 = new Label();
            LessonId = new TextBox();
            submitButton = new Button();
            invalidLesson = new Label();
            listView1 = new ListView();
            SuspendLayout();
            // 
            // backButton
            // 
            backButton.Font = new Font("Segoe UI", 10F);
            backButton.Location = new Point(12, 24);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 38;
            backButton.Text = "< Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // exitButton
            // 
            exitButton.Font = new Font("Segoe UI", 10F);
            exitButton.ForeColor = Color.Red;
            exitButton.Location = new Point(694, 24);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(94, 29);
            exitButton.TabIndex = 37;
            exitButton.Text = " Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(260, 7);
            label1.Name = "label1";
            label1.Size = new Size(301, 46);
            label1.TabIndex = 36;
            label1.Text = "Input the lesson ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(221, 380);
            label2.Name = "label2";
            label2.Size = new Size(94, 28);
            label2.TabIndex = 40;
            label2.Text = "Lesson ID";
            // 
            // LessonId
            // 
            LessonId.Font = new Font("Segoe UI", 12F);
            LessonId.Location = new Point(321, 377);
            LessonId.Name = "LessonId";
            LessonId.Size = new Size(181, 34);
            LessonId.TabIndex = 41;
            // 
            // submitButton
            // 
            submitButton.Font = new Font("Segoe UI", 12F);
            submitButton.Location = new Point(508, 376);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(103, 35);
            submitButton.TabIndex = 42;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // invalidLesson
            // 
            invalidLesson.AutoSize = true;
            invalidLesson.Font = new Font("Segoe UI", 10F);
            invalidLesson.ForeColor = Color.Red;
            invalidLesson.Location = new Point(353, 414);
            invalidLesson.Name = "invalidLesson";
            invalidLesson.Size = new Size(137, 23);
            invalidLesson.TabIndex = 43;
            invalidLesson.Text = "invalid Lesson ID";
            invalidLesson.Visible = false;
            // 
            // listView1
            // 
            listView1.Location = new Point(4, 58);
            listView1.Name = "listView1";
            listView1.Size = new Size(794, 312);
            listView1.TabIndex = 44;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // AdminDeleteLessonMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(listView1);
            Controls.Add(invalidLesson);
            Controls.Add(submitButton);
            Controls.Add(LessonId);
            Controls.Add(label2);
            Controls.Add(backButton);
            Controls.Add(exitButton);
            Controls.Add(label1);
            Name = "AdminDeleteLessonMenu";
            Text = "Select lesson";
            Load += AdminDeleteLessonMenu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button backButton;
        private Button exitButton;
        private Label label1;
        private Label label2;
        private TextBox LessonId;
        private Button submitButton;
        private Label invalidLesson;
        private ListView listView1;
    }
}
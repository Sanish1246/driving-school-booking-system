namespace MainFormProject
{
    partial class LessonHandler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LessonHandler));
            backButton = new Button();
            exitButton = new Button();
            listLessonButton = new Button();
            searchLessonButton = new Button();
            updateLessonButton = new Button();
            deleteLessonButton = new Button();
            addLessonButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // backButton
            // 
            backButton.Font = new Font("Segoe UI", 10F);
            backButton.Location = new Point(12, 12);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 29;
            backButton.Text = "< Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // exitButton
            // 
            exitButton.Font = new Font("Segoe UI", 10F);
            exitButton.ForeColor = Color.Red;
            exitButton.Location = new Point(694, 12);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(94, 29);
            exitButton.TabIndex = 28;
            exitButton.Text = " Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // listLessonButton
            // 
            listLessonButton.Font = new Font("Segoe UI", 13F);
            listLessonButton.Location = new Point(290, 338);
            listLessonButton.Name = "listLessonButton";
            listLessonButton.Size = new Size(248, 56);
            listLessonButton.TabIndex = 27;
            listLessonButton.Text = "List all lessons";
            listLessonButton.UseVisualStyleBackColor = true;
            listLessonButton.Click += listLessonButton_Click;
            // 
            // searchLessonButton
            // 
            searchLessonButton.Font = new Font("Segoe UI", 13F);
            searchLessonButton.Location = new Point(290, 276);
            searchLessonButton.Name = "searchLessonButton";
            searchLessonButton.Size = new Size(248, 56);
            searchLessonButton.TabIndex = 26;
            searchLessonButton.Text = "Search for a lesson";
            searchLessonButton.UseVisualStyleBackColor = true;
            searchLessonButton.Click += searchLessonButton_Click;
            // 
            // updateLessonButton
            // 
            updateLessonButton.Font = new Font("Segoe UI", 13F);
            updateLessonButton.Location = new Point(290, 214);
            updateLessonButton.Name = "updateLessonButton";
            updateLessonButton.Size = new Size(248, 56);
            updateLessonButton.TabIndex = 25;
            updateLessonButton.Text = "Update lesson details";
            updateLessonButton.UseVisualStyleBackColor = true;
            updateLessonButton.Click += updateLessonButton_Click;
            // 
            // deleteLessonButton
            // 
            deleteLessonButton.Font = new Font("Segoe UI", 13F);
            deleteLessonButton.Location = new Point(290, 144);
            deleteLessonButton.Name = "deleteLessonButton";
            deleteLessonButton.Size = new Size(248, 64);
            deleteLessonButton.TabIndex = 24;
            deleteLessonButton.Text = "Delete lesson";
            deleteLessonButton.UseVisualStyleBackColor = true;
            deleteLessonButton.Click += deleteLessonButton_Click;
            // 
            // addLessonButton
            // 
            addLessonButton.Font = new Font("Segoe UI", 13F);
            addLessonButton.Location = new Point(290, 79);
            addLessonButton.Name = "addLessonButton";
            addLessonButton.Size = new Size(248, 59);
            addLessonButton.TabIndex = 23;
            addLessonButton.Text = "Add lesson";
            addLessonButton.UseVisualStyleBackColor = true;
            addLessonButton.Click += addLessonButton_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(153, 9);
            label1.Name = "label1";
            label1.Size = new Size(524, 48);
            label1.TabIndex = 22;
            label1.Text = "Choose an option";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LessonHandler
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(backButton);
            Controls.Add(exitButton);
            Controls.Add(listLessonButton);
            Controls.Add(searchLessonButton);
            Controls.Add(updateLessonButton);
            Controls.Add(deleteLessonButton);
            Controls.Add(addLessonButton);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LessonHandler";
            Text = "Lesson Handler";
            ResumeLayout(false);
        }

        #endregion

        private Button backButton;
        private Button exitButton;
        private Button listLessonButton;
        private Button searchLessonButton;
        private Button updateLessonButton;
        private Button deleteLessonButton;
        private Button addLessonButton;
        private Label label1;
    }
}
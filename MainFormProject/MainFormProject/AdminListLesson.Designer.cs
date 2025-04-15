namespace MainFormProject
{
    partial class AdminListLesson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminListLesson));
            backButton = new Button();
            exitButton = new Button();
            label1 = new Label();
            listView1 = new ListView();
            SuspendLayout();
            // 
            // backButton
            // 
            backButton.Font = new Font("Segoe UI", 10F);
            backButton.Location = new Point(12, 26);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 42;
            backButton.Text = "< Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // exitButton
            // 
            exitButton.Font = new Font("Segoe UI", 10F);
            exitButton.ForeColor = Color.Red;
            exitButton.Location = new Point(694, 26);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(94, 29);
            exitButton.TabIndex = 41;
            exitButton.Text = " Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(271, 9);
            label1.Name = "label1";
            label1.Size = new Size(226, 46);
            label1.TabIndex = 40;
            label1.Text = "List of lessons";
            // 
            // listView1
            // 
            listView1.Location = new Point(5, 61);
            listView1.Name = "listView1";
            listView1.Size = new Size(793, 377);
            listView1.TabIndex = 43;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // AdminListLesson
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(listView1);
            Controls.Add(backButton);
            Controls.Add(exitButton);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminListLesson";
            Text = "List Lesson";
            Load += AdminListLesson_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button backButton;
        private Button exitButton;
        private Label label1;
        private ListView listView1;
    }
}
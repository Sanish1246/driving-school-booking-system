namespace MainFormProject
{
    partial class AdminListCar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminListCar));
            backButton = new Button();
            exitButton = new Button();
            label1 = new Label();
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
            label1.Location = new Point(271, 9);
            label1.Name = "label1";
            label1.Size = new Size(178, 46);
            label1.TabIndex = 36;
            label1.Text = "List of cars";
            // 
            // listView1
            // 
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(2, 59);
            listView1.Name = "listView1";
            listView1.Size = new Size(795, 382);
            listView1.TabIndex = 39;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // AdminListCar
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
            Name = "AdminListCar";
            Text = "List Car";
            Load += AdminListCar_Load;
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
namespace MainFormProject
{
    partial class StudentHandler
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
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
            button4 = new Button();
            button5 = new Button();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 13F);
            button3.Location = new Point(290, 214);
            button3.Name = "button3";
            button3.Size = new Size(248, 56);
            button3.TabIndex = 17;
            button3.Text = "Update student details";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 13F);
            button2.Location = new Point(290, 144);
            button2.Name = "button2";
            button2.Size = new Size(248, 64);
            button2.TabIndex = 16;
            button2.Text = "Delete student";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 13F);
            button1.Location = new Point(290, 79);
            button1.Name = "button1";
            button1.Size = new Size(248, 59);
            button1.TabIndex = 15;
            button1.Text = "Add student";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(153, 9);
            label1.Name = "label1";
            label1.Size = new Size(524, 48);
            label1.TabIndex = 14;
            label1.Text = "Choose an option";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 13F);
            button4.Location = new Point(290, 276);
            button4.Name = "button4";
            button4.Size = new Size(248, 56);
            button4.TabIndex = 18;
            button4.Text = "Search for a student";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 13F);
            button5.Location = new Point(290, 338);
            button5.Name = "button5";
            button5.Size = new Size(248, 56);
            button5.TabIndex = 19;
            button5.Text = "List all students";
            button5.UseVisualStyleBackColor = true;
            // 
            // StudentHandler
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "StudentHandler";
            Text = "StudentHandler";
            ResumeLayout(false);
        }

        #endregion

        private Button button3;
        private Button button2;
        private Button button1;
        private Label label1;
        private Button button4;
        private Button button5;
    }
}
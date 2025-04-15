namespace MainFormProject
{
    partial class CarHandler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarHandler));
            backButton = new Button();
            exitButton = new Button();
            listCarButton = new Button();
            searchCarButton = new Button();
            updateCarButton = new Button();
            deleteCarButton = new Button();
            addCarButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // backButton
            // 
            backButton.Font = new Font("Segoe UI", 10F);
            backButton.Location = new Point(10, 12);
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
            exitButton.Location = new Point(692, 12);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(94, 29);
            exitButton.TabIndex = 28;
            exitButton.Text = " Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // listCarButton
            // 
            listCarButton.Font = new Font("Segoe UI", 13F);
            listCarButton.Location = new Point(288, 338);
            listCarButton.Name = "listCarButton";
            listCarButton.Size = new Size(248, 56);
            listCarButton.TabIndex = 27;
            listCarButton.Text = "List all cars";
            listCarButton.UseVisualStyleBackColor = true;
            listCarButton.Click += listCarButton_Click;
            // 
            // searchCarButton
            // 
            searchCarButton.Font = new Font("Segoe UI", 13F);
            searchCarButton.Location = new Point(288, 276);
            searchCarButton.Name = "searchCarButton";
            searchCarButton.Size = new Size(248, 56);
            searchCarButton.TabIndex = 26;
            searchCarButton.Text = "Search for a car";
            searchCarButton.UseVisualStyleBackColor = true;
            searchCarButton.Click += searchCarButton_Click;
            // 
            // updateCarButton
            // 
            updateCarButton.Font = new Font("Segoe UI", 13F);
            updateCarButton.Location = new Point(288, 214);
            updateCarButton.Name = "updateCarButton";
            updateCarButton.Size = new Size(248, 56);
            updateCarButton.TabIndex = 25;
            updateCarButton.Text = "Update car details";
            updateCarButton.UseVisualStyleBackColor = true;
            updateCarButton.Click += updateCarButton_Click;
            // 
            // deleteCarButton
            // 
            deleteCarButton.Font = new Font("Segoe UI", 13F);
            deleteCarButton.Location = new Point(288, 144);
            deleteCarButton.Name = "deleteCarButton";
            deleteCarButton.Size = new Size(248, 64);
            deleteCarButton.TabIndex = 24;
            deleteCarButton.Text = "Delete car";
            deleteCarButton.UseVisualStyleBackColor = true;
            deleteCarButton.Click += deleteCarButton_Click;
            // 
            // addCarButton
            // 
            addCarButton.Font = new Font("Segoe UI", 13F);
            addCarButton.Location = new Point(288, 79);
            addCarButton.Name = "addCarButton";
            addCarButton.Size = new Size(248, 59);
            addCarButton.TabIndex = 23;
            addCarButton.Text = "Add car";
            addCarButton.UseVisualStyleBackColor = true;
            addCarButton.Click += addCarButton_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(151, 9);
            label1.Name = "label1";
            label1.Size = new Size(524, 48);
            label1.TabIndex = 22;
            label1.Text = "Choose an option";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CarHandler
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(backButton);
            Controls.Add(exitButton);
            Controls.Add(listCarButton);
            Controls.Add(searchCarButton);
            Controls.Add(updateCarButton);
            Controls.Add(deleteCarButton);
            Controls.Add(addCarButton);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CarHandler";
            Text = "Car Handler";
            ResumeLayout(false);
        }

        #endregion

        private Button backButton;
        private Button exitButton;
        private Button listCarButton;
        private Button searchCarButton;
        private Button updateCarButton;
        private Button deleteCarButton;
        private Button addCarButton;
        private Label label1;
    }
}
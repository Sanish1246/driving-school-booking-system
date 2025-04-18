﻿namespace MainFormProject
{
    public partial class InstructorHandler : Form
    {
        public InstructorHandler()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu();

            this.Close();

            adminMenu.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addInstructorButton_Click(object sender, EventArgs e)
        {
            AdminAddInstructor addInstructor = new AdminAddInstructor();

            this.Close();

            addInstructor.Show();
        }

        private void deleteInstructorButton_Click(object sender, EventArgs e)
        {
            AdminDeleteInstructor deleteInstructor = new AdminDeleteInstructor();

            this.Close();

            deleteInstructor.Show();
        }

        private void updateInstructorButton_Click(object sender, EventArgs e)
        {
            AdminUpdateInstructor updateInstructor = new AdminUpdateInstructor();

            this.Close();
            
            // Update instructor detail
            updateInstructor.Show();
        }

        private void searchInstructorButton_Click(object sender, EventArgs e)
        {
            AdminSearchInstructor searchInstructor = new AdminSearchInstructor();

            this.Close();
            
            // Search instructor by email
            searchInstructor.Show();
        }

        private void listInstructorButton_Click(object sender, EventArgs e)
        {
            AdminListInstructor listInstructor = new AdminListInstructor();

            this.Close();
            
            // Display all instructors
            listInstructor.Show();
        }
    }
}

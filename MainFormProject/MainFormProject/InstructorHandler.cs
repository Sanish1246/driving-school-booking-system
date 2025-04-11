using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainFormProject
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
    }
}

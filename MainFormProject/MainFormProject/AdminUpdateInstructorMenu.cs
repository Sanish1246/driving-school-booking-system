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
    public partial class AdminUpdateInstructorMenu : Form
    {
        public AdminUpdateInstructorMenu()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            AdminUpdateInstructor updateInstructor = new AdminUpdateInstructor();

            this.Close();

            updateInstructor.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Instructor data updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

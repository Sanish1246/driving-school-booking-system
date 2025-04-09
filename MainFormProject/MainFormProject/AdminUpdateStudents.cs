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
    public partial class AdminUpdateStudents : Form
    {
        public AdminUpdateStudents()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            StudentHandler studentHandlerMenu = new StudentHandler();

            studentHandlerMenu.Show();

            this.Close();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Student data updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

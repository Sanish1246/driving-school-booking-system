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
    public partial class AdminAddStudent : Form
    {
        public AdminAddStudent()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            StudentHandler studentHandlerMenu = new StudentHandler();

            studentHandlerMenu.Show();

            this.Close();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Student added", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

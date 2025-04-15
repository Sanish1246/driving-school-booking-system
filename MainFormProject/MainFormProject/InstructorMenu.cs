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
    public partial class InstructorMenu : Form
    {
        private string email;
        public InstructorMenu(string newEmail)
        {
            InitializeComponent();
            email = newEmail;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void studentLessonsButton_Click(object sender, EventArgs e)
        {
            AdminListLesson listLesson = new AdminListLesson("instructor", email);

            this.Close();

            listLesson.Show();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            AdminLogin loginMenu = new AdminLogin("instructor");

            this.Close();

            loginMenu.Show();
        }
    }
}

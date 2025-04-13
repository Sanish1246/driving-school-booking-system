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
        public InstructorMenu()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void studentLessonsButton_Click(object sender, EventArgs e)
        {
            AdminListLesson listLesson = new AdminListLesson("instructor");

            this.Close();

            listLesson.Show();
        }
    }
}

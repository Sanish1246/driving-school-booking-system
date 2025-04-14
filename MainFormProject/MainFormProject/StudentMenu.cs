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
    public partial class StudentMenu : Form
    {
        public StudentMenu()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void studentLessonsButton_Click(object sender, EventArgs e)
        {
            AdminListLesson listLesson = new AdminListLesson("student");

            this.Close();

            listLesson.Show();
        }

        private void bookLessonButton_Click(object sender, EventArgs e)
        {
            BookInstructor bookInstructor = new BookInstructor();

            this.Close();

            bookInstructor.Show();
        }
    }
}

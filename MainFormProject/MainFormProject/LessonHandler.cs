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
    public partial class LessonHandler : Form
    {
        public LessonHandler()
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

        private void addLessonButton_Click(object sender, EventArgs e)
        {
            AdminAddLesson addLesson = new AdminAddLesson();

            this.Close();

            addLesson.Show();
        }

        private void deleteLessonButton_Click(object sender, EventArgs e)
        {
            AdminDeleteLesson deleteLesson = new AdminDeleteLesson("delete", "", "", "");

            this.Close();

            deleteLesson.Show();
        }

        private void searchLessonButton_Click(object sender, EventArgs e)
        {
            AdminSearchLesson searchLesson = new AdminSearchLesson();

            this.Close();

            searchLesson.Show();
        }

        private void listLessonButton_Click(object sender, EventArgs e)
        {
            AdminListLesson listLesson = new AdminListLesson("admin", "");

            this.Close();

            listLesson.Show();
        }

        private void updateLessonButton_Click(object sender, EventArgs e)
        {
            AdminDeleteLesson deleteLesson = new AdminDeleteLesson("update", "", "", "");

            this.Close();

            deleteLesson.Show();
        }
    }
}

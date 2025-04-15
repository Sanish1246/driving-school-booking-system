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
    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void handleStudentsButton_Click(object sender, EventArgs e)
        {
            StudentHandler studentHandlerMenu = new StudentHandler();

            this.Close();

            studentHandlerMenu.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void handleInstructorsButton_Click(object sender, EventArgs e)
        {
            InstructorHandler instructorHandlerMenu = new InstructorHandler();

            this.Close();

            instructorHandlerMenu.Show();
        }

        private void handleCarsButton_Click(object sender, EventArgs e)
        {
            CarHandler carHandlerMenu = new CarHandler();

            this.Close();

            carHandlerMenu.Show();
        }

        private void handleLessonButton_Click(object sender, EventArgs e)
        {
            LessonHandler lessonHandlerMenu = new LessonHandler();

            this.Close();

            lessonHandlerMenu.Show();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            AdminLogin loginMenu = new AdminLogin("admin");

            this.Close();

            loginMenu.Show();
        }
    }
}

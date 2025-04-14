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
    public partial class AdminListLesson : Form
    {
        private string userType;
        public AdminListLesson(string userType)
        {
            InitializeComponent();
            this.userType = userType;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (userType == "student")
            {
                StudentMenu studentMenu = new StudentMenu();

                this.Close();

                studentMenu.Show();
            } else if (userType == "instructor")
            {
                InstructorMenu instructorMenu = new InstructorMenu();

                this.Close();

                instructorMenu.Show();
            }
            else
            {
                LessonHandler lessonHandlerMenu = new LessonHandler();

                this.Close();

                lessonHandlerMenu.Show();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

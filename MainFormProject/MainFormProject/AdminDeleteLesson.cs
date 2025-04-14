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
    public partial class AdminDeleteLesson : Form
    {
        private string operation;
        public AdminDeleteLesson(string operation)
        {
            InitializeComponent();
            this.operation = operation;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (operation == "delete")
            {
                LessonHandler lessonHandlerMenu = new LessonHandler();

                this.Close();

                lessonHandlerMenu.Show();
            } else
            {
                BookCar bookCar = new BookCar();

                this.Close();

                bookCar.Show();
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (operation == "delete")
            {
                AdminDeleteLessonMenu deleteLessonMenu = new AdminDeleteLessonMenu();

                this.Close();

                deleteLessonMenu.Show();
            } else
            {
                MessageBox.Show("Lesson booked!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

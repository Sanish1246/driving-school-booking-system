using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
                string lessonDate = LessonDate.Value.ToString("yyyy/MM/dd");
                DateOnly newLessonDate = DateOnly.ParseExact(lessonDate, "yyyy/MM/dd", CultureInfo.InvariantCulture);

                AdminDeleteLessonMenu deleteLessonMenu = new AdminDeleteLessonMenu(newLessonDate);

                this.Close();

                deleteLessonMenu.Show();
            } else
            {
                MessageBox.Show("Lesson booked!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

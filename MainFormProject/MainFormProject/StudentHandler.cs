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
    public partial class StudentHandler : Form
    {
        public StudentHandler()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu();

            this.Close();

            adminMenu.Show();
        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            AdminAddStudent addStudent = new AdminAddStudent();

            this.Close();

            addStudent.Show();
        }

        private void deleteStudentButton_Click(object sender, EventArgs e)
        {
            AdminDeleteStudent deleteStudent = new AdminDeleteStudent();

            this.Close();

            deleteStudent.Show();
        }

        private void updateStudentButton_Click(object sender, EventArgs e)
        {
            AdminUpdateStudents updateStudent = new AdminUpdateStudents();

            this.Close();

            updateStudent.Show();
        }

        private void searchStudentButton_Click(object sender, EventArgs e)
        {
            AdminSearchStudent searchStudent = new AdminSearchStudent();

            this.Close();

            searchStudent.Show();
        }

        private void listStudentButton_Click(object sender, EventArgs e)
        {
            AdminListStudent listStudent = new AdminListStudent();

            this.Close();

            listStudent.Show();
        }
    }
}

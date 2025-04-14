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
    public partial class BookCar : Form
    {
        public BookCar()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            BookInstructor bookInstructor = new BookInstructor();

            this.Close();

            bookInstructor.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            AdminDeleteLesson deleteLesson = new AdminDeleteLesson("book");

            this.Close();

            deleteLesson.Show();
        }
    }
}

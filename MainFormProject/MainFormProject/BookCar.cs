using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainFormProject.Context;
using MainFormProject.Models;
using Microsoft.EntityFrameworkCore;

namespace MainFormProject
{
    public partial class BookCar : Form
    {
        private string studentEmail;
        private string instructorEmail;
        public BookCar(string newStudentEmail, string newInstructorEmail)
        {
            InitializeComponent();
            studentEmail = newStudentEmail;
            instructorEmail = newInstructorEmail;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            BookInstructor bookInstructor = new BookInstructor(studentEmail);

            this.Close();

            bookInstructor.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void BookCar_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            listView1.Columns.Clear();
            listView1.Columns.Add("Make", 500);
            listView1.Columns.Add("Transmission", 1000);
            listView1.Columns.Add("Registration No", 1000);

            try
            {
                using (var context = new DrivingLessonBookingSystemContext())
                {
                    var cars = context.Cars.AsNoTracking().ToList();

                    listView1.Items.Clear(); //Clear old data

                    foreach (var car in cars)
                    {
                        var item = new ListViewItem(car.Make ?? "");
                        item.SubItems.Add(car.Transmission ?? "");
                        item.SubItems.Add(car.RegistrationNumber ?? "");

                        listView1.Items.Add(item);
                    }

                    // Adapt columns
                    listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Processing failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string regNo = registrationNo.Text;
            invalidRegNo.Hide();

            if (Validations.ValidateString(regNo))
            {
                if (CarRegistrationChecker(regNo))
                {
                    if (!IsUnique(regNo))
                    {
                        AdminDeleteLesson deleteLesson = new AdminDeleteLesson("book",studentEmail,instructorEmail, regNo);

                        this.Close();

                        deleteLesson.Show();
                    }
                    else
                    {
                        invalidRegNo.Text = "Registration number not found";
                        invalidRegNo.Show();
                    }
                }
                else
                {
                    invalidRegNo.Text = "Format should be AA99CDE";
                    invalidRegNo.Show();
                }
            }
            else
            {
                invalidRegNo.Text = "Registration number can't be empty";
                invalidRegNo.Show();
            }
        }

        public static bool CarRegistrationChecker(string registrationNumber)
        {
            var registrationNumberRegex = new Regex(@"^[a-zA-Z]{2}[\d]{2}[\s]?[a-zA-Z]{3}$");
            var m = registrationNumberRegex.Match(registrationNumber);
            return m.Success;
        }

        public static bool IsUnique(string registrationNumber)
        {
            var success = false;
            try
            {
                using (var context = new DrivingLessonBookingSystemContext())
                {
                    success = context.Cars.Any(c => c.RegistrationNumber == registrationNumber);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Processing failed: {e.Message}");
            }

            return !success;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainFormProject.Context;
using MainFormProject.Models;
using Microsoft.EntityFrameworkCore;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace MainFormProject
{
    public partial class AdminUpdateLesson : Form
    {
        private int lessonId;
        private DateOnly lessonDate;
        private string studentEmail;
        private string instructorEmail;
        private string regNo;
        public AdminUpdateLesson(int newId, DateOnly newlessonDate, string newStudentEmail, string newInstructorEmail, string newRegNo)
        {
            InitializeComponent();
            lessonId = newId;
            lessonDate = newlessonDate;
            studentEmail = newStudentEmail;
            instructorEmail = newInstructorEmail;
            regNo = newRegNo;
        }

        private void backButton_Click(object sender, EventArgs e)
        {

            AdminDeleteLessonMenu deleteLessonMenu = new AdminDeleteLessonMenu(lessonDate, "update");

            deleteLessonMenu.Show();

            this.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            errorLabel.Hide();
            string option = comboBox1.Text;

            switch (option)
            {
                case "Student first name":
                    UpdateFirstName();
                    break;
                case "Student last name":
                    UpdateLastName();
                    break;
                case "Student email":
                    UpdateEmail();
                    break;
            }
        }

        public void UpdateFirstName()
        {
            string firstName = inputUpdate.Text;

            if (!Validations.ValidateString(firstName))
            {
                errorLabel.Text = "First name can't be empty";
                errorLabel.Show();
            }
            else
            {
                try
                {
                    var table = new OfflineDatabase();
                    table.LoadTables();
                    using (var context = new DrivingLessonBookingSystemContext())
                    {
                        // Update into HashTable
                        var result = table.StudentTable.Where(s => s.Email.Equals(studentEmail, StringComparison.InvariantCulture)).ToArray();
                        table.StudentTable.Delete(studentEmail);
                        result[0].FirstName = firstName;
                        table.StudentTable.Insert(studentEmail, result[0]);

                        context.Students.Where(s => s.Email == studentEmail).ExecuteUpdate(setters => setters.SetProperty(s => s.FirstName, firstName));
                        MessageBox.Show("First name updated successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        inputUpdate.Text = "";
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Processing failed: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void UpdateLastName()
        {
            string lastName = inputUpdate.Text;

            if (!Validations.ValidateString(lastName))
            {
                errorLabel.Text = "Last name can't be empty";
                errorLabel.Show();
            }
            else
            {
                try
                {
                    var table = new OfflineDatabase();
                    table.LoadTables();
                    using (var context = new DrivingLessonBookingSystemContext())
                    {
                        // Update into HashTable
                        var result = table.StudentTable.Where(s => s.Email.Equals(studentEmail, StringComparison.InvariantCulture)).ToArray();
                        table.StudentTable.Delete(studentEmail);
                        result[0].LastName = lastName;
                        table.StudentTable.Insert(studentEmail, result[0]);

                        context.Students.Where(s => s.Email == studentEmail).ExecuteUpdate(setters => setters.SetProperty(s => s.LastName, lastName));
                        MessageBox.Show("Last name updated successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        inputUpdate.Text = "";
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Processing failed: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void UpdateEmail()
        {
            string newEmail = inputUpdate.Text;
            if (Validations.ValidateString(newEmail))
            {
                if (Validations.ValidateEmail(newEmail))
                {
                    if (!CheckStudentEmailExistence(newEmail))
                    {
                        try
                        {
                            var table = new OfflineDatabase();
                            table.LoadTables();
                            using (var context = new DrivingLessonBookingSystemContext())
                            {
                                // Update into HashTable
                                var result = table.StudentTable.Where(s => s.Email.Equals(studentEmail, StringComparison.InvariantCulture)).ToArray();
                                table.StudentTable.Delete(studentEmail);
                                result[0].Email = newEmail;
                                table.StudentTable.Insert(studentEmail, result[0]);

                                // Update into DB
                                context.Students.Where(s => s.Email == studentEmail).ExecuteUpdate(setters => setters.SetProperty(s => s.Email, newEmail));
                                MessageBox.Show("Email updated successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                inputUpdate.Text = "";
                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show($"Processing failed: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    errorLabel.Text = "Format should be in the form John.Doe@example.com";
                    errorLabel.Show();
                }
            }
            else
            {
                errorLabel.Text = "Email can't be empty";
                errorLabel.Show();

            }
        }

        public static bool CheckStudentEmailExistence(string email)
        {
            // Connect with Database
            var success = false;
            try
            {
                using (var context = new DrivingLessonBookingSystemContext())
                {
                    success = context.Students.Any(s => s.Email == email);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Processing failed: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return success;
        }
    }
}

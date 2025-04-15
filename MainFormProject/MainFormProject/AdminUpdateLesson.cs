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
                    UpdateStudentFirstName();
                    break;
                case "Student last name":
                    UpdateStudentLastName();
                    break;
                case "Student email":
                    UpdateStudentEmail();
                    break;
                case "Instructor first name":
                    UpdateInstructorFirstName();
                    break;
                case "Instructor last name":
                    UpdateInstructorLastName();
                    break;
                case "Instructor email":
                    UpdateInstructorEmail();
                    break;
                case "Car transmission":
                    UpdateTransmission();
                    break;
                case "Lesson date":
                    UpdateDate();
                    break;
            }
        }

        public void UpdateStudentFirstName()
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

        public void UpdateStudentLastName()
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

        public void UpdateStudentEmail()
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
                                studentEmail=newEmail;
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

        public void UpdateInstructorFirstName()
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
                        var result = table.InstructorTable.Where(i => i.Email.Equals(instructorEmail, StringComparison.InvariantCulture)).ToArray();
                        table.InstructorTable.Delete(instructorEmail);
                        result[0].FirstName = firstName;
                        table.InstructorTable.Insert(instructorEmail, result[0]);

                        context.Instructors.Where(i => i.Email == instructorEmail).ExecuteUpdate(setters => setters.SetProperty(i => i.FirstName, firstName));
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

        public void UpdateInstructorLastName()
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
                        var result = table.InstructorTable.Where(i => i.Email.Equals(instructorEmail, StringComparison.InvariantCulture)).ToArray();
                        table.InstructorTable.Delete(instructorEmail);
                        result[0].LastName = lastName;
                        table.InstructorTable.Insert(instructorEmail, result[0]);

                        context.Instructors.Where(i => i.Email == instructorEmail).ExecuteUpdate(setters => setters.SetProperty(i => i.LastName, lastName));
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

        public void UpdateInstructorEmail()
        {
            string newEmail = inputUpdate.Text;
            if (Validations.ValidateString(newEmail))
            {
                if (Validations.ValidateEmail(newEmail))
                {
                    if (!CheckInstructorEmailExistence(newEmail))
                    {
                        try
                        {
                            var table = new OfflineDatabase();
                            table.LoadTables();
                            using (var context = new DrivingLessonBookingSystemContext())
                            {
                                // Update into HashTable
                                var result = table.InstructorTable.Where(i => i.Email.Equals(instructorEmail, StringComparison.InvariantCulture)).ToArray();
                                table.InstructorTable.Delete(instructorEmail);
                                result[0].Email = newEmail;
                                table.InstructorTable.Insert(instructorEmail, result[0]);

                                // Update into DB
                                context.Instructors.Where(i => i.Email == instructorEmail).ExecuteUpdate(setters => setters.SetProperty(i => i.Email, newEmail));
                                MessageBox.Show("Email updated successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                instructorEmail = newEmail;
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

        public void UpdateTransmission()
        {
            string transmission = inputUpdate.Text;
            errorLabel.Hide();

            if (Validations.ValidateString(transmission))
            {
                if (TransmissionChecker(transmission))
                {
                    try
                    {
                        var table = new OfflineDatabase();
                        table.LoadTables();
                        using (var context = new DrivingLessonBookingSystemContext())
                        {
                            // Update into HashTable
                            var result = table.CarTable.Where(c => c.RegistrationNumber.Equals(regNo, StringComparison.InvariantCulture)).ToArray();
                            table.CarTable.Delete(regNo);
                            result[0].Transmission = transmission;
                            table.CarTable.Insert(regNo, result[0]);

                            context.Cars.Where(c => c.RegistrationNumber == regNo)
                                .ExecuteUpdate(setters => setters.SetProperty(c => c.Transmission, transmission));
                            MessageBox.Show("Transmission updated successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"Processing failed: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    errorLabel.Text = "Transmission should be either be automatic or manual";
                    errorLabel.Show();
                }
            }
            else
            {
                errorLabel.Text = "Transmission can't be empty";
                errorLabel.Show();
            }
        }

        private void UpdateDate()
        {
            string date = inputUpdate.Text;
            DateOnly lessonDate;

            if (Validations.ValidateString(date))
            {
                if (Validations.ValidateDate(date))
                {
                    DateOnly.TryParse(date, out lessonDate);
                    try
                    {
                        var table = new OfflineDatabase();
                        table.LoadTables();
                        using (var context = new DrivingLessonBookingSystemContext())
                        {

                            // Update in DB
                            context.Lessons.Where(l => l.LessonId == lessonId).ExecuteUpdate(setters => setters.SetProperty(l => l.Date, lessonDate));
                            MessageBox.Show("Lesson Date updated successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            inputUpdate.Text = "";
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"Processing failed: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    errorLabel.Text = "Please use the format yyyy/MM/dd.";
                    errorLabel.Show();
                }
            }
            else
            {
                errorLabel.Text = "Date can't be empty, please re-input.";
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

        public static bool CheckInstructorEmailExistence(string email)
        {
            // Connect with Database
            var success = false;
            try
            {
                using (var context = new DrivingLessonBookingSystemContext())
                {
                    success = context.Instructors.Any(i => i.Email == email);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Processing failed: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return success;
        }

        public static bool TransmissionChecker(string transmission)
        {
            return transmission.Equals("Automatic", StringComparison.InvariantCultureIgnoreCase) ||
                   transmission.Equals("Manual", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}

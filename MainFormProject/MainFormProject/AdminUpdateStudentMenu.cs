using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainFormProject.Context;
using MainFormProject.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MainFormProject
{
    public partial class AdminUpdateStudentMenu : Form
    {
        private string email;
        public AdminUpdateStudentMenu(string newEmail)
        {
            InitializeComponent();
            email = newEmail;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            AdminUpdateStudents updateInput = new AdminUpdateStudents();

            this.Close();

            updateInput.Show();
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
                case "First name":
                    UpdateFirstName();
                    break;
                case "Last name":
                    UpdateLastName();
                    break;
                case "Email":
                    UpdateEmail();
                    break;
                case "Password":
                    UpdatePassword();
                    break;
                case "Date of birth":
                    UpdateDateOfBirth();
                    break;
                case "Address":
                    UpdateAddress();
                    break;
                case "Phone number":
                    UpdatePhoneNumber();
                    break;
            }
        }

        public void UpdateFirstName()
        {
            string firstName=inputUpdate.Text;

                if (!Validations.ValidateString(firstName))
                {
                    errorLabel.Text="First name can't be empty";
                    errorLabel.Show();
                } else
                {
                    try
                    {
                        var table = new OfflineDatabase();
                        table.LoadTables();
                        using (var context = new DrivingLessonBookingSystemContext())
                        {
                            // Update into HashTable
                            var result = table.StudentTable.Where(s => s.Email.Equals(email, StringComparison.InvariantCulture)).ToArray();
                            table.StudentTable.Delete(email);
                            result[0].FirstName = firstName;
                            table.StudentTable.Insert(email, result[0]);

                            context.Students.Where(s => s.Email == email).ExecuteUpdate(setters => setters.SetProperty(s => s.FirstName, firstName));
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
                        var result = table.StudentTable.Where(s => s.Email.Equals(email, StringComparison.InvariantCulture)).ToArray();
                        table.StudentTable.Delete(email);
                        result[0].LastName = lastName;
                        table.StudentTable.Insert(email, result[0]);

                        context.Students.Where(s => s.Email == email).ExecuteUpdate(setters => setters.SetProperty(s => s.LastName, lastName));
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
            string newEmail= inputUpdate.Text;
            if (Validations.ValidateString(newEmail))
            {
                if (Validations.ValidateEmail(newEmail))
                {
                    if (!CheckEmailExistence(newEmail))
                    {
                        try
                        {
                            var table = new OfflineDatabase();
                            table.LoadTables();
                            using (var context = new DrivingLessonBookingSystemContext())
                            {
                                // Update into HashTable
                                var result = table.StudentTable.Where(s => s.Email.Equals(email, StringComparison.InvariantCulture)).ToArray();
                                table.StudentTable.Delete(email);
                                result[0].Email = newEmail;
                                table.StudentTable.Insert(email, result[0]);

                                // Update into DB
                                context.Students.Where(s => s.Email == email).ExecuteUpdate(setters => setters.SetProperty(s => s.Email, newEmail));
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


        private void UpdatePassword()
        {
            string password=inputUpdate.Text;
            if (Validations.ValidateString(password))
            {
                if (Validations.ValidatePassword(password))
                {
                    try
                    {
                        var table = new OfflineDatabase();
                        table.LoadTables();
                        using (var context = new DrivingLessonBookingSystemContext())
                        {
                            // Update into HashTable
                            var result = table.StudentTable.Where(s => s.Email.Equals(email, StringComparison.InvariantCulture)).ToArray();
                            table.StudentTable.Delete(email);
                            result[0].Password = password;
                            table.StudentTable.Insert(email, result[0]);

                            // Update into DB
                            context.Students.Where(s => s.Email == email).ExecuteUpdate(setters => setters.SetProperty(s => s.Password, password));
                            MessageBox.Show("Password updated successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            inputUpdate.Text = "";
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"Processing failed: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                } else
                {
                    errorLabel.Text = "Invalid password";
                    errorLabel.Show();
                }
            }
            else
            {
                errorLabel.Text="Password can't be empty";
                errorLabel.Show();
            }
        }

        private void UpdateDateOfBirth()
        {
            string date = inputUpdate.Text;
            DateOnly dateOfBirth;

            if (Validations.ValidateString(date))
            {
                if (Validations.ValidateDate(date))
                {
                    DateOnly.TryParse(date, out dateOfBirth);
                    try
                    {
                        var table = new OfflineDatabase();
                        table.LoadTables();
                        using (var context = new DrivingLessonBookingSystemContext())
                        {
                            // Update into HashTable
                            var result = table.StudentTable.Where(s => s.Email.Equals(email, StringComparison.InvariantCulture)).ToArray();
                            table.StudentTable.Delete(email);
                            result[0].DateOfBirth = dateOfBirth;
                            table.StudentTable.Insert(email, result[0]);

                            // Update in DB
                            context.Students.Where(s => s.Email == email).ExecuteUpdate(setters => setters.SetProperty(s => s.DateOfBirth, dateOfBirth));
                            MessageBox.Show("Date of birth updated successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            inputUpdate.Text = "";
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"Processing failed: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                } else
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


        private void UpdateAddress()
        {
            string address=inputUpdate.Text;

            if (Validations.ValidateString(address))
            {
                try
                {
                    var table = new OfflineDatabase();
                    table.LoadTables();
                    using (var context = new DrivingLessonBookingSystemContext())
                    {
                        // Update into HashTable
                        var result = table.StudentTable.Where(s => s.Email.Equals(email, StringComparison.InvariantCulture)).ToArray();
                        table.StudentTable.Delete(email);
                        result[0].Address = address;
                        table.StudentTable.Insert(email, result[0]);

                        // Update in DB
                        context.Students.Where(s => s.Email == email).ExecuteUpdate(setters => setters.SetProperty(s => s.Address, address));
                        MessageBox.Show("Address updated successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                errorLabel.Text = "Address can't be empty, please re-input.";
                errorLabel.Show();
            }

        }

        private void UpdatePhoneNumber()
        {
            string phoneNumber = inputUpdate.Text;

            if (Validations.ValidateString(phoneNumber))
            {
                if (Validations.ValidatePhoneNumber(phoneNumber))
                {
                    try
                    {
                        var table = new OfflineDatabase();
                        table.LoadTables();
                        using (var context = new DrivingLessonBookingSystemContext())
                        {
                            // Update into HashTable
                            var result = table.StudentTable.Where(s => s.Email.Equals(email, StringComparison.InvariantCulture)).ToArray();
                            table.StudentTable.Delete(email);
                            result[0].PhoneNumber = phoneNumber;
                            table.StudentTable.Insert(email, result[0]);

                            // Update into DB
                            context.Students.Where(s => s.Email == email).ExecuteUpdate(setters => setters.SetProperty(s => s.PhoneNumber, phoneNumber));
                            MessageBox.Show("Phone number updated successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    errorLabel.Text = "Phone number should be in the format (+230)58226843";
                    errorLabel.Show();
                }

            }
            else
            {
                errorLabel.Text="Phone number can't be empty, please re-input.";
                errorLabel.Show();
            }
        }

        public static bool CheckEmailExistence(string email)
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

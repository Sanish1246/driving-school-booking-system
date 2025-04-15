using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainFormProject;
using MainFormProject.Context;

namespace MainFormProject
{
    public partial class AdminLogin : Form
    {
        private string loginType;
        public AdminLogin(string loginType)
        {
            this.loginType=loginType;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool valid = true;
            string username = Email.Text;
            string email=Email.Text;
            string password = Password.Text;


            emailError.Hide();
            passwordError.Hide();
            if (this.loginType == "admin")
            {
                if (Validations.ValidateString(username))
                {
                    if (!(username.ToLower().Equals("root", StringComparison.InvariantCulture)))
                    {
                        emailError.Text = "Wrong username entered, please re-input.";
                        valid = false;
                        emailError.Show();
                    }
                }
                else
                {
                    emailError.Text = "Username can't be empty.";
                    valid = false;
                    emailError.Show();
                }

                if (Validations.ValidateString(password))
                {
                    if (!(password.ToLower().Equals("root", StringComparison.InvariantCulture)))
                    {
                        passwordError.Text = "Wrong password entered, please re-input.";
                        valid = false;
                        passwordError.Show();
                    }

                }
                else
                {
                    passwordError.Text = "Password can't be empty.";
                    valid = false;
                    passwordError.Show();
                }


                if (valid)
                {
                    AdminMenu adminMenu = new AdminMenu();

                    adminMenu.Show();

                    this.Close();
                }
            } else if (this.loginType == "student")
            {
                if (Validations.ValidateString(email))
                {
                    if (Validations.ValidateEmail(email))
                    {
                        if (!CheckStudentEmailExistence(email))
                        {
                            emailError.Text = "Email doesn't exist";
                            emailError.Show();
                            valid = false;
                        }
                    }
                    else
                    {
                        emailError.Text = "Format should be in the form John.Doe@example.com";
                        emailError.Show();
                        valid = false;
                    }
                }
                else
                {
                    emailError.Text = "Email can't be empty";
                    emailError.Show();
                    valid = false;
                }

                if (valid) {
                    if (!Validations.ValidateString(password))
                    {
                        passwordError.Text = "Password can't be empty";
                        passwordError.Show();
                        valid = false;
                    } else
                    {
                        // check if password entered matches the one for particular user in the database
                        try
                        {
                            using (var context = new DrivingLessonBookingSystemContext())
                            {
                                var student = context.Students.Where(s => s.Email == email).ToList();
                                if (student[0].Password == password)
                                {
                                    // password is valid
                                    valid = true;
                                }
                                else
                                {
                                    passwordError.Text = "Incorrect Password entered";
                                    passwordError.Show();
                                    valid = false;
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Processing failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
            }


                if (valid)
                {
                    StudentMenu studentMenu = new StudentMenu(email);

                    this.Close();

                    studentMenu.Show();  
                }
            } else
            {
                if (Validations.ValidateString(email))
                {
                    if (Validations.ValidateEmail(email))
                    {
                        if (!CheckInstructorEmailExistence(email))
                        {
                            emailError.Text = "Email doesn't exist";
                            emailError.Show();
                            valid = false;
                        }
                    }
                    else
                    {
                        emailError.Text = "Format should be in the form John.Doe@example.com";
                        emailError.Show();
                        valid = false;
                    }
                }
                else
                {
                    emailError.Text = "Email can't be empty";
                    emailError.Show();
                    valid = false;
                }

                if (valid)
                {
                    if (!Validations.ValidateString(password))
                    {
                        passwordError.Text = "Password can't be empty";
                        passwordError.Show();
                        valid = false;
                    }
                    else
                    {
                        // check if password entered matches the one for particular user in the database
                        try
                        {
                            using (var context = new DrivingLessonBookingSystemContext())
                            {
                                var instructor = context.Instructors.Where(i => i.Email == email).ToList();
                                if (instructor[0].Password == password)
                                {
                                    // password is valid
                                    valid = true;
                                }
                                else
                                {
                                    passwordError.Text = "Incorrect Password entered";
                                    passwordError.Show();
                                    valid = false;
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Processing failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                if (valid)
                {
                    InstructorMenu instructorMenu = new InstructorMenu(email);

                    instructorMenu.Show();

                    this.Close();
                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            LoginChoice loginChoice = new LoginChoice();

            this.Close();

            loginChoice.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}

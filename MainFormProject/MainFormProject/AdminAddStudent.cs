using System.Globalization;
using MainFormProject.Context;
using MainFormProject.Models;

namespace MainFormProject
{
    public partial class AdminAddStudent : Form
    {
        public AdminAddStudent()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            StudentHandler studentHandlerMenu = new StudentHandler();

            this.Close();

            studentHandlerMenu.Show();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            bool valid = true;
            string firstName = FirstName.Text;
            string lastName= LastName.Text;
            string email= Email.Text;
            string password = Password.Text;
            string dob = DOB.Value.ToString("yyyy/MM/dd");
            DateOnly newDob = DateOnly.ParseExact(dob, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            string address = Address.Text;
            string phoneNo = PhoneNum.Text;

            invalidFirst.Hide();
            invalidLast.Hide();
            invalidEmail.Hide();
            invalidPassword.Hide();
            invalidAddress.Hide();
            invalidPhone.Hide();
            
            // Check if entered text is not empty
            if (!Validations.ValidateString(firstName))
            {
                invalidFirst.Show();
                valid = false;
            }

            if (!Validations.ValidateString(lastName))
            {
                invalidLast.Show();
                valid = false;
            }

            if (Validations.ValidateString(email))
            {

                // Check the email format
                if (Validations.ValidateEmail(email))
                {
                    // Check if email is already present in database; emails should be unique
                    if (CheckEmailExistence(email))
                    {
                        invalidEmail.Text = "Email already exists, please choose another one.";
                        valid = false;
                        invalidEmail.Show();
                    }
                }
                else
                {
                    invalidEmail.Text = "format should be in the form John.Doe@example.com";
                    valid = false;
                    invalidEmail.Show();
                }
            }
            else
            {
                invalidEmail.Text="Email can't be empty";
                valid = false;
                invalidEmail.Show();

            }
            
            // Check password strength
            if (Validations.ValidateString(password))
            {
                if (!Validations.ValidatePassword(password))
                {
                    invalidPassword.Show();
                    valid = false;
                }
            }
            else
            {
                invalidPassword.Show();
                valid = false;
            }

            if (Validations.ValidateString(phoneNo))
            {
                if (!Validations.ValidatePhoneNumber(phoneNo))
                {
                    invalidPhone.Text = "number should be in the format(+230)58226843";
                    valid = false;
                    invalidPhone.Show();
                }
            }
            else
            {
                invalidPhone.Text="Phone number can't be empty";
                valid = false;
                invalidPhone.Show();
            }

            if (!Validations.ValidateString(address))
            {
                invalidAddress.Show();
                valid = false;
            }

            if (valid)
            {
                try
                {
                    var table = new OfflineDatabase();
                    using (var context = new DrivingLessonBookingSystemContext())
                    {
                        // Add new student
                        var student = new Student
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            Address = address,
                            Email = email,
                            DateOfBirth = newDob,
                            Password = password,
                            PhoneNumber = phoneNo
                        };
                        // Add student to hash table
                        table.StudentTable.Insert(email, student);

                        context.Students.Add(student);
                        context.SaveChanges();
                        MessageBox.Show("Student added", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FirstName.Text = "";
                        LastName.Text = "";
                        Email.Text = "";
                        Password.Text = "";
                        Address.Text = "";
                        PhoneNum.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Processing failed {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }


        }


        public static bool CheckEmailExistence(string email)
        {
            var success = false;
            try
            {
                using (var context = new DrivingLessonBookingSystemContext())
                {
                    // Check email uniqueness
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

using MainFormProject.Context;
using Microsoft.EntityFrameworkCore;

namespace MainFormProject
{
    public partial class AdminDeleteInstructor : Form
    {
        public AdminDeleteInstructor()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            InstructorHandler instructorHandlerMenu = new InstructorHandler();

            this.Close();

            instructorHandlerMenu.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string email = Email.Text;
            emailError.Hide();
            
            // Check if email is empty
            if (Validations.ValidateString(email))
            {
                // Check if email format is correct
                if (Validations.ValidateEmail(email))
                {
                    // Check if email is unique
                    if (!CheckEmailExistence(email))
                    {
                        emailError.Text = "Email doesn't exist";
                        emailError.Show();
                    }
                    else
                    {
                        try
                        {
                            // Load data from Hash Table
                            var table = new OfflineDatabase();
                            table.LoadTables();
                            using (var context = new DrivingLessonBookingSystemContext())
                            {
                                // Delete user in hash table
                                table.InstructorTable.Delete(email);

                                context.Instructors.Where(i => i.Email == email).ExecuteDelete();
                                MessageBox.Show("Instructor deleted successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Email.Text = "";
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Processing failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    emailError.Text = "Format should be in the form John.Doe@example.com";
                    emailError.Show();
                }
            }
            else
            {
                emailError.Text = "Email can't be empty";
                emailError.Show();
            }
        }

        public static bool CheckEmailExistence(string email)
        {
            var success = false;
            try
            {
                using (var context = new DrivingLessonBookingSystemContext())
                {
                    // Check if email is unique
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

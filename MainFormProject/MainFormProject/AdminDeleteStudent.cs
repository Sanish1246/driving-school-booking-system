using MainFormProject.Context;
using Microsoft.EntityFrameworkCore;

namespace MainFormProject
{
    public partial class AdminDeleteStudent : Form
    {
        public AdminDeleteStudent()
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

            studentHandlerMenu.Show();

            this.Close();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string email = Email.Text;
            emailError.Hide();

            if (Validations.ValidateString(email))
            {
                if (Validations.ValidateEmail(email))
                {
                    if (!CheckEmailExistence(email))
                    {
                        emailError.Text = "Email doesn't exist";
                        emailError.Show();
                    } else
                    {
                        try
                        {
                            var table = new OfflineDatabase();
                            table.LoadTables();
                            using (var context = new DrivingLessonBookingSystemContext())
                            {
                                // Delete user in hash table
                                table.StudentTable.Delete(email);

                                context.Students.Where(s => s.Email == email).ExecuteDelete();
                                MessageBox.Show("Student deleted successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    emailError.Text="Format should be in the form John.Doe@example.com";
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

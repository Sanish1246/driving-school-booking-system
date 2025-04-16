using System.Text.RegularExpressions;
using MainFormProject.Context;
using Microsoft.EntityFrameworkCore;

namespace MainFormProject
{
    public partial class AdminDeleteCar : Form
    {
        public AdminDeleteCar()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            CarHandler carMenu = new CarHandler();

            this.Close();

            carMenu.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string regNo = registrationNo.Text;
            invalidRegNo.Hide();
            // Check if car registration number is empty
            if (Validations.ValidateString(regNo))
            {
                // Check if car registration number is in the correct format
                if (CarRegistrationChecker(regNo))
                {
                    // Check if car registration number is unique
                    if (!IsUnique(regNo))
                    {
                        try
                        {
                            // Load data from hash table
                            var table = new OfflineDatabase();
                            table.LoadTables();
                            using (var context = new DrivingLessonBookingSystemContext())
                            {
                                // Delete car in hash table
                                table.CarTable.Delete(regNo);

                                context.Cars.Where(c => c.RegistrationNumber == regNo).ExecuteDelete();
                                MessageBox.Show("Car deleted successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Processing failed {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    } else
                    {
                        invalidRegNo.Text = "This registration number does not exist";
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
            // Verify if car registration format is valid
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
                    // Check if car registration number is unique
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

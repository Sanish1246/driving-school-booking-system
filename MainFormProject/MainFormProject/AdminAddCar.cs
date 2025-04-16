using MainFormProject.Context;
using MainFormProject.Models;
using System.Text.RegularExpressions;

namespace MainFormProject
{
    public partial class AdminAddCar : Form
    {
        public AdminAddCar()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            CarHandler carMenu = new CarHandler();

            this.Close();
            
            // Display car menu for CRUD Operations
            carMenu.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            bool valid = true;
            string make = Make.Text;
            string transmission = Transmission.Text;
            string regNo = RegistrationNo.Text;

            invalidMake.Hide();
            invalidTransmission.Hide();
            invalidRegNo.Hide();

            if (!Validations.ValidateString(make))
            {
                invalidMake.Show();
                valid = false;
            }

            if (Validations.ValidateString(transmission))
            {
                // Transmission can either be automatic or manual
                if (!TransmissionChecker(transmission))
                {
                    invalidTransmission.Text = "Transmission can either be automatic or manual";
                    invalidTransmission.Show();
                    valid = false;
                }
            }
            else
            {
                invalidTransmission.Text = "Transmission can't be empty";
                invalidTransmission.Show();
                valid = false;
            }
            
            // Check if car registration number isn't empty
            if (Validations.ValidateString(regNo))
            {
                // Check if car registration number matches required format
                if (CarRegistrationChecker(regNo))
                {
                    // Check if car registration number is unique
                    if (!IsUnique(regNo))
                    {
                        invalidRegNo.Text = "Registration number already taken";
                        invalidRegNo.Show();
                        valid = false;
                    } 
                }
                else
                {
                    invalidRegNo.Text = "Invalid format";
                    invalidRegNo.Show();
                    valid = false;
                }
            }
            else
            {
                invalidRegNo.Text = "Registration number can't be empty";
                invalidRegNo.Show();
                valid = false;
            }

            if (valid)
            {
                try
                {
                    // Load Hash Table with data
                    var table = new OfflineDatabase();
                    table.LoadTables();
                    using (var context = new DrivingLessonBookingSystemContext())
                    {
                        var car = new Car()
                        {
                            Make = make,
                            Transmission = transmission,
                            RegistrationNumber = Validations.RemoveWhiteSpaces(regNo.ToUpper())
                        };
                        // Add car to hash table
                        table.CarTable.Insert(regNo, car);

                        context.Cars.Add(car);
                        context.SaveChanges();
                        MessageBox.Show("Car added successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Make.Text = "";
                        Transmission.Text = "";
                        RegistrationNo.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Processing failed {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        public static bool TransmissionChecker(string transmission)
        {
            // Check if car is either automatic or manual
            return transmission.Equals("Automatic", StringComparison.InvariantCultureIgnoreCase) ||
                   transmission.Equals("Manual", StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool CarRegistrationChecker(string registrationNumber)
        {
            // Check if car registration number format is valid
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

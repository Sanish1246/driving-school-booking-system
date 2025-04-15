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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace MainFormProject
{
    public partial class AdminUpdateCarMenu : Form
    {
        private string regNo;
        public AdminUpdateCarMenu(string newRegNo)
        {
            InitializeComponent();
            regNo = newRegNo;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            AdminUpdateCar updateCar = new AdminUpdateCar();

            this.Close();

            updateCar.Show();
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
                case "Make":
                    UpdateMake();
                    break;
                case "Transmission":
                    UpdateTransmission();
                    break;
                case "Registration Number":
                    UpdateRegNo();
                    break;
            }
        }

        public void UpdateMake()
        {
            string make=inputUpdate.Text;
            errorLabel.Hide();

            if (Validations.ValidateString(make))
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
                        result[0].Make = make;
                        table.CarTable.Insert(regNo, result[0]);

                        context.Cars.Where(c => c.RegistrationNumber == regNo)
                            .ExecuteUpdate(setters => setters.SetProperty(c => c.Make, make));
                        MessageBox.Show("Make updated successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Processing failed: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                errorLabel.Text = "Make can't be empty";
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
                } else
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

        public void UpdateRegNo()
        {
            string newRegNo = inputUpdate.Text;
            errorLabel.Hide();


            if (Validations.ValidateString(newRegNo))
            {
                if (CarRegistrationChecker(newRegNo))
                {
                    if (IsUnique(newRegNo))
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
                                result[0].RegistrationNumber = regNo;
                                table.CarTable.Insert(regNo, result[0]);

                                context.Cars.Where(c => c.RegistrationNumber == regNo).ExecuteUpdate(
                                    setters => setters.SetProperty(c => c.RegistrationNumber, newRegNo.ToUpper()));
                                MessageBox.Show("Registration Number updated successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                regNo = newRegNo;
                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show($"Processing failed: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        errorLabel.Text = "Registration number is already taken, please re-input.";
                        errorLabel.Show();
                    }
                }
                else
                {
                    errorLabel.Text = "Invalid registration number format";
                    errorLabel.Show();
                }
            }
            else
            {
                errorLabel.Text = "Registration number can't be empty";
                errorLabel.Show();
            }
        }

        public static bool TransmissionChecker(string transmission)
        {
            return transmission.Equals("Automatic", StringComparison.InvariantCultureIgnoreCase) ||
                   transmission.Equals("Manual", StringComparison.InvariantCultureIgnoreCase);
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

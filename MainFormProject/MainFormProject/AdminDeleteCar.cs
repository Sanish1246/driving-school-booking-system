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
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            if (Validations.ValidateString(regNo))
            {
                if (CarRegistrationChecker(regNo))
                {
                    if (!IsUnique(regNo))
                    {
                        try
                        {
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

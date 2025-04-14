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

namespace MainFormProject
{
    public partial class AdminUpdateStudents : Form
    {
        public AdminUpdateStudents()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            StudentHandler studentHandlerMenu = new StudentHandler();

            this.Close();

            studentHandlerMenu.Show();
            
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
                        this.Close();

                        AdminUpdateStudentMenu updateMenu = new AdminUpdateStudentMenu(email);

                        updateMenu.Show();
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

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainFormProject.Context;

namespace MainFormProject
{
    public partial class AdminSearchStudent : Form
    {
        public AdminSearchStudent()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            StudentHandler studentHandlerMenu = new StudentHandler();

            this.Close();

            studentHandlerMenu.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string email = Email.Text;
            studentDetails.Text = "";
            emailError.Hide();

            if (Validations.ValidateString(email))
            {
                if (Validations.ValidateEmail(email))
                {
                    if (!CheckEmailExistence(email))
                    {
                        emailError.Text = "Email doesn't exist";
                        emailError.Show();
                    }
                    else
                    {
                        try
                        {
                            using (var context = new DrivingLessonBookingSystemContext())
                            {
                                var students = context.Students.Where(s => s.Email == email);
                                foreach (var student in students)
                                {
                                    studentDetails.Text=$"Student found with details:\n{student}";
                                }
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

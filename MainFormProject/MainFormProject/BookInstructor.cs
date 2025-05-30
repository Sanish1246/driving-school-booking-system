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
using MainFormProject.Models;
using Microsoft.EntityFrameworkCore;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace MainFormProject
{
    public partial class BookInstructor : Form
    {
        private string email;
        public BookInstructor(string newEmail)
        {
            InitializeComponent();
            email = newEmail;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            StudentMenu studentMenu = new StudentMenu(email);

            this.Close();

            studentMenu.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void BookInstructor_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            listView1.Columns.Clear();
            listView1.Columns.Add("First Name", 100);
            listView1.Columns.Add("Last Name", 100);
            listView1.Columns.Add("Email", 150);
            listView1.Columns.Add("Password", 100);
            listView1.Columns.Add("Date of Birth", 100);
            listView1.Columns.Add("Address", 200);
            listView1.Columns.Add("Phone", 100);

            try
            {
                using (var context = new DrivingLessonBookingSystemContext())
                {
                    var instructors = context.Instructors.AsNoTracking().ToList();

                    listView1.Items.Clear(); //Clear old data

                    foreach (var instructor in instructors)
                    {
                        var item = new ListViewItem(instructor.FirstName ?? "");
                        item.SubItems.Add(instructor.LastName ?? "");
                        item.SubItems.Add(instructor.Email ?? "");
                        item.SubItems.Add(instructor.Password ?? "");
                        item.SubItems.Add(instructor.DateOfBirth.ToShortDateString());
                        item.SubItems.Add(instructor.Address ?? "");
                        item.SubItems.Add(instructor.PhoneNumber ?? "");

                        listView1.Items.Add(item);
                    }

                    // Adapt columns
                    listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Processing failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string instructorEmail = InstructorEmail.Text;
            emailError.Hide();

            if (Validations.ValidateString(instructorEmail))
            {
                if (Validations.ValidateEmail(instructorEmail))
                {
                    if (!CheckEmailExistence(instructorEmail))
                    {
                        emailError.Text = "Email doesn't exist";
                        emailError.Show();
                    }
                    else
                    {
                        BookCar bookCar = new BookCar(email,instructorEmail);

                        bookCar.Show();

                        this.Close();
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

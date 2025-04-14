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
    public partial class AdminListStudent : Form
    {
        public AdminListStudent()
        {
            InitializeComponent();
        }

        private void AdminListStudent_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details; // assicurati che sia in modalità "Details"
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
                    var students = context.Students.AsNoTracking().ToList();

                    listView1.Items.Clear(); //Clear old data

                    foreach (var student in students)
                    {
                        var item = new ListViewItem(student.FirstName ?? "");
                        item.SubItems.Add(student.LastName ?? "");
                        item.SubItems.Add(student.Email ?? "");
                        item.SubItems.Add(student.Password ?? "");
                        item.SubItems.Add(student.DateOfBirth.ToShortDateString());
                        item.SubItems.Add(student.Address ?? "");
                        item.SubItems.Add(student.PhoneNumber ?? "");

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


    }
}

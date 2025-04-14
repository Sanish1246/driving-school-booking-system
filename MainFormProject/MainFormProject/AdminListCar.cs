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
    public partial class AdminListCar : Form
    {
        public AdminListCar()
        {
            InitializeComponent();
        }

        private void AdminListCar_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            listView1.Columns.Clear();
            listView1.Columns.Add("Make", 500);
            listView1.Columns.Add("Transmission", 1000);
            listView1.Columns.Add("Registration No", 1000);

            try
            {
                using (var context = new DrivingLessonBookingSystemContext())
                {
                    var cars = context.Cars.AsNoTracking().ToList();

                    listView1.Items.Clear(); //Clear old data

                    foreach (var car in cars)
                    {
                        var item = new ListViewItem(car.Make ?? "");
                        item.SubItems.Add(car.Transmission ?? "");
                        item.SubItems.Add(car.RegistrationNumber ?? "");

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
            CarHandler carHandler = new CarHandler();

            this.Close();

            carHandler.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainFormProject
{
    public partial class AdminSearchCar : Form
    {
        public AdminSearchCar()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Car found", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

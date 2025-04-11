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
            MessageBox.Show("Car deleted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

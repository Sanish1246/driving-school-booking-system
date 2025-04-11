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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool valid = true;
            string adminUsername = textBox1.Text;
            string adminPassword = textBox2.Text;


            label5.Hide();
            label6.Hide();
            if (adminUsername == "")
            {
                label5.Show();
                valid = false;
                textBox1.Text = "";
            }

            if (adminPassword == "")
            {
                label6.Show();
                valid = false;
                textBox2.Text = "";
            }


            if (valid)
            {
                AdminMenu adminMenu = new AdminMenu();

                adminMenu.Show();

                this.Close();
            }
        }
    }
}

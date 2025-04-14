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
        private string loginType;
        public AdminLogin(string loginType)
        {
            this.loginType=loginType;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool valid = true;
            string username = textBox1.Text;
            string email=textBox1.Text;
            string password = textBox2.Text;


            label5.Hide();
            label6.Hide();
            if (this.loginType == "admin")
            {
                if (username != "root")
                {
                    label5.Show();
                    valid = false;
                    textBox1.Text = "";
                }

                if (password != "root")
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
            } else if (this.loginType == "student")
            {
                if (email == "")
                {
                    label5.Show();
                    valid = false;
                    textBox1.Text = "";
                }

                if (password == "")
                {
                    label6.Show();
                    valid = false;
                    textBox2.Text = "";
                }


                if (valid)
                {
                    StudentMenu studentMenu = new StudentMenu();

                    this.Close();

                    studentMenu.Show();  
                }
            } else
            {
                if (email == "")
                {
                    label5.Show();
                    valid = false;
                    textBox1.Text = "";
                }

                if (password == "")
                {
                    label6.Show();
                    valid = false;
                    textBox2.Text = "";
                }

                if (valid)
                {
                    InstructorMenu instructorMenu = new InstructorMenu();

                    instructorMenu.Show();

                    this.Close();
                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            LoginChoice loginChoice = new LoginChoice();

            this.Close();

            loginChoice.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

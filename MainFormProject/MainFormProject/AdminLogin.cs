using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainFormProject;

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
                if (Validations.ValidateString(username))
                {
                    if (!(username.ToLower().Equals("root", StringComparison.InvariantCulture)))
                    {
                        label5.Text = "Wrong username entered, please re-input.";
                        valid = false;
                        label5.Show();
                    }
                }
                else
                {
                    label5.Text = "Username can't be empty.";
                    valid = false;
                    label5.Show();
                }

                if (Validations.ValidateString(password))
                {
                    if (!(password.ToLower().Equals("root", StringComparison.InvariantCulture)))
                    {
                        label6.Text = "Wrong password entered, please re-input.";
                        valid = false;
                        label6.Show();
                    }

                }
                else
                {
                    label6.Text = "Password can't be empty.";
                    valid = false;
                    label6.Show();
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

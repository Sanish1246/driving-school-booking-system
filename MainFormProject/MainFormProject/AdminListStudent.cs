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
    public partial class AdminListStudent : Form
    {
        public AdminListStudent()
        {
            InitializeComponent();
        }

        private void AdminListStudent_Load(object sender, EventArgs e)
        {
            string[] names = new string[]
            {
        "Alice",
        "Bob",
        "Clara",
        "David",
        "Ella",
        "Frank",
        "Grace",
        "Henry",
        "Isla",
        "Jack"
            };

            Array.Sort(names); // Ordina alfabeticamente

            foreach (string name in names)
            {
                firstNames.Items.Add(name);
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

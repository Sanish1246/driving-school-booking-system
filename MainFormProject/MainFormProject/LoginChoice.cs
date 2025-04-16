namespace MainFormProject
{
    public partial class LoginChoice : Form
    {
        public LoginChoice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminLogin loginForm = new AdminLogin("admin");

            this.Close();
            
            // Display login to log as admin/student/instructor
            loginForm.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminLogin loginForm = new AdminLogin("student");

            this.Close();
            
            // Display student menu
            loginForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminLogin loginForm = new AdminLogin("instructor");

            this.Close();
            
            // Display instructor menu
            loginForm.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

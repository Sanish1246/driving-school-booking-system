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

            loginForm.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminLogin loginForm = new AdminLogin("student");

            this.Close();

            loginForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminLogin loginForm = new AdminLogin("instructor");

            this.Close();

            loginForm.Show();
        }
    }
}

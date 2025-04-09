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
            AdminLogin adminLoginForm = new AdminLogin();

            adminLoginForm.Show();

            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

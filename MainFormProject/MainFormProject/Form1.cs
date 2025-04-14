namespace MainFormProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginChoice loginChoice = new LoginChoice();

            this.Hide();

            loginChoice.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void skipButton_Click(object sender, EventArgs e)
        {
            LoginChoice loginChoice = new LoginChoice();

            this.Hide();

            loginChoice.Show();
        }
    }
}

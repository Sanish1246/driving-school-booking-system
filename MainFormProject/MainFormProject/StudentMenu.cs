namespace MainFormProject
{
    public partial class StudentMenu : Form
    {
        private string email;
        public StudentMenu(string newEmail)
        {
            InitializeComponent();
            email = newEmail;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void studentLessonsButton_Click(object sender, EventArgs e)
        {
            AdminListLesson listLesson = new AdminListLesson("student", email);

            this.Close();
            
            // Display lessons for particular student
            listLesson.Show();
        }

        private void bookLessonButton_Click(object sender, EventArgs e)
        {
            BookInstructor bookInstructor = new BookInstructor(email);
            
            // Book a lesson
            bookInstructor.Show();

            this.Close();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            AdminLogin loginMenu = new AdminLogin("student");

            this.Close();

            loginMenu.Show();
        }
    }
}

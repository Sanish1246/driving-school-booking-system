namespace MainFormProject
{
    public partial class LessonHandler : Form
    {
        public LessonHandler()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu();

            this.Close();

            adminMenu.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addLessonButton_Click(object sender, EventArgs e)
        {
            AdminAddLesson addLesson = new AdminAddLesson();

            this.Close();
            
            // Add lesson menu
            addLesson.Show();
        }

        private void deleteLessonButton_Click(object sender, EventArgs e)
        {
            AdminDeleteLesson deleteLesson = new AdminDeleteLesson("delete", "", "", "");

            this.Close();
            
            // Delete lesson
            deleteLesson.Show();
        }

        private void searchLessonButton_Click(object sender, EventArgs e)
        {
            AdminSearchLesson searchLesson = new AdminSearchLesson();

            this.Close();
            
            // Search lesson
            searchLesson.Show();
        }

        private void listLessonButton_Click(object sender, EventArgs e)
        {
            AdminListLesson listLesson = new AdminListLesson("admin", "");

            this.Close();

            listLesson.Show();
        }

        private void updateLessonButton_Click(object sender, EventArgs e)
        {
            AdminDeleteLesson deleteLesson = new AdminDeleteLesson("update", "", "", "");

            this.Close();

            deleteLesson.Show();
        }
    }
}

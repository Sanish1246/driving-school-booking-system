namespace MainFormProject
{
    public partial class CarHandler : Form
    {
        public CarHandler()
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

        private void addCarButton_Click(object sender, EventArgs e)
        {
            AdminAddCar addCar = new AdminAddCar();

            this.Close();
            
            // Add car menu
            addCar.Show();
        }

        private void deleteCarButton_Click(object sender, EventArgs e)
        {
            AdminDeleteCar deleteCar = new AdminDeleteCar();

            this.Close();
            
            // Delete car menu
            deleteCar.Show();
        }

        private void updateCarButton_Click(object sender, EventArgs e)
        {
            AdminUpdateCar updateCar = new AdminUpdateCar();

            this.Close();
            
            // Update car menu
            updateCar.Show();
        }

        private void searchCarButton_Click(object sender, EventArgs e)
        {
            AdminSearchCar searchCar = new AdminSearchCar();

            this.Close();

            searchCar.Show();
        }

        private void listCarButton_Click(object sender, EventArgs e)
        {
            AdminListCar listCar = new AdminListCar();

            this.Close();
            
            // Display all cars
            listCar.Show();
        }
    }
}

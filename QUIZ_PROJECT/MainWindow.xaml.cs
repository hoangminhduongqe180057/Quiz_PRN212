using System.Windows;
using System.Windows.Controls;

namespace QUIZ_PROJECT
{
    public partial class MainWindow : Window
    {
        public string UserRole { get; set; }

        public MainWindow(string userRole)
        {
            InitializeComponent();
            UserRole = userRole;
            MainContent.Navigate(new HomePage(UserRole));
            SetMenuVisibility();
        }

        private void SetMenuVisibility()
        {
            // Always visible for all roles
            HomeButton.Visibility = Visibility.Visible;
            TakeQuizButton.Visibility = Visibility.Visible;
            ResultsButton.Visibility = Visibility.Visible;
            LogoutButton.Visibility = Visibility.Visible;

            // Only visible for Teacher and Admin roles
            CategoriesButton.Visibility = UserRole == "Admin" || UserRole == "Teacher" ? Visibility.Visible : Visibility.Collapsed;
            QuizzesButton.Visibility = UserRole == "Admin" || UserRole == "Teacher" ? Visibility.Visible : Visibility.Collapsed;

            // Only visible for Admin role
            UsersButton.Visibility = UserRole == "Admin" ? Visibility.Visible : Visibility.Collapsed;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new HomePage(UserRole));
        }


        private void UsersButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new UsersPage()); // Replace with the actual page class
        }

        private void CategoriesButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new CategoriesPage()); // Replace with the actual page class
        }

        private void QuizzesButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new QuizzesPage()); // Replace with the actual page class
        }

        private void TakeQuizButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new TakeQuizPage()); // Replace with the actual page class
        }

        private void ResultsButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new ResultsPage()); // Replace with the actual page class
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Open LoginWindow
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();

            // Close MainWindow
            this.Close();
        }
    }
}

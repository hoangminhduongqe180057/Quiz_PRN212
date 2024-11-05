using System.Windows;
using System.Windows.Controls;

namespace QUIZ_PROJECT
{
    public partial class MainWindow : Window
    {
        public string UserRole { get; set; }
        private string UserName { get; set; }
        private int UserId { get; set; }

        public MainWindow(string userRole, string userName, int userId)
        {
            InitializeComponent();
            UserRole = userRole;
            UserName = userName;
            UserId = userId;

            // Navigate to HomePage with all required parameters
            MainContent.Navigate(new HomePage(UserRole, UserName, UserId));
            SetMenuVisibility();
        }

        private void SetMenuVisibility()
        {
            // Set visibility based on roles
            HomeButton.Visibility = Visibility.Visible;
            TakeQuizButton.Visibility = Visibility.Visible;
            ResultsButton.Visibility = Visibility.Visible;
            LogoutButton.Visibility = Visibility.Visible;

            CategoriesButton.Visibility = (UserRole == "Admin" || UserRole == "Teacher") ? Visibility.Visible : Visibility.Collapsed;
            QuizzesButton.Visibility = (UserRole == "Admin" || UserRole == "Teacher") ? Visibility.Visible : Visibility.Collapsed;
            UsersButton.Visibility = (UserRole == "Admin") ? Visibility.Visible : Visibility.Collapsed;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new HomePage(UserRole, UserName, UserId)); // Pass UserId as the third parameter
        }

        private void UsersButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new UsersPage()); // Ensure UsersPage is implemented correctly
        }

        private void CategoriesButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new CategoriesPage()); // Ensure CategoriesPage is implemented correctly
        }

        private void QuizzesButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new QuizzesPage()); // Ensure QuizzesPage is implemented correctly
        }

        private void TakeQuizButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new TakeQuizPage(UserId)); // Pass UserId to TakeQuizPage
        }

        private void ResultsButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new ResultsPage(UserName)); // Pass UserName to ResultsPage
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

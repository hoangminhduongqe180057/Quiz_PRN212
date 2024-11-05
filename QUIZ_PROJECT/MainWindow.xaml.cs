using System.Windows;
using System.Windows.Controls;

namespace QUIZ_PROJECT
{
    public partial class MainWindow : Window
    {
        public string UserRole { get; set; }
        private string UserName { get; set; }
        private int UserId { get; set; }
        private bool IsTakingQuiz { get; set; } // Flag to track if the user is taking a quiz

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

        private void ToggleMenuVisibility(bool isVisible)
        {
            if (UserRole == "Student") // Apply restrictions only for students
            {
                Visibility visibility = isVisible ? Visibility.Visible : Visibility.Collapsed;

                HomeButton.Visibility = visibility;
                TakeQuizButton.Visibility = visibility;
                ResultsButton.Visibility = visibility;
                LogoutButton.Visibility = visibility;

                // Hide these options entirely for students while taking the quiz
                CategoriesButton.Visibility = Visibility.Collapsed;
                QuizzesButton.Visibility = Visibility.Collapsed;
                UsersButton.Visibility = Visibility.Collapsed;
            }
        }


        private void TakeQuizButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserRole == "Student")
            {
                IsTakingQuiz = true; // Set flag to indicate quiz mode
                ToggleMenuVisibility(false); // Hide the menu for the student role
            }
            MainContent.Navigate(new TakeQuizPage(this, UserId)); // Pass MainWindow reference and UserId to TakeQuizPage
        }



        // Method to re-enable navigation for students after quiz submission
        public void EndQuiz()
        {
            if (UserRole == "Student")
            {
                IsTakingQuiz = false;
                ToggleMenuVisibility(true); // Show the menu again for students
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsTakingQuiz || UserRole != "Student")
            {
                MainContent.Navigate(new HomePage(UserRole, UserName, UserId));
            }
        }

        private void ResultsButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsTakingQuiz || UserRole != "Student")
            {
                MainContent.Navigate(new ResultsPage(UserName, UserRole, UserId)); // Pass UserRole and UserId to ResultsPage
            }
        }


        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsTakingQuiz || UserRole != "Student")
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
        }

        private void UsersButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to UsersPage
            MainContent.Navigate(new UsersPage());
        }

        private void CategoriesButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to CategoriesPage
            MainContent.Navigate(new CategoriesPage());
        }

        private void QuizzesButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to QuizzesPage
            MainContent.Navigate(new QuizzesPage());
        }
    }
}

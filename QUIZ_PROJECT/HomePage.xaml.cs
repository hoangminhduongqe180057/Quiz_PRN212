using System.Windows;
using System.Windows.Controls;

namespace QUIZ_PROJECT
{
    public partial class HomePage : Page
    {
        private string UserRole;
        public HomePage(string userRole)
        {
            InitializeComponent();
            UserRole = userRole;
            SetSectionVisibility();
        }

        private void SetSectionVisibility()
        {
            // Admin: All sections visible
            if (UserRole == "Admin")
            {
                ManageUsersSection.Visibility = Visibility.Visible;
                ManageQuizzesSection.Visibility = Visibility.Visible;
                TakeQuizSection.Visibility = Visibility.Visible;
                ViewResultsSection.Visibility = Visibility.Visible;
            }
            // Teacher: All sections except "Manage Users"
            else if (UserRole == "Teacher")
            {
                ManageUsersSection.Visibility = Visibility.Collapsed;
                ManageQuizzesSection.Visibility = Visibility.Visible;
                TakeQuizSection.Visibility = Visibility.Visible;
                ViewResultsSection.Visibility = Visibility.Visible;
            }
            // Student: Only "Take Quiz" and "View Results" sections
            else if (UserRole == "Student")
            {
                ManageUsersSection.Visibility = Visibility.Collapsed;
                ManageQuizzesSection.Visibility = Visibility.Collapsed;
                TakeQuizSection.Visibility = Visibility.Visible;
                ViewResultsSection.Visibility = Visibility.Visible;
            }
        }

        private void GoToUsers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UsersPage());
        }

        private void GoToQuizzes_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new QuizzesPage());
        }

        private void StartQuiz_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TakeQuizPage());
        }

        private void GoToResults_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ResultsPage());
        }
    }
}

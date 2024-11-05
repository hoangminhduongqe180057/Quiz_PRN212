using System.Windows;
using System.Windows.Controls;

namespace QUIZ_PROJECT
{
    public partial class HomePage : Page
    {
        private string UserRole;
        private string UserName;
        private int UserId; 

        public HomePage(string userRole, string userName, int userId)
        {
            InitializeComponent();
            UserRole = userRole;
            UserName = userName;
            UserId = userId; // Store userId

            // Set the role icon based on userRole
            string roleIcon = userRole switch
            {
                "Admin" => "👑",
                "Teacher" => "📚",
                "Student" => "🎓",
                _ => "👤"
            };

            // Display role and name information
            RoleText.Text = $"{roleIcon} {userRole}";

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
            // Get a reference to the MainWindow and pass it along with the UserId
            var mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                NavigationService.Navigate(new TakeQuizPage(mainWindow, UserId));
            }
            else
            {
                MessageBox.Show("Error: MainWindow not found.");
            }
        }


        private void GoToResults_Click(object sender, RoutedEventArgs e)
        {
            // Pass UserName, UserRole, and UserId to ResultsPage
            NavigationService.Navigate(new ResultsPage(UserName, UserRole, UserId));
        }
    }
}

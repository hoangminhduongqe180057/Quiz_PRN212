using System.Windows;
using System.Windows.Controls;

namespace QUIZ_PROJECT
{
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
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

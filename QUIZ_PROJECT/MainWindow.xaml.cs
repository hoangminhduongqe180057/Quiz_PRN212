using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QUIZ_PROJECT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new Uri("/HomePage.xaml", UriKind.Relative));
        }

        private void UsersButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new Uri("/UsersPage.xaml", UriKind.Relative));
        }

        private void QuizzesButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new Uri("/QuizzesPage.xaml", UriKind.Relative));
        }

        private void TakeQuizButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new Uri("/TakeQuizPage.xaml", UriKind.Relative));
        }

        private void ResultsButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new Uri("/ResultsPage.xaml", UriKind.Relative));
        }

        private void CategoriesButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new Uri("/CategoriesPage.xaml", UriKind.Relative));
        }

    }
}
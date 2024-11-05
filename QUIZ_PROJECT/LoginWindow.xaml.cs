using DataAccess.Models;
using System.Linq;
using System.Windows;

namespace QUIZ_PROJECT
{
    public partial class LoginWindow : Window
    {
        private QuizContext _context;

        public LoginWindow()
        {
            InitializeComponent();
            _context = new QuizContext();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)   
            {
                // Pass the role to MainWindow
                MainWindow mainWindow = new MainWindow(user.Role, user.Name, user.Id);
                mainWindow.Show();



                // Close LoginWindow
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}

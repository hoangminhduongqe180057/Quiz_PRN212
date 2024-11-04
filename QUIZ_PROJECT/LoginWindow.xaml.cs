using System.Linq;
using System.Windows;
using DataAccess.Models; // Make sure this points to your actual DbContext namespace

namespace QUIZ_PROJECT
{
    public partial class LoginWindow : Window
    {
        private QuizContext _context; // Database context to access user data

        public LoginWindow()
        {
            InitializeComponent();
            _context = new QuizContext(); // Initialize the context
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (ValidateUser(username, password))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                // Set HomePage as the content of MainWindow
                mainWindow.MainContent.Navigate(new HomePage());

                this.Close(); // Close the login window
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Validates user credentials against the database
        private bool ValidateUser(string username, string password)
        {
            // Check if a user with the provided username and password exists
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            // Returns true if a matching user is found, otherwise false
            return user != null;
        }
    }
}

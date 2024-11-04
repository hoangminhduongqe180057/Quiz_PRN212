using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        private QuizContext _context;

        public UsersPage()
        {
            InitializeComponent();
            _context = new QuizContext();
            LoadUsers();
        }

        private void LoadUsers()
        {
            UsersDataGrid.ItemsSource = _context.Users.ToList();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            var user = new User
            {
                Username = UsernameTextBox.Text,
                Password = PasswordTextBox.Text, // Ideally, you should hash passwords.
                Role = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString()
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            LoadUsers();
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            // Implement editing logic here
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem is User selectedUser)
            {
                _context.Users.Remove(selectedUser);
                _context.SaveChanges();
                LoadUsers();
            }
        }
    }
}

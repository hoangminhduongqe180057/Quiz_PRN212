using DataAccess.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace QUIZ_PROJECT
{
    public partial class UsersPage : Page
    {
        private QuizContext _context;
        private User _selectedUser = null; // Holds the currently selected user for editing

        public UsersPage()
        {
            InitializeComponent();
            _context = new QuizContext();
            LoadUsers();
        }

        private void LoadUsers()
        {
            UsersDataGrid.ItemsSource = _context.Users.ToList();
            ClearInputFields(); // Clear input fields after loading data
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            // Check for empty fields
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) || // Check for Name field
                string.IsNullOrWhiteSpace(UsernameTextBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordTextBox.Password) ||
                RoleComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please fill out all fields.", "Input Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Check for duplicate username
            var existingUser = _context.Users.FirstOrDefault(u => u.Username == UsernameTextBox.Text);
            if (_selectedUser == null) // Adding a new user
            {
                if (existingUser != null)
                {
                    MessageBox.Show("Username already exists. Please choose a different username.", "Duplicate Username", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var user = new User
                {
                    Username = UsernameTextBox.Text,
                    Password = PasswordTextBox.Password, // Ideally, you should hash passwords
                    Role = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString()
                };

                _context.Users.Add(user);
                _context.SaveChanges(); // Save user to generate the ID

                // Check if the role is "Student" and create a corresponding Student record
                if (user.Role == "Student")
                {
                    var student = new Student
                    {
                        Name = NameTextBox.Text, // Use the NameTextBox for Student Name
                        Email = $"{user.Username}@example.com", // Or capture email if it's available
                        UserId = user.Id // Link the Student to the created User
                    };

                    _context.Students.Add(student);
                    MessageBox.Show("User and Student profile added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("User added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else // Editing an existing user
            {
                // Allow updating the existing user without duplicate check if username remains unchanged
                if (existingUser != null && existingUser.Id != _selectedUser.Id)
                {
                    MessageBox.Show("Username already exists. Please choose a different username.", "Duplicate Username", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                _selectedUser.Username = UsernameTextBox.Text;
                _selectedUser.Password = PasswordTextBox.Password;
                _selectedUser.Role = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

                MessageBox.Show("User updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                _selectedUser = null; // Reset the selected user after editing
            }

            _context.SaveChanges();
            LoadUsers();
        }




        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            // Check if a user is selected in the DataGrid
            if (UsersDataGrid.SelectedItem is User selectedUser)
            {
                _selectedUser = selectedUser; // Set the selected user for editing

                // Populate the input fields with the user's information
                UsernameTextBox.Text = selectedUser.Username;
                PasswordTextBox.Password = selectedUser.Password; // Display the password as plain text here for simplicity
                RoleComboBox.SelectedItem = RoleComboBox.Items
                    .Cast<ComboBoxItem>()
                    .FirstOrDefault(item => item.Content.ToString() == selectedUser.Role);
            }
            else
            {
                MessageBox.Show("Please select a user to edit.", "Edit User", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem is User selectedUser)
            {
                var result = MessageBox.Show($"Are you sure you want to delete {selectedUser.Username}?",
                                             "Confirm Delete",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    _context.Users.Remove(selectedUser);
                    _context.SaveChanges();
                    LoadUsers();
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.", "Delete User", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ClearInputFields()
        {
            // Clears the input fields
            UsernameTextBox.Text = string.Empty;
            PasswordTextBox.Password = string.Empty;
            RoleComboBox.SelectedIndex = -1;
        }
    }
}

using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace QUIZ_PROJECT
{
    public partial class QuizzesPage : Page
    {
        private QuizContext _context;
        private bool _isEditMode = false;
        private int? _editingQuizId = null;

        public QuizzesPage()
        {
            InitializeComponent();
            _context = new QuizContext();
            LoadQuizzes();
            LoadCategories();
        }

        // Load all quizzes into the DataGrid
        private void LoadQuizzes()
        {
            QuizzesDataGrid.ItemsSource = _context.Quizzes.Include(q => q.Category).ToList();
            ClearInputFields(); // Clear input fields after loading data
        }

        // Load all categories into the ComboBox for selection when adding a new quiz
        private void LoadCategories()
        {
            CategoryComboBox.ItemsSource = _context.Categories.ToList();
            CategoryComboBox.DisplayMemberPath = "Name";
            CategoryComboBox.SelectedValuePath = "Id";
        }

        // Add or edit a quiz
        private void AddQuiz_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(QuizTitleTextBox.Text) || CategoryComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please enter a title and select a category.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_isEditMode && _editingQuizId.HasValue) // Edit mode
            {
                var quiz = _context.Quizzes.FirstOrDefault(q => q.Id == _editingQuizId.Value);
                if (quiz != null)
                {
                    quiz.Title = QuizTitleTextBox.Text;
                    quiz.CategoryId = (int)CategoryComboBox.SelectedValue;
                    MessageBox.Show("Quiz updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else // Add mode
            {
                var newQuiz = new Quiz
                {
                    Title = QuizTitleTextBox.Text,
                    CategoryId = (int)CategoryComboBox.SelectedValue
                };
                _context.Quizzes.Add(newQuiz);
                MessageBox.Show("Quiz added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            _context.SaveChanges();
            LoadQuizzes();
            ResetForm();
        }

        // Edit the selected quiz's title and category
        private void EditQuiz_Click(object sender, RoutedEventArgs e)
        {
            if (QuizzesDataGrid.SelectedItem is Quiz selectedQuiz)
            {
                _isEditMode = true;
                _editingQuizId = selectedQuiz.Id;
                QuizTitleTextBox.Text = selectedQuiz.Title;
                CategoryComboBox.SelectedValue = selectedQuiz.CategoryId;
                AddQuiz_Button.Content = "Update Quiz";
            }
            else
            {
                MessageBox.Show("Please select a quiz to edit.", "Edit Quiz", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Delete the selected quiz
        private void DeleteQuiz_Click(object sender, RoutedEventArgs e)
        {
            if (QuizzesDataGrid.SelectedItem is Quiz selectedQuiz)
            {
                var result = MessageBox.Show($"Are you sure you want to delete the quiz '{selectedQuiz.Title}'?", "Delete Quiz", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    _context.Quizzes.Remove(selectedQuiz);
                    _context.SaveChanges();
                    LoadQuizzes();
                    MessageBox.Show("Quiz deleted successfully.", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a quiz to delete.", "Delete Quiz", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Navigate to the Manage Questions page for the selected quiz
        private void ManageQuestions_Click(object sender, RoutedEventArgs e)
        {
            if (QuizzesDataGrid.SelectedItem is Quiz selectedQuiz)
            {
                var manageQuestionsPage = new ManageQuestionsPage(selectedQuiz.Id);
                NavigationService.Navigate(manageQuestionsPage);
            }
            else
            {
                MessageBox.Show("Please select a quiz to manage its questions.", "Manage Questions", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Update the form fields when a quiz is selected in the DataGrid
        private void QuizzesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (QuizzesDataGrid.SelectedItem is Quiz selectedQuiz)
            {
                _isEditMode = true;
                _editingQuizId = selectedQuiz.Id;
                QuizTitleTextBox.Text = selectedQuiz.Title;
                CategoryComboBox.SelectedValue = selectedQuiz.CategoryId;
                AddQuiz_Button.Content = "Update Quiz";
            }
        }

        // Reset the form fields and set the button back to "Add"
        private void ResetForm()
        {
            QuizTitleTextBox.Clear();
            CategoryComboBox.SelectedIndex = -1;
            _isEditMode = false;
            _editingQuizId = null;
            AddQuiz_Button.Content = "Add Quiz";
        }

        // Clears the input fields
        private void ClearInputFields()
        {
            QuizTitleTextBox.Clear();
            CategoryComboBox.SelectedIndex = -1;
        }
    }
}

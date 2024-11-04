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
        }

        // Load all categories into the ComboBox for selection when adding a new quiz
        private void LoadCategories()
        {
            CategoryComboBox.ItemsSource = _context.Categories.ToList();
            CategoryComboBox.DisplayMemberPath = "Name";
            CategoryComboBox.SelectedValuePath = "Id";
        }

        // Add a new quiz to the database
        private void AddQuiz_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(QuizTitleTextBox.Text) && CategoryComboBox.SelectedValue != null)
            {
                var quiz = new Quiz
                {
                    Title = QuizTitleTextBox.Text,
                    CategoryId = (int)CategoryComboBox.SelectedValue
                };

                _context.Quizzes.Add(quiz);
                _context.SaveChanges();
                LoadQuizzes();

                // Clear input fields after adding
                QuizTitleTextBox.Clear();
                CategoryComboBox.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Please enter a title and select a category.");
            }
        }

        // Edit the selected quiz's title and category
        private void EditQuiz_Click(object sender, RoutedEventArgs e)
        {
            if (QuizzesDataGrid.SelectedItem is Quiz selectedQuiz)
            {
                var newTitle = Microsoft.VisualBasic.Interaction.InputBox("Edit Quiz Title:", "Edit Quiz", selectedQuiz.Title);
                if (!string.IsNullOrEmpty(newTitle) && CategoryComboBox.SelectedValue != null)
                {
                    selectedQuiz.Title = newTitle;
                    selectedQuiz.CategoryId = (int)CategoryComboBox.SelectedValue;

                    _context.SaveChanges();
                    LoadQuizzes();
                }
                else
                {
                    MessageBox.Show("Please provide a new title and select a category.");
                }
            }
            else
            {
                MessageBox.Show("Please select a quiz to edit.");
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
                }
            }
            else
            {
                MessageBox.Show("Please select a quiz to delete.");
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
                MessageBox.Show("Please select a quiz to manage its questions.");
            }
        }

        // Update the category ComboBox when a quiz is selected, for easier editing
        private void QuizzesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (QuizzesDataGrid.SelectedItem is Quiz selectedQuiz)
            {
                CategoryComboBox.SelectedValue = selectedQuiz.CategoryId;
                QuizTitleTextBox.Text = selectedQuiz.Title;
            }
        }
    }
}

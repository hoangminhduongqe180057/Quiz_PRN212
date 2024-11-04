using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace QUIZ_PROJECT
{
    public partial class TakeQuizPage : Page
    {
        private QuizContext _context;
        private Dictionary<int, int> _selectedAnswers; // Stores question ID and selected answer ID pairs

        public TakeQuizPage()
        {
            InitializeComponent();
            _context = new QuizContext();
            _selectedAnswers = new Dictionary<int, int>();
            LoadQuizzes();
        }

        // Load quizzes into the ComboBox
        private void LoadQuizzes()
        {
            QuizComboBox.ItemsSource = _context.Quizzes.ToList();
            QuizComboBox.DisplayMemberPath = "Title";
            QuizComboBox.SelectedValuePath = "Id";
        }

        // When a quiz is selected, load its questions and answers
        private void QuizComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (QuizComboBox.SelectedValue is int quizId)
            {
                // Load quiz details (title and instructions)
                var quiz = _context.Quizzes.Include(q => q.Category).FirstOrDefault(q => q.Id == quizId);
                if (quiz != null)
                {
                    QuizTitleText.Text = quiz.Title;
                    if (quiz.Duration.HasValue)
                    {
                        QuizInstructions.Text = $"Category: {quiz.Category?.Name} - Duration: {quiz.Duration.Value.Hour} hours and {quiz.Duration.Value.Minute} minutes";
                    }
                    else
                    {
                        QuizInstructions.Text = $"Category: {quiz.Category?.Name} - Duration: Not specified";
                    }

                }

                // Load questions for the selected quiz
                LoadQuestions(quizId);
            }
        }

        // Load questions and answers for the selected quiz
        private void LoadQuestions(int quizId)
        {
            var questions = _context.Questions
                                    .Where(q => q.QuizId == quizId)
                                    .Include(q => q.Answers)
                                    .ToList();

            // Bind questions to the ItemsControl
            QuestionsItemsControl.ItemsSource = questions;

            // Clear previously selected answers
            _selectedAnswers.Clear();
        }

        // Submit quiz and calculate score
        private void SubmitQuiz_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to submit the quiz?", "Submit Quiz", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // Calculate and save the score
                int score = 0;
                foreach (var question in QuestionsItemsControl.Items)
                {
                    if (question is Question q && _selectedAnswers.TryGetValue(q.Id, out int selectedAnswerId))
                    {
                        if (q.Answers.Any(a => a.Id == selectedAnswerId && a.IsCorrect))
                        {
                            score++;
                        }
                    }
                }

                MessageBox.Show($"Your score is: {score} out of {QuestionsItemsControl.Items.Count}");
                SaveQuizResult(score);
            }
        }

        // Save the quiz result in the Mark table
        private void SaveQuizResult(int score)
        {
            if (QuizComboBox.SelectedValue is int quizId)
            {
                var mark = new Mark
                {
                    StudentId = GetCurrentStudentId(), // Retrieve the logged-in student ID
                    QuizId = quizId,
                    Score = score,
                    DateTaken = DateTime.Now
                };

                try
                {
                    _context.Marks.Add(mark);
                    _context.SaveChanges();
                    MessageBox.Show("Your result has been saved!");
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show($"An error occurred while saving your results: {ex.InnerException?.Message}");
                }
            }
        }

        // Placeholder for actual authentication logic to get current student ID
        private int GetCurrentStudentId()
        {
            // Replace with actual student ID logic. Here, we retrieve the first student ID as an example.
            return _context.Students.Select(s => s.Id).FirstOrDefault();
        }

        // Capture selected answer in _selectedAnswers dictionary
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton && radioButton.DataContext is Answer answer)
            {
                if ((radioButton.DataContext as Answer)?.Question is Question question)
                {
                    _selectedAnswers[question.Id] = answer.Id;
                }
            }
        }
    }
}

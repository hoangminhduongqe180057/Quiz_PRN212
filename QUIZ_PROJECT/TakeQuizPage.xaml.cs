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
        private List<Question> _questions; // Holds all questions for the selected quiz
        private int _currentQuestionIndex; // Tracks the current question index
        private int _userId; // Stores the user ID of the logged-in user
        private MainWindow _mainWindow;
        public TakeQuizPage(MainWindow mainWindow, int userId)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _context = new QuizContext();
            _selectedAnswers = new Dictionary<int, int>();
            _questions = new List<Question>();
            _currentQuestionIndex = 0;
            _userId = userId; // Initialize user ID

            LoadQuizzes();
        }

        private void LoadQuizzes()
        {
            QuizComboBox.ItemsSource = _context.Quizzes.ToList();
            QuizComboBox.DisplayMemberPath = "Title";
            QuizComboBox.SelectedValuePath = "Id";
        }

        private void QuizComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (QuizComboBox.SelectedValue is int quizId)
            {
                var quiz = _context.Quizzes.Include(q => q.Category).FirstOrDefault(q => q.Id == quizId);
                if (quiz != null)
                {
                    QuizTitleText.Text = quiz.Title;
                    QuizInstructions.Text = quiz.Duration.HasValue
? $"Category: {quiz.Category?.Name} - Duration: {quiz.Duration.Value.Hour} hours and {quiz.Duration.Value.Minute} minutes"
: $"Category: {quiz.Category?.Name} - Duration: Not specified";

                    LoadQuestions(quizId);
                }
            }
        }

        private void LoadQuestions(int quizId)
        {
            _questions = _context.Questions
                                 .Where(q => q.QuizId == quizId)
                                 .Include(q => q.Answers)
                                 .ToList();
            _currentQuestionIndex = 0;
            ShowCurrentQuestion();
            _selectedAnswers.Clear();
        }

        private void ShowCurrentQuestion()
        {
            if (_questions.Any() && _currentQuestionIndex >= 0 && _currentQuestionIndex < _questions.Count)
            {
                var currentQuestion = _questions[_currentQuestionIndex];
                QuestionText.Text = currentQuestion.Text;

                var labels = new[] { "A", "B", "C", "D" };
                var answerOptions = currentQuestion.Answers
                    .Select((answer, index) => new AnswerOption
                    {
                        Label = labels[index],
                        AnswerId = answer.Id,
                        Text = answer.Text,
                        IsChecked = _selectedAnswers.ContainsKey(currentQuestion.Id) && _selectedAnswers[currentQuestion.Id] == answer.Id
                    })
                    .ToList();

                AnswersItemsControl.ItemsSource = answerOptions;
            }
        }

        private void AnswerRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton && radioButton.Tag is int answerId)
            {
                var questionId = _questions[_currentQuestionIndex].Id;
                _selectedAnswers[questionId] = answerId;
            }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentQuestionIndex > 0)
            {
                _currentQuestionIndex--;
                ShowCurrentQuestion();
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentQuestionIndex < _questions.Count - 1)
            {
                _currentQuestionIndex++;
                ShowCurrentQuestion();
            }
        }

        private void SubmitQuiz_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to submit your answers?", "Confirm Submission", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                double score = CalculateScore();
                SaveQuizResult(score);

                // Call EndQuiz on MainWindow to re-enable the menu
                _mainWindow.EndQuiz();
            }
        }




        private double CalculateScore()
        {
            int correctAnswers = 0;
            foreach (var question in _questions)
            {
                if (_selectedAnswers.TryGetValue(question.Id, out int selectedAnswerId) && question.CorrectAnswerId == selectedAnswerId)
                {
                    correctAnswers++;
                }
            }

            // Calculate the score on a 10-point scale
            double scoreOn10Scale = (correctAnswers / (double)_questions.Count) * 10;
            return Math.Round(scoreOn10Scale, 2); // Round to 2 decimal places for better presentation
        }

        private void SaveQuizResult(double score)
        {
            if (QuizComboBox.SelectedValue is int quizId)
            {
                int studentId = GetCurrentStudentId(_userId);
                if (studentId == 0)
                {
                    MessageBox.Show("No valid student found. Please log in or create a student profile.");
                    return;
                }

                var mark = new Mark
                {
                    StudentId = studentId,
                    QuizId = quizId,
                    Score = (decimal)score, // Save the score on a 10-point scale
                    DateTaken = DateTime.Now
                };

                try
                {
                    _context.Marks.Add(mark);
                    _context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show($"An error occurred while saving your results: {ex.InnerException?.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a quiz before submitting.");
            }
        }

        private int GetCurrentStudentId(int userId)
        {
            var student = _context.Students
                                  .FirstOrDefault(s => s.UserId == userId);
            if (student != null)
            {
                return student.Id;
            }
            else
            {
                return 0;
            }
        }
    }
}

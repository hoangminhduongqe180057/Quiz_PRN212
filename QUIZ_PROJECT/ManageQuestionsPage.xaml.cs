using DataAccess.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace QUIZ_PROJECT
{
    public partial class ManageQuestionsPage : Page
    {
        private QuizContext _context;
        private int _quizId;
        private string _correctAnswer; // Stores which answer is marked correct

        public ManageQuestionsPage(int quizId)
        {
            InitializeComponent();
            _context = new QuizContext();
            _quizId = quizId;
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            QuestionsDataGrid.ItemsSource = _context.Questions
                                                    .Where(q => q.QuizId == _quizId)
                                                    .ToList();
        }

        private void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateQuestionInput())
            {
                // Create the question
                var question = new Question
                {
                    Text = QuestionTextBox.Text,
                    QuizId = _quizId
                };

                _context.Questions.Add(question);
                _context.SaveChanges();

                // Retrieve the question ID after saving
                int questionId = question.Id;

                // Add answers with the correct answer identified
                AddAnswer(questionId, AnswerATextBox.Text, _correctAnswer == "A");
                AddAnswer(questionId, AnswerBTextBox.Text, _correctAnswer == "B");
                AddAnswer(questionId, AnswerCTextBox.Text, _correctAnswer == "C");
                AddAnswer(questionId, AnswerDTextBox.Text, _correctAnswer == "D");

                _context.SaveChanges();
                LoadQuestions();

                // Clear input fields after adding
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please complete all fields and select a correct answer.");
            }
        }

        private void AddAnswer(int questionId, string answerText, bool isCorrect)
        {
            var answer = new Answer
            {
                Text = answerText,
                QuestionId = questionId,
                IsCorrect = isCorrect
            };
            _context.Answers.Add(answer);
        }

        private bool ValidateQuestionInput()
        {
            // Ensure all fields are filled and a correct answer is selected
            return !string.IsNullOrWhiteSpace(QuestionTextBox.Text)
                   && !string.IsNullOrWhiteSpace(AnswerATextBox.Text)
                   && !string.IsNullOrWhiteSpace(AnswerBTextBox.Text)
                   && !string.IsNullOrWhiteSpace(AnswerCTextBox.Text)
                   && !string.IsNullOrWhiteSpace(AnswerDTextBox.Text)
                   && !string.IsNullOrWhiteSpace(_correctAnswer);
        }

        private void ClearInputFields()
        {
            QuestionTextBox.Clear();
            AnswerATextBox.Clear();
            AnswerBTextBox.Clear();
            AnswerCTextBox.Clear();
            AnswerDTextBox.Clear();
            _correctAnswer = null;
        }

        private void CorrectAnswer_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton)
            {
                _correctAnswer = radioButton.Content.ToString(); // Set the correct answer based on selected option (A, B, C, or D)
            }
        }

        private void EditQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (QuestionsDataGrid.SelectedItem is Question selectedQuestion)
            {
                var newQuestionText = Microsoft.VisualBasic.Interaction.InputBox("Edit question:", "Edit Question", selectedQuestion.Text);
                if (!string.IsNullOrEmpty(newQuestionText))
                {
                    selectedQuestion.Text = newQuestionText;
                    _context.SaveChanges();
                    LoadQuestions();
                }
            }
        }

        private void DeleteQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (QuestionsDataGrid.SelectedItem is Question selectedQuestion)
            {
                _context.Questions.Remove(selectedQuestion);
                _context.SaveChanges();
                LoadQuestions();
            }
        }
    }
}

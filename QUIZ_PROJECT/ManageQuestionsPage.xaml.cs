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
        private int _correctAnswerId; // Stores the ID of the correct answer
        private Question _selectedQuestion; // Tracks the question being edited

        public ManageQuestionsPage(int quizId)
        {
            InitializeComponent();
            _context = new QuizContext();
            _quizId = quizId;
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            // Load questions belonging to the specified quiz
            QuestionsDataGrid.ItemsSource = _context.Questions
                                                    .Where(q => q.QuizId == _quizId)
                                                    .ToList();
            ClearInputFields();
        }

        private void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateQuestionInput())
            {
                if (_selectedQuestion == null) // Adding a new question
                {
                    // Check for duplicate question text within the same quiz
                    if (_context.Questions.Any(q => q.Text == QuestionTextBox.Text && q.QuizId == _quizId))
                    {
                        MessageBox.Show("A question with this text already exists in this quiz.", "Duplicate Question", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    // Create a new question
                    var question = new Question
                    {
                        Text = QuestionTextBox.Text,
                        QuizId = _quizId
                    };

                    _context.Questions.Add(question);
                    _context.SaveChanges();

                    // Add answers and set the CorrectAnswerId
                    var answerA = AddAnswer(question.Id, AnswerATextBox.Text);
                    var answerB = AddAnswer(question.Id, AnswerBTextBox.Text);
                    var answerC = AddAnswer(question.Id, AnswerCTextBox.Text);
                    var answerD = AddAnswer(question.Id, AnswerDTextBox.Text);

                    // Set the correct answer based on selected RadioButton
                    question.CorrectAnswerId = GetCorrectAnswerId(answerA, answerB, answerC, answerD);
                    _context.SaveChanges();

                    MessageBox.Show("Question added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else // Updating an existing question
                {
                    _selectedQuestion.Text = QuestionTextBox.Text;

                    // Update answers associated with the selected question
                    var answers = _context.Answers.Where(a => a.QuestionId == _selectedQuestion.Id).ToList();
                    UpdateAnswer(answers[0], AnswerATextBox.Text);
                    UpdateAnswer(answers[1], AnswerBTextBox.Text);
                    UpdateAnswer(answers[2], AnswerCTextBox.Text);
                    UpdateAnswer(answers[3], AnswerDTextBox.Text);

                    // Set the correct answer ID for the updated question
                    _selectedQuestion.CorrectAnswerId = GetCorrectAnswerId(answers[0], answers[1], answers[2], answers[3]);
                    _context.SaveChanges();

                    MessageBox.Show("Question updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    _selectedQuestion = null;
                }

                LoadQuestions();
            }
            else
            {
                MessageBox.Show("Please complete all fields and select a correct answer.", "Input Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private Answer AddAnswer(int questionId, string answerText)
        {
            var answer = new Answer
            {
                Text = answerText,
                QuestionId = questionId
            };
            _context.Answers.Add(answer);
            _context.SaveChanges();
            return answer;
        }

        private void UpdateAnswer(Answer answer, string newText)
        {
            answer.Text = newText;
        }

        private int GetCorrectAnswerId(Answer answerA, Answer answerB, Answer answerC, Answer answerD)
        {
            // Determine which answer was selected as the correct one based on the radio button
            if (RadioButtonA.IsChecked == true) return answerA.Id;
            if (RadioButtonB.IsChecked == true) return answerB.Id;
            if (RadioButtonC.IsChecked == true) return answerC.Id;
            if (RadioButtonD.IsChecked == true) return answerD.Id;
            return 0; // Default value in case no answer is selected
        }

        private void ClearInputFields()
        {
            QuestionTextBox.Clear();
            AnswerATextBox.Clear();
            AnswerBTextBox.Clear();
            AnswerCTextBox.Clear();
            AnswerDTextBox.Clear();
            _correctAnswerId = 0;
            _selectedQuestion = null;
            RadioButtonA.IsChecked = RadioButtonB.IsChecked = RadioButtonC.IsChecked = RadioButtonD.IsChecked = false;
        }

        private void EditQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (QuestionsDataGrid.SelectedItem is Question selectedQuestion)
            {
                _selectedQuestion = selectedQuestion;
                QuestionTextBox.Text = selectedQuestion.Text;

                // Load existing answers for the selected question
                var answers = _context.Answers.Where(a => a.QuestionId == selectedQuestion.Id).ToList();
                if (answers.Count >= 4)
                {
                    AnswerATextBox.Text = answers[0].Text;
                    AnswerBTextBox.Text = answers[1].Text;
                    AnswerCTextBox.Text = answers[2].Text;
                    AnswerDTextBox.Text = answers[3].Text;

                    // Set the correct answer RadioButton based on CorrectAnswerId
                    if (selectedQuestion.CorrectAnswerId == answers[0].Id)
                        RadioButtonA.IsChecked = true;
                    else if (selectedQuestion.CorrectAnswerId == answers[1].Id)
                        RadioButtonB.IsChecked = true;
                    else if (selectedQuestion.CorrectAnswerId == answers[2].Id)
                        RadioButtonC.IsChecked = true;
                    else if (selectedQuestion.CorrectAnswerId == answers[3].Id)
                        RadioButtonD.IsChecked = true;
                }
            }
            else
            {
                MessageBox.Show("Please select a question to edit.", "Edit Question", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void CorrectAnswer_Checked(object sender, RoutedEventArgs e)
        {
            // RadioButton event doesn't need to modify _correctAnswerId directly
            // It will be determined by GetCorrectAnswerId during save
        }

        private bool ValidateQuestionInput()
        {
            return !string.IsNullOrWhiteSpace(QuestionTextBox.Text)
                   && !string.IsNullOrWhiteSpace(AnswerATextBox.Text)
                   && !string.IsNullOrWhiteSpace(AnswerBTextBox.Text)
                   && !string.IsNullOrWhiteSpace(AnswerCTextBox.Text)
                   && !string.IsNullOrWhiteSpace(AnswerDTextBox.Text)
                   && (RadioButtonA.IsChecked == true || RadioButtonB.IsChecked == true || RadioButtonC.IsChecked == true || RadioButtonD.IsChecked == true);
        }

        private void DeleteQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (QuestionsDataGrid.SelectedItem is Question selectedQuestion)
            {
                var result = MessageBox.Show($"Are you sure you want to delete the question '{selectedQuestion.Text}'?",
                                             "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    var answers = _context.Answers.Where(a => a.QuestionId == selectedQuestion.Id);
                    _context.Answers.RemoveRange(answers);
                    _context.Questions.Remove(selectedQuestion);
                    _context.SaveChanges();
                    LoadQuestions();
                    MessageBox.Show("Question deleted successfully.", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a question to delete.", "Delete Question", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}

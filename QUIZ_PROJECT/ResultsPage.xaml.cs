using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows.Controls;

namespace QUIZ_PROJECT
{
    public partial class ResultsPage : Page
    {
        private QuizContext _context;
        private string _userName;
        private string _userRole;
        private int _userId;

        public ResultsPage(string userName, string userRole, int userId)
        {
            InitializeComponent();
            _userName = userName;
            _userRole = userRole;
            _userId = userId;
            _context = new QuizContext();
            LoadResults();
        }

        private void LoadResults()
        {
            if (_userRole == "Student")
            {
                // Only load results for the current student
                ResultsDataGrid.ItemsSource = _context.Marks
                    .Include(m => m.Student)
                    .Include(m => m.Quiz)
                    .Where(m => m.Student.UserId == _userId)
                    .ToList();
            }
            else
            {
                // Load all results for Admin or Teacher roles
                ResultsDataGrid.ItemsSource = _context.Marks
                    .Include(m => m.Student)
                    .Include(m => m.Quiz)
                    .ToList();
            }
        }
    }
}

using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for ResultsPage.xaml
    /// </summary>
    public partial class ResultsPage : Page
    {
        private QuizContext _context;

        public ResultsPage()
        {
            InitializeComponent();
            _context = new QuizContext();
            LoadResults();
        }

        private void LoadResults()
        {
            ResultsDataGrid.ItemsSource = _context.Marks
                .Include(m => m.Student)
                .Include(m => m.Quiz)
                .ToList();
        }
    }
}

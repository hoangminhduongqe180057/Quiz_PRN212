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
    /// Interaction logic for CategoriesPage.xaml
    /// </summary>
    public partial class CategoriesPage : Page
    {
        private QuizContext _context;

        public CategoriesPage()
        {
            InitializeComponent();
            _context = new QuizContext();
            LoadCategories();
        }

        private void LoadCategories()
        {
            CategoriesDataGrid.ItemsSource = _context.Categories.ToList();
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CategoryNameTextBox.Text))
            {
                var category = new Category
                {
                    Name = CategoryNameTextBox.Text.Trim()
                };

                _context.Categories.Add(category);
                _context.SaveChanges();
                LoadCategories();

                // Clear the text box
                CategoryNameTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Category name cannot be empty.");
            }
        }

        private void EditCategory_Click(object sender, RoutedEventArgs e)
        {
            if (CategoriesDataGrid.SelectedItem is Category selectedCategory)
            {
                var newName = Microsoft.VisualBasic.Interaction.InputBox("Enter new category name:", "Edit Category", selectedCategory.Name);
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    selectedCategory.Name = newName;
                    _context.SaveChanges();
                    LoadCategories();
                }
            }
        }

        private void DeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            if (CategoriesDataGrid.SelectedItem is Category selectedCategory)
            {
                if (MessageBox.Show("Are you sure you want to delete this category?", "Delete Category", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _context.Categories.Remove(selectedCategory);
                    _context.SaveChanges();
                    LoadCategories();
                }
            }
        }
    }
}

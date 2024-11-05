using DataAccess.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace QUIZ_PROJECT
{
    public partial class CategoriesPage : Page
    {
        private QuizContext _context;
        private bool _isEditMode = false; // Flag for edit mode
        private int? _editingCategoryId = null; // Holds the ID of the category being edited

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

        private void SaveCategory_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CategoryNameTextBox.Text))
            {
                MessageBox.Show("Please enter a category name.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Check for duplicate category name
            var existingCategory = _context.Categories.FirstOrDefault(c => c.Name == CategoryNameTextBox.Text);

            if (_isEditMode && _editingCategoryId.HasValue)
            {
                // Editing an existing category
                if (existingCategory != null && existingCategory.Id != _editingCategoryId)
                {
                    MessageBox.Show("A category with this name already exists. Please enter a different name.", "Duplicate Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var category = _context.Categories.FirstOrDefault(c => c.Id == _editingCategoryId.Value);
                if (category != null)
                {
                    category.Name = CategoryNameTextBox.Text;
                    _context.SaveChanges();
                    MessageBox.Show("Category updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                // Adding a new category
                if (existingCategory != null)
                {
                    MessageBox.Show("A category with this name already exists. Please enter a different name.", "Duplicate Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var newCategory = new Category
                {
                    Name = CategoryNameTextBox.Text
                };

                _context.Categories.Add(newCategory);
                _context.SaveChanges();
                MessageBox.Show("Category added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            // Reset form and reload categories
            ResetForm();
            LoadCategories();
        }


        private void EditCategory_Click(object sender, RoutedEventArgs e)
        {
            if (CategoriesDataGrid.SelectedItem is Category selectedCategory)
            {
                // Populate the form with selected category's information for editing
                CategoryNameTextBox.Text = selectedCategory.Name;
                _isEditMode = true;
                _editingCategoryId = selectedCategory.Id;
                SaveCategoryButton.Content = "Update Category"; // Change button text to indicate edit mode
            }
        }

        private void DeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            if (CategoriesDataGrid.SelectedItem is Category selectedCategory)
            {
                var result = MessageBox.Show("Are you sure you want to delete this category?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    _context.Categories.Remove(selectedCategory);
                    _context.SaveChanges();
                    MessageBox.Show("Category deleted successfully.", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadCategories();
                }
            }
        }

        private void ResetForm()
        {
            CategoryNameTextBox.Clear();
            _isEditMode = false;
            _editingCategoryId = null;
            SaveCategoryButton.Content = "Save Category"; // Reset button text
        }
    }
}

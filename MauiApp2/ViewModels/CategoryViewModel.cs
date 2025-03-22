using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MauiApp2.Models;

namespace MauiApp2.ViewModels
{
    public class CategoryViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Category> Categories { get; set; }

        public ICommand AddCategoryCommand { get; }
        public ICommand DeleteCategoryCommand { get; }

        private Category selectedCategory;

        public Category SelectedCategory
        {
            get => selectedCategory;
            set
            {
                selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

        public CategoryViewModel()
        {
            Categories = new ObservableCollection<Category>
            {
                new Category { Id = 1, CategoryName = "Еда" },
                new Category { Id = 2, CategoryName = "Транспорт" },
                new Category { Id = 3, CategoryName = "Развлечения" },
                new Category { Id = 4, CategoryName = "Здоровье" }
            };

            AddCategoryCommand = new Command(AddCategory);
            DeleteCategoryCommand = new Command(DeleteCategory);
        }

        private void AddCategory()
        {
            var newCategory = new Category { CategoryName = "Новая категория" };
            Categories.Add(newCategory);
        }

        private void DeleteCategory()
        {
            if (SelectedCategory != null)
            {
                Categories.Remove(SelectedCategory);
            }
        }
    }
}

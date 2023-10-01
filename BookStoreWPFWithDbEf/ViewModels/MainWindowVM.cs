using BookStoreWPFWithDbEf.Models;
using BookStoreWPFWithDbEf.Tools;
using BookStoreWPFWithDbEf.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookStoreWPFWithDbEf.ViewModels
{
    public class MainWindowVM : NotifyPropertyChangedBase
    {
        private readonly BookStoreContext context;
        public MainWindowVM()
        {
            context = new BookStoreContext();
            Load();
        }
        private void Load()
        {
            allBooks = context.Books.ToList();
            OnPropertyChanged(nameof(Books));
        }

        #region authors

        public ICommand OpenAuthorsWindowCommand => new RelayCommand(x =>
        {
            var window = new AuthorsWindow();
            var wm = new AuthorsWindowVM(context);
            window.DataContext = wm;
            window.ShowDialog();
        });
        #endregion

        #region genres
        public ICommand OpenGenresWindowCommand => new RelayCommand(x =>
        {
            var window = new GenresWindow();
            var wm = new GenresWindowVM(context);
            window.DataContext = wm;
            window.ShowDialog();
        });
        #endregion

        #region customers
        public ICommand OpenCustomersWindowCommand => new RelayCommand(x =>
        {
            var window = new CustomersWindow();
            var wm = new CustomersWindowVM(context);
            window.DataContext = wm;
            window.ShowDialog();
        });
        #endregion

        #region Books

        private List<Books> allBooks;
        public ObservableCollection<BooksVM> Books
        {
            get => new(allBooks.Select(x => new BooksVM(x)));
        }

        public ICommand AddNewBookCommand => new RelayCommand(x =>
        {
            var window = new CustomersWindow();
            var wm = new CustomersWindowVM(context);
            window.DataContext = wm;
            window.ShowDialog();
        });
        #endregion
    }
}

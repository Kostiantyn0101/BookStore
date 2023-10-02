﻿using BookStoreWPFWithDbEf.Models;
using BookStoreWPFWithDbEf.Tools;
using BookStoreWPFWithDbEf.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

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
            allAuthors = context.Authors.ToList();
            OnPropertyChanged(nameof(Authors));

            allGenres = context.Genres.ToList();
            OnPropertyChanged(nameof(Genres));

            allBooks = context.Books.ToList();
            OnPropertyChanged(nameof(Books));
        }

        #region authors
        private List<Authors> allAuthors = new List<Authors>();

        public ObservableCollection<AuthorsVM> Authors
        {
            get => new(allAuthors.Select(x => new AuthorsVM(x)));
        }
        public ICommand OpenAuthorsWindowCommand => new RelayCommand(x =>
        {
            var window = new AuthorsWindow();
            var wm = new AuthorsWindowVM(context);
            window.DataContext = wm;
            window.ShowDialog();
        });
        #endregion

        #region genres

        private List<Genres> allGenres = new List<Genres>();

        public ObservableCollection<GenresVM> Genres
        {
            get => new(allGenres.Select(x => new GenresVM(x)));
        }
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

        private BooksVM selectedBook;
        public BooksVM SelectedBook
        {
            get => selectedBook;
            set
            {
                if (value != selectedBook)
                {
                    selectedBook = value;
                    OnPropertyChanged(nameof(SelectedBook));
                }
            }
        }

        public ICommand AddNewBookCommand => new RelayCommand(x =>
        {
            //var model = new BooksVM(new Books());
            var model = new Books();
            model.Title = "Title";
            model.Publisher = "Publisher";
            model.TotalPages = 0;
            model.Year = int.Parse(DateTime.Now.ToString("yyyy"));
            model.SalePrice = 0;
            model.CostPrice = 0;
            model.IsNew = false;
            var window = new BookWindow();
            window.DataContext = new BooksWindowVM(model, context);
            if (window.ShowDialog() == true)
            {
                allBooks.Add(model);
                context.Books.Add(model);
                OnPropertyChanged(nameof(Books));
            }
        });
        public ICommand EditBookCommand => new RelayCommand(x =>
        {
            var prevModel = new BooksVM(new Books());
            prevModel = SelectedBook;
            var window = new BookWindow();
            window.DataContext = new BooksWindowVM(SelectedBook.Model, context);

            if (window.ShowDialog() == true)
            {
                OnPropertyChanged(nameof(Books));
            }
            else
            {
                SelectedBook = prevModel;
            }
        }, x => SelectedBook != null);

        public ICommand DeleteBookCommand => new RelayCommand(x =>
        {
            if (SelectedBook != null)
            {
                context.Books.Remove(SelectedBook.Model);
                allBooks.Remove(SelectedBook.Model);
                OnPropertyChanged(nameof(Books));
            }
        });
        #endregion

        public ICommand SaveCommand => new RelayCommand(x =>
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Load();
        });
    }
}

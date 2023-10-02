using BookStoreWPFWithDbEf.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreWPFWithDbEf.Tools;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace BookStoreWPFWithDbEf.ViewModels
{
    public class BooksWindowVM : BooksVM
    {
        private ICollection<ReceiptVM> _receipts;
        private ICollection<ReservationVM> _reservations;
        private ICollection<SaleVM> _sales;
        private readonly BookStoreContext _context;

        public BooksWindowVM(Books model, BookStoreContext context) : base(model)
        {
            Model = model;
            _context = context;
            _receipts = context.ReceiptBook.Select(x => new ReceiptVM(x)).ToList();
            _sales = context.SaleBook.Select(x => new SaleVM(x)).ToList();
            _reservations = context.Reservation.Select(x => new ReservationVM(x)).ToList();
            _Load();

            SelectedInit();

        }

        private void _Load()
        {
            allAuthors = _context.Authors.ToList();
            OnPropertyChanged(nameof(Authors));
            allGenres = _context.Genres.ToList();
            OnPropertyChanged(nameof(Genres));
        }
        private void SelectedInit()
        {
            if (Model.Genres != null)
            {
                selectedGenre = new GenresVM(Model.Genres);
            }
            else 
            {
                selectedGenre = new GenresVM(allGenres.FirstOrDefault());
            }
            if (Model.Authors != null)
            {
                selectedAuthor = new AuthorsVM(Model.Authors);
            }
            else
            {
                selectedAuthor = new AuthorsVM(allAuthors.FirstOrDefault());
            }
        }
        private List<Authors> allAuthors = new List<Authors>();

        public ObservableCollection<AuthorsVM> _Authors
        {
            get => new(allAuthors.Select(x => new AuthorsVM(x)));
        }
        private AuthorsVM selectedAuthor;
        public AuthorsVM SelectedAuthor
        {
            get => selectedAuthor;
            set
            {
                if (value != selectedAuthor)
                {
                    selectedAuthor = value;
                    Model.Authors = selectedAuthor.Model;
                    OnPropertyChanged(nameof(SelectedAuthor));
                }
            }
        }
        private List<Genres> allGenres = new List<Genres>();

        public ObservableCollection<GenresVM> _Genres
        {
            get => new(allGenres.Select(x => new GenresVM(x)));
        }
        private GenresVM selectedGenre;
        public GenresVM SelectedGenre
        {
            get => selectedGenre;
            set
            {
                if (value != selectedGenre)
                {
                    selectedGenre = value;
                    Model.Genres = selectedGenre.Model;
                    OnPropertyChanged(nameof(SelectedGenre));
                }
            }
        }
        //public ICommand Save => new RelayCommand(x =>
        //{

        //});
        //public Books Model { get; set; }
        // public int Id { get => Model.Id; }
        //public string Title
        //{
        //    get => Model.Title;
        //    set
        //    {
        //        if (Model.Title != value)
        //        {
        //            Model.Title = value;
        //            OnPropertyChanged(nameof(Title));
        //        }
        //    }
        //}
        //public string Publisher
        //{
        //    get => Model.Publisher;
        //    set
        //    {
        //        if (Model.Publisher != value)
        //        {
        //            Model.Publisher = value;
        //            OnPropertyChanged(nameof(Publisher));
        //        }
        //    }
        //}
        //public int TotalPages
        //{
        //    get => Model.TotalPages;
        //    set
        //    {
        //        if (Model.TotalPages != value)
        //        {
        //            Model.TotalPages = value;
        //            OnPropertyChanged(nameof(TotalPages));
        //        }
        //    }
        //}
        //public int Year
        //{
        //    get => Model.Year;
        //    set
        //    {
        //        if (Model.Year != value)
        //        {
        //            Model.Year = value;
        //            OnPropertyChanged(nameof(Year));
        //        }
        //    }
        //}
        //public decimal SalePrice
        //{
        //    get => Model.SalePrice;
        //    set
        //    {
        //        if (Model.SalePrice != value)
        //        {
        //            Model.SalePrice = value;
        //            OnPropertyChanged(nameof(SalePrice));
        //        }
        //    }
        //}
        //public decimal CostPrice
        //{
        //    get => Model.CostPrice;
        //    set
        //    {
        //        if (Model.CostPrice != value)
        //        {
        //            Model.CostPrice = value;
        //            OnPropertyChanged(nameof(CostPrice));
        //        }
        //    }
        //}
        //public bool IsNew
        //{
        //    get => Model.IsNew;
        //    set
        //    {
        //        if (Model.IsNew != value)
        //        {
        //            Model.IsNew = value;
        //            OnPropertyChanged(nameof(IsNew));
        //        }
        //    }
        //}
        //public AuthorsVM Authors
        //{
        //    get => new AuthorsVM(Model.Authors);
        //    set
        //    {
        //        if (Model.Authors != value.Model)
        //        {
        //            Model.Authors = value.Model;
        //            OnPropertyChanged(nameof(Authors));
        //        }
        //    }
        //}
        //public GenresVM Genres
        //{
        //    get => new GenresVM(Model.Genres);
        //    set
        //    {
        //        if (Model.Genres != value.Model)
        //        {
        //            Model.Genres = value.Model;
        //            OnPropertyChanged(nameof(Genres));
        //        }
        //    }
        //}
        //public BooksVM ContinuationOfBook
        //{
        //    get => new BooksVM(Model.ContinuationOfBook);
        //    set
        //    {
        //        if (Model.ContinuationOfBook != value.Model)
        //        {
        //            Model.ContinuationOfBook = value.Model;
        //            OnPropertyChanged(nameof(ContinuationOfBook));
        //        }
        //    }
        //}
        //public int? ContinuationOfBookId
        //{
        //    get => Model.ContinuationOfBookId;
        //    set
        //    {
        //        if (Model.ContinuationOfBookId != value)
        //        {
        //            Model.ContinuationOfBookId = value;
        //            OnPropertyChanged(nameof(ContinuationOfBookId));
        //        }
        //    }
        //}
    }
}

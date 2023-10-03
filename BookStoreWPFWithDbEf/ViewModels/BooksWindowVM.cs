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
                Model.Genres = selectedGenre.Model;

            }
            if (Model.Authors != null)
            {
                selectedAuthor = new AuthorsVM(Model.Authors);
            }
            else
            {
                selectedAuthor = new AuthorsVM(allAuthors.FirstOrDefault());
                Model.Authors = selectedAuthor.Model;

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
    }
}

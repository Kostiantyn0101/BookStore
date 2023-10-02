using BookStoreWPFWithDbEf.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreWPFWithDbEf.Tools;

namespace BookStoreWPFWithDbEf.ViewModels
{
    public class BooksVM : NotifyPropertyChangedBase
    {
        private ICollection<ReceiptVM> _receipts;
        private ICollection<ReservationVM> _reservations;
        private ICollection<SaleVM> _sales;

        public BooksVM(Books model)
        {
            Model = model;
        }

        public void Load()
        {
            _receipts = Model.Receipts.Select(x => new ReceiptVM(x)).ToList();
            _sales = Model.Sales.Select(x => new SaleVM(x)).ToList();
            _reservations = Model.Reservations.Select(x => new ReservationVM(x)).ToList();
        }

        public Books Model { get; set; }
        public int Id { get => Model.Id; }
        public string Title
        {
            get => Model.Title;
            set
            {
                if (Model.Title != value)
                {
                    Model.Title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }
        public string Publisher
        {
            get => Model.Publisher;
            set
            {
                if (Model.Publisher != value)
                {
                    Model.Publisher = value;
                    OnPropertyChanged(nameof(Publisher));
                }
            }
        }
        public int TotalPages
        {
            get => Model.TotalPages;
            set
            {
                if (Model.TotalPages != value)
                {
                    Model.TotalPages = value;
                    OnPropertyChanged(nameof(TotalPages));
                }
            }
        }
        public int Year
        {
            get => Model.Year;
            set
            {
                if (Model.Year != value)
                {
                    Model.Year = value;
                    OnPropertyChanged(nameof(Year));
                }
            }
        }
        public decimal SalePrice
        {
            get => Model.SalePrice;
            set
            {
                if (Model.SalePrice != value)
                {
                    Model.SalePrice = value;
                    OnPropertyChanged(nameof(SalePrice));
                }
            }
        }
        public decimal CostPrice
        {
            get => Model.CostPrice;
            set
            {
                if (Model.CostPrice != value)
                {
                    Model.CostPrice = value;
                    OnPropertyChanged(nameof(CostPrice));
                }
            }
        }
        public bool IsNew
        {
            get => Model.IsNew;
            set
            {
                if (Model.IsNew != value)
                {
                    Model.IsNew = value;
                    OnPropertyChanged(nameof(IsNew));
                }
            }
        }
        public AuthorsVM Authors
        {
            get => new AuthorsVM(Model.Authors);
            set
            {
                if (Model.Authors != value.Model)
                {
                    Model.Authors = value.Model;
                    OnPropertyChanged(nameof(Authors));
                }
            }
        }
        public GenresVM Genres
        {
            get => new GenresVM(Model.Genres);
            set
            {
                if (Model.Genres != value.Model)
                {
                    Model.Genres = value.Model;
                    OnPropertyChanged(nameof(Genres));
                }
            }
        }
        public BooksVM ContinuationOfBook
        {
            get => new BooksVM(Model.ContinuationOfBook);
            set
            {
                if (Model.ContinuationOfBook != value.Model)
                {
                    Model.ContinuationOfBook = value.Model;
                    OnPropertyChanged(nameof(ContinuationOfBook));
                }
            }
        }
        public int? ContinuationOfBookId
        {
            get => Model.ContinuationOfBookId;
            set
            {
                if (Model.ContinuationOfBookId != value)
                {
                    Model.ContinuationOfBookId = value;
                    OnPropertyChanged(nameof(ContinuationOfBookId));
                }
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not BooksVM model) return false;
            if ((obj as BooksVM).Model == null) return false;
            return Model.Id.Equals((obj as BooksVM).Model.Id);
        }
    }
}

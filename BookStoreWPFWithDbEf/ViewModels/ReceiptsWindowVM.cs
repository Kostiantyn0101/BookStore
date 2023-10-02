using BookStoreWPFWithDbEf.Models;
using BookStoreWPFWithDbEf.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BookStoreWPFWithDbEf.ViewModels
{
    public class ReceiptsWindowVM : NotifyPropertyChangedBase
    {
        private readonly BookStoreContext context;

        public ReceiptsWindowVM(BookStoreContext Сontext)
        {
            context = Сontext;
            //SelectedInit();
            Load();
        }
        private void Load()
        {
            allReceipts = context.ReceiptBook.ToList();
            OnPropertyChanged(nameof(Receipts));
            allBooks = context.Books.ToList();
            OnPropertyChanged(nameof(Books));
        }
        //private void SelectedInit()
        //{
        //    if (Model.Genres != null)
        //    {
        //        selectedGenre = new GenresVM(Model.Genres);
        //    }
        //    else
        //    {
        //        selectedGenre = new GenresVM(allGenres.FirstOrDefault());
        //    }
        //    if (Model.Authors != null)
        //    {
        //        selectedAuthor = new AuthorsVM(Model.Authors);
        //    }
        //    else
        //    {
        //        selectedAuthor = new AuthorsVM(allAuthors.FirstOrDefault());
        //    }
        //}
        private List<ReceiptBook> allReceipts = new List<ReceiptBook>();

        public ObservableCollection<ReceiptVM> Receipts
        {
            get => new(allReceipts.Select(x => new ReceiptVM(x)));
        }
        private ReceiptVM selectedReceipt;
        public ReceiptVM SelectedReceipt
        {
            get => selectedReceipt;
            set
            {
                if (value != selectedReceipt)
                {
                    selectedReceipt = value;
                    OnPropertyChanged(nameof(SelectedReceipt));
                }
            }
        }
        private List<Books> allBooks = new List<Books>();

        public ObservableCollection<BooksVM> Books
        {
            get => new(allBooks.Select(x => new BooksVM(x)));
        }
        //private BooksVM selectedBook;
        //public BooksVM SelectedBook
        //{
        //    get => selectedBook;
        //    set
        //    {
        //        if (value != selectedBook)
        //        {
        //            selectedBook = value;
        //            OnPropertyChanged(nameof(SelectedBook));
        //        }
        //    }
        //}
        public ICommand AddNewCommand => new RelayCommand(x =>
        {
            var model = new ReceiptBook() { };
            model.Book = allBooks.FirstOrDefault();
            model.Time = DateTime.Now;
            context.Add(model);
            allReceipts.Add(model);
            OnPropertyChanged(nameof(Receipts));
            OnPropertyChanged(nameof(SelectedReceipt));
        });
        public ICommand DeleteCommand => new RelayCommand(x =>
        {
            if (SelectedReceipt != null)
            {
                context.ReceiptBook.Remove(SelectedReceipt.Model);
                allReceipts.Remove(SelectedReceipt.Model);
                OnPropertyChanged(nameof(Receipts));
            }
        });
        public ICommand SaveCommand => new RelayCommand(x =>
        {
            context.SaveChanges();
            Load();
        });
    }
}

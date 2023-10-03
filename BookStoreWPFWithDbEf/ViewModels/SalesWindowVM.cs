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
    public class SalesWindowVM : NotifyPropertyChangedBase
    {
        private readonly BookStoreContext context;

        public SalesWindowVM(BookStoreContext Сontext)
        {
            context = Сontext;
            Load();
        }
        private void Load()
        {
            allSales = context.SaleBook.ToList();
            OnPropertyChanged(nameof(Sales));
            allBooks = context.Books.ToList();
            OnPropertyChanged(nameof(Books));
        }
        private List<SaleBook> allSales = new List<SaleBook>();

        public ObservableCollection<SaleVM> Sales
        {
            get => new(allSales.Select(x => new SaleVM(x)));
        }
        private SaleVM selectedSale;
        public SaleVM SelectedSale
        {
            get => selectedSale;
            set
            {
                if (value != selectedSale)
                {
                    selectedSale = value;
                    OnPropertyChanged(nameof(SelectedSale));
                }
            }
        }
        private List<Books> allBooks = new List<Books>();

        public ObservableCollection<BooksVM> Books
        {
            get => new(allBooks.Select(x => new BooksVM(x)));
        }
        public ICommand AddNewCommand => new RelayCommand(x =>
        {
            var model = new SaleBook() { };
            model.Book = allBooks.FirstOrDefault();
            model.Time = DateTime.Now;
            context.Add(model);
            allSales.Add(model);
            OnPropertyChanged(nameof(Sales));
            OnPropertyChanged(nameof(SelectedSale));
        });
        public ICommand DeleteCommand => new RelayCommand(x =>
        {
            if (SelectedSale != null)
            {
                context.SaleBook.Remove(SelectedSale.Model);
                allSales.Remove(SelectedSale.Model);
                OnPropertyChanged(nameof(Sales));
            }
        });
        public ICommand SaveCommand => new RelayCommand(x =>
        {
            context.SaveChanges();
            MessageBox.Show("Saved");
            Load();
        });
    }
}

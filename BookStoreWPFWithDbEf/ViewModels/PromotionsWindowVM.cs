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
    public class PromotionsWindowVM : NotifyPropertyChangedBase
    {
        private readonly BookStoreContext context;

        public PromotionsWindowVM(BookStoreContext Сontext)
        {
            context = Сontext;
            Load();
        }
        private void Load()
        {
            allPromotions = context.Promotions.ToList();
            OnPropertyChanged(nameof(Promotions));
            allBooks = context.Books.ToList();
            OnPropertyChanged(nameof(Books));
        }
        private List<Promotions> allPromotions = new List<Promotions>();

        public ObservableCollection<PromotionsVM> Promotions
        {
            get => new(allPromotions.Select(x => new PromotionsVM(x)));
        }
        private PromotionsVM selectedPromotion;
        public PromotionsVM SelectedPromotion
        {
            get => selectedPromotion;
            set
            {
                if (value != selectedPromotion)
                {
                    selectedPromotion = value;
                    OnPropertyChanged(nameof(SelectedPromotion));
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
            var model = new Promotions() { };
            model.Book = allBooks.FirstOrDefault();
            model.Start = DateTime.Now;
            model.End = DateTime.Now;
            model.Discount = 0;
            context.Add(model);
            allPromotions.Add(model);
            OnPropertyChanged(nameof(Promotions));
            OnPropertyChanged(nameof(SelectedPromotion));
        });
        public ICommand DeleteCommand => new RelayCommand(x =>
        {
            if (SelectedPromotion != null)
            {
                context.Promotions.Remove(SelectedPromotion.Model);
                allPromotions.Remove(SelectedPromotion.Model);
                OnPropertyChanged(nameof(Promotions));
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

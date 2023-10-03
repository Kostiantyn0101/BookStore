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
    public class WriteOffWindowVM : NotifyPropertyChangedBase
    {
        private readonly BookStoreContext context;

        public WriteOffWindowVM(BookStoreContext Сontext)
        {
            context = Сontext;
            Load();
        }
        private void Load()
        {
            allWriteOffs = context.WriteOff.ToList();
            OnPropertyChanged(nameof(WriteOffs));
            allBooks = context.Books.ToList();
            OnPropertyChanged(nameof(Books));
        }
        private List<WriteOff> allWriteOffs = new List<WriteOff>();

        public ObservableCollection<WriteOffVM> WriteOffs
        {
            get => new(allWriteOffs.Select(x => new WriteOffVM(x)));
        }
        private WriteOffVM selectedWriteOff;
        public WriteOffVM SelectedWriteOff
        {
            get => selectedWriteOff;
            set
            {
                if (value != selectedWriteOff)
                {
                    selectedWriteOff = value;
                    OnPropertyChanged(nameof(SelectedWriteOff));
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
            var model = new WriteOff() { };
            model.Book = allBooks.FirstOrDefault();
            model.Time = DateTime.Now;
            context.Add(model);
            allWriteOffs.Add(model);
            OnPropertyChanged(nameof(WriteOffs));
            OnPropertyChanged(nameof(SelectedWriteOff));
        });
        public ICommand DeleteCommand => new RelayCommand(x =>
        {
            if (SelectedWriteOff != null)
            {
                context.WriteOff.Remove(SelectedWriteOff.Model);
                allWriteOffs.Remove(SelectedWriteOff.Model);
                OnPropertyChanged(nameof(WriteOffs));
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

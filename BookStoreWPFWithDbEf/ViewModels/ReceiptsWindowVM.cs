﻿using BookStoreWPFWithDbEf.Models;
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
            Load();
        }
        private void Load()
        {
            allReceipts = context.ReceiptBook.ToList();
            OnPropertyChanged(nameof(Receipts));
            allBooks = context.Books.ToList();
            OnPropertyChanged(nameof(Books));
        }
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
            MessageBox.Show("Saved");
            Load();
        });
    }
}

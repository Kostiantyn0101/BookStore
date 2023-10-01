using BookStoreWPFWithDbEf.Models;
using BookStoreWPFWithDbEf.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWPFWithDbEf.ViewModels
{
    public class SaleVM : NotifyPropertyChangedBase
    {
        public SaleVM(SaleBook model)
        {
            Model = model;
        }
        public SaleBook Model { get; set; }
        public int Id { get => Model.Id; }
        public DateTime Time
        {
            get => Model.Time;
            set
            {
                Model.Time = value;
                OnPropertyChanged(nameof(Time));
            }
        }
        public BooksVM Book
        {
            get => new BooksVM(Model.Book);
            set
            {
                Model.Book = value.Model;
                OnPropertyChanged(nameof(Book));
            }
        }
        public int Count
        {
            get => Model.Count;
            set
            {
                Model.Count = value;
                OnPropertyChanged(nameof(Count));
            }
        }
        public decimal Price
        {
            get => Model.Price;
            set
            {
                Model.Price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
    }
}

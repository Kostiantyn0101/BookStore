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
    public class ReservationVM : NotifyPropertyChangedBase
    {
        public ReservationVM(Reservation model)
        {
            Model = model;
        }
        public Reservation Model { get; set; }
        public int Id { get => Model.Id; }
        public DateTime Time
        {
            get => Model.Time;
            set
            {
                if (Model.Time != value)
                {
                    Model.Time = value;
                    OnPropertyChanged(nameof(Time));
                }
            }
        }
        public BooksVM Book
        {
            get => new BooksVM(Model.Book);
            set
            {
                if (Model.Book != value.Model)
                {
                    Model.Book = value.Model;
                    OnPropertyChanged(nameof(Book));
                }
            }
        }
        public int Count
        {
            get => Model.Count;
            set
            {
                if (Model.Count != value)
                {
                    Model.Count = value;
                    OnPropertyChanged(nameof(Count));
                }
            }
        }
        public decimal Price
        {
            get => Model.Price;
            set
            {
                if (Model.Price != value)
                {
                    Model.Price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }
    }
}

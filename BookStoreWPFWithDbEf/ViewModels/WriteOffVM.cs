using BookStoreWPFWithDbEf.Models;
using BookStoreWPFWithDbEf.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWPFWithDbEf.ViewModels
{
    public class WriteOffVM : NotifyPropertyChangedBase
    {
        public WriteOffVM(WriteOff model)
        {
            Model = model;
        }
        public WriteOff Model { get; set; }
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
        public string Description
        {
            get => Model.Description;
            set
            {
                if (Model.Description != value)
                {
                    Model.Description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }
    }
}

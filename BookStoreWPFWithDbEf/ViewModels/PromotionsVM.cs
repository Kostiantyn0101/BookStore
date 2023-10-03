using BookStoreWPFWithDbEf.Models;
using BookStoreWPFWithDbEf.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWPFWithDbEf.ViewModels
{
    public class PromotionsVM : NotifyPropertyChangedBase
    {
        public PromotionsVM(Promotions model)
        {
            Model = model;
        }
        public Promotions Model { get; set; }
        public int Id { get => Model.Id; }
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
        public DateTime Start
        {
            get => Model.Start;
            set
            {
                if (Model.Start != value)
                {
                    Model.Start = value;
                    OnPropertyChanged(nameof(Start));
                }
            }
        }
        public DateTime End
        {
            get => Model.End;
            set
            {
                if (Model.End != value)
                {
                    Model.End = value;
                    OnPropertyChanged(nameof(End));
                }
            }
        }
        public int Discount
        {
            get => Model.Discount;
            set
            {
                if (Model.Discount != value)
                {
                    Model.Discount = value;
                    OnPropertyChanged(nameof(Discount));
                }
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not PromotionsVM model) return false;
            if ((obj as PromotionsVM).Model == null) return false;
            return Model.Id.Equals((obj as PromotionsVM).Model.Id);
        }
    }
}
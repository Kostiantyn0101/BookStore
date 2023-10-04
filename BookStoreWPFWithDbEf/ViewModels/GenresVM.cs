using BookStoreWPFWithDbEf.Models;
using BookStoreWPFWithDbEf.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWPFWithDbEf.ViewModels
{
    public class GenresVM : NotifyPropertyChangedBase
    {
        public GenresVM(Genres model)
        {
            Model = model;
        }
        public Genres Model { get; set; }
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
        private int bookCount;
        public int BookCount
        {
            get { return bookCount; }
            set
            {
                if (bookCount != value)
                {
                    bookCount = value;
                    OnPropertyChanged(nameof(BookCount));
                }
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not GenresVM model) return false;
            if ((obj as GenresVM).Model == null) return false;
            return Model.Id.Equals((obj as GenresVM).Model.Id);
        }
    }
}

using BookStoreWPFWithDbEf.Models;
using BookStoreWPFWithDbEf.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWPFWithDbEf.ViewModels
{
    public class AuthorsVM : NotifyPropertyChangedBase
    {
        public Authors Model { get; set; }
        public AuthorsVM(Authors model)
        {
            Model = model;
        }
        public int Id { get => Model.Id; }
        public string FullName
        {
            get => Model.FullName;
            set
            {
                if (Model.FullName != value)
                {
                    Model.FullName = value;
                    OnPropertyChanged(nameof(FullName));
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
            if (obj is not AuthorsVM model) return false;
            if ((obj as AuthorsVM).Model == null) return false;
            return Model.Id.Equals((obj as AuthorsVM).Model.Id);
        }
    }
}

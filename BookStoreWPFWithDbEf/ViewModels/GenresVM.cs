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
                Model.Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
    }
}

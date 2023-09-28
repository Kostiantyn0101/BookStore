using BookStoreWPFWithDbEf.Models;
using BookStoreWPFWithDbEf.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWPFWithDbEf.ViewModels
{
    public class AuthorsVM :NotifyPropertyChangedBase
    {
        public AuthorsVM(Authors model) 
        {
            Model = model;
        }
        public Authors Model { get; set; }
        public int Id { get => Model.Id; }
        public string FullName
        { 
            get => Model.FullName;
            set
            {
                Model.FullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }
    }
}

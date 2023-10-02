using BookStoreWPFWithDbEf.Models;
using BookStoreWPFWithDbEf.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace BookStoreWPFWithDbEf.ViewModels
{
    public class AuthorsWindowVM : NotifyPropertyChangedBase
    {
        private readonly BookStoreContext context;

        public AuthorsWindowVM(BookStoreContext Сontext)
        {
            context = Сontext;
            Load();
        }
        private void Load()
        {
            allAuthors = context.Authors.ToList();
            OnPropertyChanged(nameof(Authors));
        }

        private List<Authors> allAuthors = new List<Authors>();

        public ObservableCollection<AuthorsVM> Authors
        {
            get => new(allAuthors.Select(x => new AuthorsVM(x)));
        }
        private AuthorsVM selectedAuthor;
        public AuthorsVM SelectedAuthor
        {
            get => selectedAuthor;
            set
            {
                if (value != selectedAuthor)
                {
                    selectedAuthor = value;
                    OnPropertyChanged(nameof(SelectedAuthor));
                }
            }
        }
        public ICommand AddNewCommand => new RelayCommand(x =>
        {
            var author = new Authors();
            context.Add(author);
            allAuthors.Add(author);
            OnPropertyChanged(nameof(Authors));
            OnPropertyChanged(nameof(SelectedAuthor));
        });
        public ICommand DeleteCommand => new RelayCommand(x =>
        {
            if (SelectedAuthor != null)
            {
                context.Authors.Remove(SelectedAuthor.Model);
                allAuthors.Remove(SelectedAuthor.Model);
                OnPropertyChanged(nameof(Authors));
            }
        });
        public ICommand SaveCommand => new RelayCommand(x =>
        {
            if (SelectedAuthor != null)
            {
                context.SaveChanges();
                Load();
            }
            else
            {
                MessageBox.Show("Empty Data");
            }
        });
    }
}

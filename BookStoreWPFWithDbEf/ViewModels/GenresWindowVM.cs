using BookStoreWPFWithDbEf.Models;
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
    internal class GenresWindowVM : NotifyPropertyChangedBase
    {
        private readonly BookStoreContext context;

        public GenresWindowVM(BookStoreContext Сontext)
        {
            context = Сontext;
            Load();
        }
        private void Load()
        {
            allGenres = context.Genres.ToList();
            OnPropertyChanged(nameof(Genres));
        }

        private List<Genres> allGenres = new List<Genres>();

        public ObservableCollection<GenresVM> Genres
        {
            get => new(allGenres.Select(x => new GenresVM(x)));
        }
        private GenresVM selectedGenre;
        public GenresVM SelectedGenre
        {
            get => selectedGenre;
            set
            {
                if (value != selectedGenre)
                {
                    selectedGenre = value;
                    OnPropertyChanged(nameof(SelectedGenre));
                }
            }
        }
        public ICommand AddNewCommand => new RelayCommand(x =>
        {
            var genre = new Genres();
            context.Add(genre);
            allGenres.Add(genre);
            OnPropertyChanged(nameof(Genres));
            OnPropertyChanged(nameof(SelectedGenre));
        });
        public ICommand DeleteCommand => new RelayCommand(x =>
        {
            if (SelectedGenre != null)
            {
                context.Genres.Remove(SelectedGenre.Model);
                allGenres.Remove(SelectedGenre.Model);
                OnPropertyChanged(nameof(Genres));
            }
        });
        public ICommand SaveCommand => new RelayCommand(x =>
        {
            if (SelectedGenre != null)
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

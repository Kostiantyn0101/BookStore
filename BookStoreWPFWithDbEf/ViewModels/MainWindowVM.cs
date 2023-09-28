using BookStoreWPFWithDbEf.Models;
using BookStoreWPFWithDbEf.Tools;
using BookStoreWPFWithDbEf.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookStoreWPFWithDbEf.ViewModels
{
    public class MainWindowVM : NotifyPropertyChangedBase
    {
        private readonly BookStoreContext context;
        public MainWindowVM()
        {
            context = new BookStoreContext();
            Load();
        }
        private void Load()
        {
            //allAuthors = context.Authors.ToList();
            //OnPropertyChanged(nameof(Authors));
        }

        #region authors
        //private List<Authors> allAuthors;
        //public ObservableCollection<AuthorsVM> Authors
        //{
        //    get => new(allAuthors.Select(x => new AuthorsVM(x)));
        //}

        public ICommand OpenAuthorsWindowCommand => new RelayCommand(x =>
        {
            var window = new AuthorsWindow();
            var wm = new AuthorsWindowVM(context);
            window.DataContext = wm;
            window.ShowDialog();
        });
        #endregion

        #region genres
        public ICommand OpenGenresWindowCommand => new RelayCommand(x =>
        {
            var window = new GenresWindow();
            var wm = new GenresWindowVM(context);
            window.DataContext = wm;
            window.ShowDialog();
        });
        #endregion
    }
}

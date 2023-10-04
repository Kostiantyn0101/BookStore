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
    public class StatisticWindowVM : NotifyPropertyChangedBase
    {
        private readonly BookStoreContext context;

        public StatisticWindowVM(BookStoreContext Сontext)
        {
            context = Сontext;
            //Load();
        }
        public List<Books> GetNewBooks
        {
            get => context.Books.Where(book => book.IsNew == true).ToList();
        }

        #region BookStatistic
        private ObservableCollection<BooksVM> statisticBookList = new ObservableCollection<BooksVM>();

        public ObservableCollection<BooksVM> StatisticBookList
        {
            get => statisticBookList;
            set
            {
                if (statisticBookList != value)
                {
                    statisticBookList = value;
                    OnPropertyChanged(nameof(StatisticBookList));
                }
            }
        }
        public ICommand TodayBookStatisticCommand => new RelayCommand(x =>
        {
            DateTime today = DateTime.Today;
            var popularBooksToday = context.SaleBook
                .Where(s => s.Time.Date == today)
                .GroupBy(s => s.Id)
                .OrderByDescending(g => g.Count())
                .Select(g => new BooksVM(context.Books.FirstOrDefault(b => b.Id == g.Key)))
                .Take(10)
                .ToList();
            if (popularBooksToday.Count == 0)
            {
                MessageBox.Show("Nothing sold today");
            }
            StatisticBookList.Clear();
            StatisticBookList = new ObservableCollection<BooksVM>(popularBooksToday);
        });

        public ICommand WeekBookStatisticCommand => new RelayCommand(x =>
        {
            DateTime startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            DateTime endOfWeek = startOfWeek.AddDays(6);

            var popularBooksWeek = context.SaleBook
                .Where(s => s.Time >= startOfWeek && s.Time <= endOfWeek)
                .GroupBy(s => s.Id)
                .OrderByDescending(g => g.Count())
                .Select(g => new BooksVM(context.Books.FirstOrDefault(b => b.Id == g.Key)))
                .Take(10)
                .ToList();

            StatisticBookList.Clear();
            StatisticBookList = new ObservableCollection<BooksVM>(popularBooksWeek);
        });

        public ICommand MonthBookStatisticCommand => new RelayCommand(x =>
        {
            DateTime startOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            var popularBooksMonth = context.SaleBook
                .Where(s => s.Time >= startOfMonth && s.Time <= endOfMonth)
                .GroupBy(s => s.Id)
                .OrderByDescending(g => g.Count())
                .Select(g => new BooksVM(context.Books.FirstOrDefault(b => b.Id == g.Key)))
                .Take(10)
                .ToList();

            StatisticBookList.Clear();
            StatisticBookList = new ObservableCollection<BooksVM>(popularBooksMonth);
        });

        public ICommand YearBookStatisticCommand => new RelayCommand(x =>
        {
            DateTime startOfYear = new DateTime(DateTime.Today.Year, 1, 1);
            DateTime endOfYear = new DateTime(DateTime.Today.Year, 12, 31);

            var popularBooksYear = context.SaleBook
                .Where(s => s.Time >= startOfYear && s.Time <= endOfYear)
                .GroupBy(s => s.Id)
                .OrderByDescending(g => g.Count())
                .Select(g => new BooksVM(context.Books.FirstOrDefault(b => b.Id == g.Key)))
                .Take(10)
                .ToList();

            StatisticBookList.Clear();
            StatisticBookList = new ObservableCollection<BooksVM>(popularBooksYear);
        });
        #endregion

        #region AuthorStatistic
        private ObservableCollection<AuthorsVM> statisticAuthorList = new ObservableCollection<AuthorsVM>();

        public ObservableCollection<AuthorsVM> StatisticAuthorList
        {
            get => statisticAuthorList;
            set
            {
                if (statisticAuthorList != value)
                {
                    statisticAuthorList = value;
                    OnPropertyChanged(nameof(StatisticAuthorList));
                }
            }
        }
        public ICommand TodayAuthorStatisticCommand => new RelayCommand(x =>
        {
            DateTime today = DateTime.Today;
            SetAuthorsStatisticsForPeriod(today, today);
        });

        public ICommand WeekAuthorStatisticCommand => new RelayCommand(x =>
        {
            DateTime startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            DateTime endOfWeek = startOfWeek.AddDays(6);
            SetAuthorsStatisticsForPeriod(startOfWeek, endOfWeek);
        });

        public ICommand MonthAuthorStatisticCommand => new RelayCommand(x =>
        {
            DateTime startOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
            SetAuthorsStatisticsForPeriod(startOfMonth, endOfMonth);
        });

        public ICommand YearAuthorStatisticCommand => new RelayCommand(x =>
        {
            DateTime startOfYear = new DateTime(DateTime.Today.Year, 1, 1);
            DateTime endOfYear = new DateTime(DateTime.Today.Year, 12, 31);
            SetAuthorsStatisticsForPeriod(startOfYear, endOfYear);
        });

        private void SetAuthorsStatisticsForPeriod(DateTime startDate, DateTime endDate)
        {
            var popularAuthors = context.SaleBook
                .Where(s => s.Time >= startDate && s.Time <= endDate)
                .Select(s => s.Book.Authors)
                .GroupBy(a => a.Id)
                .OrderByDescending(g => g.Count())
                .Select(g => new AuthorsVM(context.Authors.FirstOrDefault(a => a.Id == g.Key)))
                .Take(10)
                .ToList();

            foreach (var authorVM in popularAuthors)
            {
                var authorId = authorVM.Model.Id;
                var bookCount = context.SaleBook.Count(s => s.Book.Authors.Id == authorId && s.Time >= startDate && s.Time <= endDate);
                authorVM.BookCount = bookCount;
            }

            StatisticAuthorList.Clear();
            foreach (var author in popularAuthors)
            {
                StatisticAuthorList.Add(author);
            }
        }









        #endregion

        #region GenreStatistic

        private ObservableCollection<GenresVM> statisticGenreList = new ObservableCollection<GenresVM>();

        public ObservableCollection<GenresVM> StatisticGenreList
        {
            get => statisticGenreList;
            set
            {
                if (statisticGenreList != value)
                {
                    statisticGenreList = value;
                    OnPropertyChanged(nameof(StatisticGenreList));
                }
            }
        }
        public ICommand TodayGenreStatisticCommand => new RelayCommand(x =>
        {
            DateTime today = DateTime.Today;
            SetGenresStatisticsForPeriod(today, today);
        });

        public ICommand WeekGenreStatisticCommand => new RelayCommand(x =>
        {
            DateTime startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            DateTime endOfWeek = startOfWeek.AddDays(6);
            SetGenresStatisticsForPeriod(startOfWeek, endOfWeek);
        });

        public ICommand MonthGenreStatisticCommand => new RelayCommand(x =>
        {
            DateTime startOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
            SetGenresStatisticsForPeriod(startOfMonth, endOfMonth);
        });

        public ICommand YearGenreStatisticCommand => new RelayCommand(x =>
        {
            DateTime startOfYear = new DateTime(DateTime.Today.Year, 1, 1);
            DateTime endOfYear = new DateTime(DateTime.Today.Year, 12, 31);
            SetGenresStatisticsForPeriod(startOfYear, endOfYear);
        });
        private void SetGenresStatisticsForPeriod(DateTime startDate, DateTime endDate)
        {
            var popularGenres = context.SaleBook
                .Where(s => s.Time >= startDate && s.Time <= endDate)
                .Select(s => s.Book.Genres)
                .GroupBy(g => g.Id)
                .OrderByDescending(g => g.Count())
                .Select(g => new GenresVM(context.Genres.FirstOrDefault(genre => genre.Id == g.Key)))
                .Take(10)
                .ToList();

            foreach (var genreVM in popularGenres)
            {
                var genreId = genreVM.Model.Id;
                var bookCount = context.SaleBook.Count(s => s.Book.Genres.Id == genreId && s.Time >= startDate && s.Time <= endDate);
                genreVM.BookCount = bookCount;
            }
            StatisticGenreList.Clear();
            foreach (var genre in popularGenres)
            {
                StatisticGenreList.Add(genre);
            }
        }
        #endregion
    }
}

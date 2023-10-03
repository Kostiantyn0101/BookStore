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
    public class ReservationWindowVM : NotifyPropertyChangedBase
    {
        private readonly BookStoreContext context;

        public ReservationWindowVM(BookStoreContext Сontext)
        {
            context = Сontext;
            Load();
        }
        private void Load()
        {
            allReservations = context.Reservation.ToList();
            OnPropertyChanged(nameof(Reservations));
            allCustomers = context.Customers.ToList();
            OnPropertyChanged(nameof(Customers));
            allBooks = context.Books.ToList();
            OnPropertyChanged(nameof(Books));
        }
        private List<Reservation> allReservations = new List<Reservation>();

        public ObservableCollection<ReservationVM> Reservations
        {
            get => new(allReservations.Select(x => new ReservationVM(x)));
        }
        private ReservationVM selectedReservation;
        public ReservationVM SelectedReservation
        {
            get => selectedReservation;
            set
            {
                if (value != selectedReservation)
                {
                    selectedReservation = value;
                    OnPropertyChanged(nameof(SelectedReservation));
                }
            }
        }
        private List<Customers> allCustomers = new List<Customers>();

        public ObservableCollection<CustomersVM> Customers
        {
            get => new(allCustomers.Select(x => new CustomersVM(x)));
        }
        private List<Books> allBooks = new List<Books>();
        public ObservableCollection<BooksVM> Books
        {
            get => new(allBooks.Select(x => new BooksVM(x)));
        }
        public ICommand AddNewCommand => new RelayCommand(x =>
        {
            var model = new Reservation() { };
            model.Book = allBooks.FirstOrDefault();
            model.Time = DateTime.Now;
            model.Customer = allCustomers.FirstOrDefault();
            context.Add(model);
            allReservations.Add(model);
            OnPropertyChanged(nameof(Reservations));
            OnPropertyChanged(nameof(SelectedReservation));
        });
        public ICommand DeleteCommand => new RelayCommand(x =>
        {
            if (SelectedReservation != null)
            {
                context.Reservation.Remove(SelectedReservation.Model);
                allReservations.Remove(SelectedReservation.Model);
                OnPropertyChanged(nameof(Reservations));
            }
        });
        public ICommand SaveCommand => new RelayCommand(x =>
        {
            context.SaveChanges();
            MessageBox.Show("Saved");
            Load();
        });
    }
}

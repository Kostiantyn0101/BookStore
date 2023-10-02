using BookStoreWPFWithDbEf.Models;
using BookStoreWPFWithDbEf.Tools;
using Microsoft.EntityFrameworkCore.Metadata;
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
    public class CustomersWindowVM : NotifyPropertyChangedBase
    {
        private readonly BookStoreContext context;

        public CustomersWindowVM(BookStoreContext Сontext)
        {
            context = Сontext;
            Load();
        }
        private void Load()
        {
            allCustomers = context.Customers.ToList();
            OnPropertyChanged(nameof(Customers));
        }

        private List<Customers> allCustomers = new List<Customers>();

        public ObservableCollection<CustomersVM> Customers
        {
            get => new(allCustomers.Select(x => new CustomersVM(x)));
        }
        private CustomersVM selectedCustomers;
        public CustomersVM SelectedCustomers
        {
            get => selectedCustomers;
            set
            {
                if (value != selectedCustomers)
                {
                    selectedCustomers = value;
                    OnPropertyChanged(nameof(SelectedCustomers));
                }
            }
        }
        public ICommand AddNewCommand => new RelayCommand(x =>
        {
            var author = new Customers()
            {
                FirstName = string.Empty,
                LastName = string.Empty,
                PhoneNumber = string.Empty,
                Email = string.Empty,
                Login = string.Empty,
                Password = string.Empty,
            };
            context.Add(author);
            allCustomers.Add(author);
            OnPropertyChanged(nameof(Customers));
            OnPropertyChanged(nameof(SelectedCustomers));
        });
        public ICommand DeleteCommand => new RelayCommand(x =>
        {
            if (SelectedCustomers != null)
            {
                context.Customers.Remove(SelectedCustomers.Model);
                allCustomers.Remove(SelectedCustomers.Model);
                OnPropertyChanged(nameof(Customers));
            }
        });
        public ICommand SaveCommand => new RelayCommand(x =>
        {
            //if (SelectedCustomers != null)
            //{
            context.SaveChanges();
            Load();
            //}
            //else
            //{
            //    MessageBox.Show("Empty Data");
            //}
        });
    }
}

using BookStoreWPFWithDbEf.Models;
using BookStoreWPFWithDbEf.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWPFWithDbEf.ViewModels
{
    public class CustomersVM : NotifyPropertyChangedBase
    {
        public CustomersVM(Customers model)
        {
            Model = model;
        }
        public Customers Model { get; set; }
        public int Id { get => Model.Id; }
        public string FirstName
        {
            get => Model.FirstName;
            set
            {
                if (Model.FirstName != value)
                {
                    Model.FirstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }
        public string LastName
        {
            get => Model.LastName;
            set
            {
                if (Model.LastName != value)
                {
                    Model.LastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }
        public string FullName
        { 
            get => $"{LastName} {FirstName}";
        }
        public string Email
        {
            get => Model.Email;
            set
            {
                if (Model.Email != value)
                {
                    Model.Email = value; 
                    OnPropertyChanged(nameof(Email));
                }
            }
        }
        public string PhoneNumber
        {
            get => Model.PhoneNumber;
            set
            {
                if (Model.PhoneNumber != value)
                {
                    Model.PhoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                }
            }
        }
        public string Login
        {
            get => Model.Login;
            set
            {
                if (Model.Login != value)
                {
                    Model.Login = value;
                    OnPropertyChanged(nameof(Login));
                }
            }
        }
        public string Password
        {
            get => Model.Password;
            set
            {
                if (Model.Password != value)
                {
                    Model.Password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }
        public bool IsAdmin
        {
            get => Model.IsAdmin;
            set
            {
                if (Model.IsAdmin != value)
                {
                    Model.IsAdmin = value;
                    OnPropertyChanged(nameof(IsAdmin));
                }
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not CustomersVM model) return false;
            if ((obj as CustomersVM).Model == null) return false;
            return Model.Id.Equals((obj as CustomersVM).Model.Id);
        }
    }
}

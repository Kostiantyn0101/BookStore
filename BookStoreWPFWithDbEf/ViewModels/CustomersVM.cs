﻿using BookStoreWPFWithDbEf.Models;
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
                Model.FirstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string LastName
        {
            get => Model.LastName;
            set
            {
                Model.LastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        public string Email
        {
            get => Model.Email;
            set
            {
                Model.Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string PhoneNumber
        {
            get => Model.PhoneNumber;
            set
            {
                Model.PhoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }
        public string Login
        {
            get => Model.Login;
            set
            {
                Model.Email = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            get => Model.Password;
            set
            {
                Model.Email = value;
                OnPropertyChanged(nameof(Password));
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using LicenseManager.Core.Models;
using LicenseManager.Core.Services;
using LicenseManager.WinDesktop.Services;
using Microsoft.WindowsAzure.MobileServices;

namespace LicenseManager.WinDesktop.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        public MainPage()
        {
            MessageBoxNotificationService notificationService = new MessageBoxNotificationService {Owner = this};
            SimpleIoc.Default.Register<INotificationService>(() => notificationService);

            var navigationService = new WpfNavigationService();
            navigationService.Configure(MessageData.MainPageName, typeof(MainPage));
            navigationService.Configure(MessageData.CustomerListPageName, typeof(CustomerListPage));
            navigationService.Configure(MessageData.CustomerInfoPageName, typeof(CustomerPage));
            navigationService.Configure(MessageData.CustomerEditionPageName, typeof(CustomerEditPage));

            navigationService.Configure(MessageData.AttemptListPageName, typeof(AttemptListPage));
            navigationService.Configure(MessageData.AttemptInfoPageName, typeof(AttemptPage));

            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            SimpleIoc.Default.Register<ILicenseManagerRepository>(() => new AzureLicenseManagerRepository());

            InitializeComponent();
           
            navigationService.Initialize(navigationFrame.NavigationService);
        }
        #region test data
        List<ToDoItem> _todoItems = new List<ToDoItem>
            {
                new ToDoItem { Id = Guid.NewGuid().ToString(), Text = "First item"},
                new ToDoItem { Id = Guid.NewGuid().ToString(), Text = "Second item" },
            };
        private List<Customer> _customers = new List<Customer>
        {
            new Customer
            {
                Id = "1",
                CreatedAt = DateTime.Now,
                IsClient = false,
                Key = "67890",
                Name = "Ivan",
                LastName = "Ivanovenkovich",
                Position = "Software Developer",
                Company = "Xamarin HQ",
                Photo = "http://www.refractored.com/images/SF.png",
                PhoneNumber = "855-916-2743",
                EMail = "ivanov@xam.com",
                Skype = "ivanov.ivan",
                StreetAddress = "394 Pacific Ave. 4th Floor",
                City = "San Francisco",
                State = "CA",
                Country = "United States",
                ZipCode = "94111",
                Latitude = 37.797788,
                Longitude = -122.401858,
                AboutUs = "Sansome & Pacific"
            },
            new Customer
            {
                Id = "2",
                CreatedAt = DateTime.Now,
                IsClient = true,
                Key = "12345",
                Name = "Sarah",
                LastName = "Connor",
                Position = "Security Manager",
                Company = "Xamarin Inc. Argentina",
                Photo = "http://www.refractored.com/images/SF.png",
                PhoneNumber = "855-926-2746",
                EMail = "sarah.connor@mail.com",
                Skype = "",
                StreetAddress = "Av. Pres. Roque Saenz Pena 875",
                City = "Buenos Aires",
                State = "",
                Country = "Argentina",
                ZipCode = "C1035AAD CABA",
                Latitude = -34.6049956875424,
                Longitude = -58.3788027544727,
                AboutUs = "Visual Studio to the Max!"
            },
            new Customer
            {
                Id = "3",
                CreatedAt = DateTime.Now - TimeSpan.FromDays(1),
                IsClient = true,
                Key = "12345",
                Name = "A",
                LastName = "B",
                Position = "Software Developer",
                Company = "Xamarin HQ",
                Photo = "http://www.refractored.com/images/SF.png",
                PhoneNumber = "855-916-2743",
                EMail = "ivanov@xam.com",
                Skype = "ivanov.ivan",
                StreetAddress = "394 Pacific Ave. 4th Floor",
                City = "San Francisco",
                State = "CA",
                Country = "United States",
                ZipCode = "94111",
                Latitude = 37.797788,
                Longitude = -122.401858,
                AboutUs = "Sansome & Pacific"
            },
        };
        private List<Attempt> _attempts = new List<Attempt>
        {
            new Attempt
            {
                Id = "1",
                Name = "John",
                CreatedAt = DateTime.Now,
                LastName = "Bond",
                Position = "Software Developer",
                Company = "Xamarin HQ",
                Photo = "http://www.refractored.com/images/SF.png",
                PhoneNumber = "855-916-2743",
                EMail = "ivanov@xam.com",
                Skype = "ivanov.ivan",
                StreetAddress = "394 Pacific Ave. 4th Floor",
                City = "San Francisco",
                State = "CA",
                Country = "United States",
                ZipCode = "94111",
                Latitude = 37.797788,
                Longitude = -122.401858,
                AboutUs = "Sansome & Pacific"
            },
            new Attempt
            {
                Id = "2",
                Name = "Sarah",
                CreatedAt = DateTime.Now - TimeSpan.FromDays(2),
                LastName = "R",
                Position = "Security Manager",
                Company = "Terminator Inc. U.S.A.",
                Photo = "http://www.refractored.com/images/SF.png",
                PhoneNumber = "855-926-2746",
                EMail = "sarah.connor@mail.com",
                Skype = "",
                StreetAddress = "Av. Pres. Roque Saenz Pena 875",
                City = "Buenos Aires",
                State = "",
                Country = "Argentina",
                ZipCode = "C1035AAD CABA",
                Latitude = -34.6049956875424,
                Longitude = -58.3788027544727,
                AboutUs = "Visual Studio to the Max!"
            },
            new Attempt
            {
                Id = "3",
                Name = "Ron",
                CreatedAt = DateTime.Now,
                LastName = "Bon",
                Position = "Software Developer",
                Company = "Xamarin HQ",
                Photo = "http://www.refractored.com/images/SF.png",
                PhoneNumber = "855-916-2743",
                EMail = "ivanov@xam.com",
                Skype = "ivanov.ivan",
                StreetAddress = "394 Pacific Ave. 4th Floor",
                City = "San Francisco",
                State = "CA",
                Country = "United States",
                ZipCode = "94111",
                Latitude = 37.797788,
                Longitude = -122.401858,
                AboutUs = "Sansome & Pacific"
            },
        };
        #endregion
        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            MobileServiceClient mobileService = new MobileServiceClient("http://localhost:62421/");

            foreach (var toDoItem in _todoItems)
            {
                await mobileService.GetTable<ToDoItem>().InsertAsync(toDoItem);
            }
            var client = await mobileService.GetTable<ToDoItem>().ReadAsync();
            var res = client.ToList();

            foreach (var customer in _customers)
            {
                await mobileService.GetTable<Customer>().InsertAsync(customer);

            }

            var client3 = await mobileService.GetTable<Customer>().ReadAsync();
            var res3 = client3.ToList();

            foreach (var attempt in _attempts)
            {
                await mobileService.GetTable<Attempt>().InsertAsync(attempt);
            }

            var client2 = await mobileService.GetTable<Attempt>().ReadAsync();
            var res2 = client2.ToList();

            
        }
    }
}

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
            //SimpleIoc.Default.Register<ILicenseManagerRepository>(() => new AzureLicenseManagerRepository());

            InitializeComponent();
           
            navigationService.Initialize(navigationFrame.NavigationService);
        }
    }
}

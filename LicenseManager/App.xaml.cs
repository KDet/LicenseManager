using Acr.UserDialogs;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using LicenseManager.Core.Services;
using LicenseManager.XamForms.UI.Pages;
using LicenseManager.XamForms.UI.Services;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;

namespace LicenseManager.XamForms.UI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            XamFormsNotificationService notificationService = new XamFormsNotificationService();
            SimpleIoc.Default.Register<INotificationService>(() => notificationService);
          
            var navigationService = new XamFormsNavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);

            navigationService.Configure(MessageData.MainPageName, typeof(MainPage));
            navigationService.Configure(MessageData.CustomerListPageName, typeof(CustomerListPage));
            navigationService.Configure(MessageData.CustomerInfoPageName, typeof(CustomerPage));
            navigationService.Configure(MessageData.CustomerEditionPageName, typeof(CustomerEditPage));

            navigationService.Configure(MessageData.AttemptListPageName, typeof(AttemptListPage));
            navigationService.Configure(MessageData.AttemptInfoPageName, typeof(AttemptPage));

            var firstPage = new NavigationPage(new MainPage());
            navigationService.Initialize(firstPage);
            MainPage = firstPage;

        }
    }
}

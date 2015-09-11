using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LicenseManager.Core.Models;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace LicenseManager.XamForms.UI.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            MobileServiceClient mobileService = new MobileServiceClient(
                "http://localhost:62421/"
                );
            var client = await mobileService.GetTable<ToDoItem>().ReadAsync();
            var res = client.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using LicenseManager.Core.Services;

namespace LicenseManager.XamForms.UI.Services
{
    public class XamFormsNotificationService : INotificationService
    {
        public void DisplayAlert(string message)
        {
             UserDialogs.Instance.Alert(message, null, "OK");
        }
    }
}

using GalaSoft.MvvmLight.Command;
using LicenseManager.Core.Services;

namespace LicenseManager.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
	{
	    private RelayCommand _goToCustomers;
		public RelayCommand GoToCustomersCommand
		{
		    get
		    {
		        return _goToCustomers ??
		               (_goToCustomers = new RelayCommand(GoToCustomers));
		    }
		}
        private RelayCommand _goToAttempts;
        public RelayCommand GoToAttemptsCommand
        {
            get
            {
                return _goToAttempts ??
                       (_goToAttempts = new RelayCommand(GoToAttempts));
            }
        }

        private void GoToCustomers()
        {
            NavigatioService.NavigateTo(MessageData.CustomerListPageName);
        }
        private void GoToAttempts()
		{
			NavigatioService.NavigateTo(MessageData.AttemptListPageName);
		}
	}
}
using GalaSoft.MvvmLight.Command;
using LicenseManager.Core.Services;

namespace LicenseManager.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
	{
	    private RelayCommand _goToCustomers;
        private RelayCommand _goToAttempts;

        private void GoToCustomers()
        {
            NavigatioService.NavigateTo(MessageData.CustomerListPageName);
        }
        private void GoToAttempts()
        {
            NavigatioService.NavigateTo(MessageData.AttemptListPageName);
        }

        public RelayCommand GoToCustomersCommand
		{
		    get
		    {
		        return _goToCustomers ??
		               (_goToCustomers = new RelayCommand(GoToCustomers));
		    }
		}      
        public RelayCommand GoToAttemptsCommand
        {
            get
            {
                return _goToAttempts ??
                       (_goToAttempts = new RelayCommand(GoToAttempts));
            }
        }
		public MainViewModel()
		{
		}
			
	}
}
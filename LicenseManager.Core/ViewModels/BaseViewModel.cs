using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace LicenseManager.Core.ViewModels
{
    public class BaseViewModel : ViewModelBase
    {
        private bool _isBusy;

        protected readonly INavigationService NavigatioService;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { Set(() => IsBusy, ref _isBusy, value); }
        }

        public BaseViewModel()
        {
            NavigatioService = SimpleIoc.Default.GetInstance<INavigationService>();
        }
    }
}
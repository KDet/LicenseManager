using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using LicenseManager.Core.Helpers;
using LicenseManager.Core.Services;

namespace LicenseManager.Core.ViewModels
{
    public class BaseListViewModel<TItemViewModel> : BaseViewModel
    {
        private ObservableCollection<Grouping<string, TItemViewModel>> _itemsGrouped =
            new ObservableCollection<Grouping<string, TItemViewModel>>();
        private ObservableCollection<TItemViewModel> _items 
            = new ObservableCollection<TItemViewModel>();

        protected readonly ILicenseManagerRepository LicenseManagerRepository;

        private RelayCommand _getItemsCommand;
        private RelayCommand<TItemViewModel> _goToItemCommand;
       
        public ObservableCollection<Grouping<string, TItemViewModel>> ItemsGrouped
        {
            get { return _itemsGrouped; }
            set { Set(() => ItemsGrouped, ref _itemsGrouped, value); }
        }
        public ObservableCollection<TItemViewModel> Items
        {
            get { return _items; }
            set { Set(() => Items, ref _items, value); }
        }

        public RelayCommand GetItemsCommand
        {
            get
            {
                return _getItemsCommand ??
                       (_getItemsCommand = new RelayCommand(async () => await GetItems(), () => !IsBusy));
            }
        }
        public RelayCommand<TItemViewModel> GoToItemCommand
        {
            get
            {
                return _goToItemCommand ??
                       (_goToItemCommand = new RelayCommand<TItemViewModel>(GoToItem, customer => customer != null));
            }
        }

        protected virtual Task GetItems()
        {
            return null;
        }
        protected virtual void GoToItem(TItemViewModel itemViewModel)
        {

        }
        public virtual Task Delete(TItemViewModel itemViewModel)
        {
            return null;
        }

        public BaseListViewModel(ILicenseManagerRepository licenseManagerRepository)
        {
            LicenseManagerRepository = licenseManagerRepository;
        }
    }
}